# gh2ghx-converter
**gh2ghx-converter** is a command-line tool for converting binary Grasshopper files (*.gh*) to XML-based Grasshopper files (*.ghx*). Grasshopper is a popular visual programming language and environment for [Rhino 3D modeling software](https://www.rhino3d.com). This tool provides a simple and efficient way to convert Grasshopper files, making them more accessible and interoperable with other software and versions of Grasshopper.

# Features

- Converts binary .gh files to XML-based .ghx files.
- Preserves the structure and functionality of the original Grasshopper definition.
- Compatible with Grasshopper files created in different versions of Rhino.

# Installation 

To use gh2ghx-converter, you'll need to open Rhino3D with a license. Once you have Rhino3D opened, you can load one of the scripts into Grasshopper.

# Usage

Replace the input parameters with the `input path` to the folder with your binary Grasshopper files and replace the parameter with the `output path` with the desired name for the resulting XML-based Grasshopper files. Then click the button to run the C# script and logger creates a `text output` and a `list output` with the converted file names.

## Example:
bash
Copy code
gh2ghx-converter my_design.gh my_design.ghx

# Script 

```cs
```
