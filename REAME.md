#  Listing ACC \BIM 360 Structure in Windows CLI

[![Autodesk Construction Cloud API](https://img.shields.io/badge/ACC-v1-brightgreen.svg)](https://forge.autodesk.com/en/docs/acc/v1/overview/)
![.NET5.0](https://img.shields.io/badge/.NET-5.0-brightgreen.svg)
![Beginner](https://img.shields.io/badge/Level-Beginner-green.svg)
[![License](https://img.shields.io/:license-MIT-blue.svg)](http://opensource.org/licenses/MIT)



This is hobby project I developed for amusement, if we can replicate a [tree kind structure](https://learnforge.autodesk.io/#/tutorials/viewhubmodels) in windows console environment.

## DEMO

![3LeggedOAuth](D:\Work\Forge\UploadFileToBIM360\ListTree\3LeggedOAuth.gif)

# Setup

## Prerequisites

1. **Forge Account**: Learn how to create a Forge Account, activate subscription and create an app at [this tutorial](http://learnforge.autodesk.io/#/account/).

2. **Visual Studio**: Either Community (Windows) or Code (Windows, MacOS).

3. **.NET 5** basic knowledge with C#

   


## Running locally

Clone this project or download it. It's recommended to install [GitHub desktop](https://desktop.github.com/). To clone it via command line, use the following (**Terminal** on MacOSX/Linux, **Git Shell** on Windows):

```bash
git clone https://github.com/MadhukarMoogala/ListTree.git
cd ListTree
set FORGE_CLIENT_ID=
set FORGE_CLIENT_SECRET=
dotnet restore
dotnet run
```

**Visual Studio** (Windows):

Right-click on the project, then go to **Add New Item\Web\JSON File**. Adjust the settings as shown below. Set Forge variables, define the following:

```json
{
  "Forge": {
    "ClientId": "",
    "ClientSecret": ""
  }
}

```

Alternatively, right-click on the project, then go to **Debug**. Adjust the settings as shown below. For environment variable, define the following:

- FORGE_CLIENT_ID: `your id here`
- FORGE_CLIENT_SECRET: `your secret here`

**Visual Studio Code** (Windows, MacOS):

Open the folder, at the bottom-right, select **Yes** and **Restore**. This restores the packages (e.g. Autodesk.Forge) and creates the launch.json file. See *Tips & Tricks* for .NET Core on MacOS.

## Build 

```bash
Microsoft (R) Build Engine version 16.10.1+2fd48ab73 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
C:\Program Files\dotnet\sdk\5.0.301\NuGet.targets(131,5): warning : Unable to find a project to restore! [D:\Work\Forge\UploadFileToBIM360\ListTree\ListTree.sln]

Build succeeded.

C:\Program Files\dotnet\sdk\5.0.301\NuGet.targets(131,5): warning : Unable to find a project to restore! [D:\Work\Forge\UploadFileToBIM360\ListTree\ListTree.sln]
    1 Warning(s)
    0 Error(s)

Time Elapsed 00:00:00.26
```

## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](https://github.com/MadhukarMoogala/ListTree/blob/master/LICENSE) file for full details.

## Written by

Madhukar Moogala [@galakar](http://twitter.com/galakar), [Forge Partner Development](http://forge.autodesk.com/)





