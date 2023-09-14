using System.IO;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.InteropServices;

// Limited to the use within Rhino3D
using Rhino.DocObjects;
using Rhino.Collections;
using GH_IO;
using GH_IO.Serialization;

if (!Convert) return;

if (!System.IO.Directory.Exists(FolderIn)) return;
if (!System.IO.Directory.Exists(FolderOut))
    System.IO.Directory.CreateDirectory(FolderOut);

// Note: this could be made recursive, but additional code will be required.
string[] files = System.IO.Directory.GetFiles(FolderIn, "*.gh", SearchOption.TopDirectoryOnly);

// No gh files found in the source directory.
if (files == null || files.Length == 0) return;

List<string> convertedFiles = new List<string>();
foreach (string file in files)
{
    string filename = System.IO.Path.GetFileNameWithoutExtension(file) + ".ghx";
    string filepath = FolderOut + filename;

    // Do not override already converted files.
    if (System.IO.File.Exists(filepath))
        continue;

    GH_Archive archive = new GH_Archive();
    if (!archive.ReadFromFile(file))
        continue;

    if (archive.WriteToFile(filepath, false, false))
        convertedFiles.Add(filepath);
}

Files = convertedFiles;
