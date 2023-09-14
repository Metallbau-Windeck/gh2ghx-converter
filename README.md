# gh2ghx-converter
**gh2ghx-converter** is a command-line tool for converting binary Grasshopper files (*.gh*) to XML-based Grasshopper files (*.ghx*). Grasshopper is a popular visual programming language and environment for [Rhino 3D modeling software](https://www.rhino3d.com). This tool provides a simple and efficient way to convert Grasshopper files, making them more accessible and interoperable with other software and versions of Grasshopper.

# Features

- Converts binary .gh files to XML-based .ghx files.
- Preserves the structure and functionality of the original Grasshopper definition.
- Compatible with Grasshopper files created in different versions of Rhino.

# Installation 

To use `gh2ghx-converter`, you'll need to open Rhino3D with an active license. Once you have Rhino3D opened, you can load one of the scripts into Grasshopper.

# Usage

Replace the input parameters with the `input path` to the folder with your binary Grasshopper files and replace the parameter with the `output path` with the desired name for the resulting XML-based Grasshopper files. Then click the button to run the C# script and logger creates a `text output` and a `list output` with the converted file names.

# Script

```cs
using System.IO;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.InteropServices;

// Limited to the use in Rhino3D
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
```
