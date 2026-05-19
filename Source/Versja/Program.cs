/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-17 21:50                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Versja.Application;
using VD = Versja.Domain;

class Program
{
    static void Main(string[] args)
    {
        //VD.Version version = new VD.Version();
        //version.Major   = 1;
        //version.Minor   = 2;
        //version.Patch   = 42;
        //version.RuntimeTarget   = "net9.0";
        //version.RCNumber    = 5;
        //version.VersionDateTime = DateTime.Today;
        //version.AutoIncrementPatch = true;
        //version.Cadence = 17;
        //version.ReleaseIdentifier = VD.ReleaseIdentifier.Beta;

        //string s = version.ToString();

        //var y = VD.Version.Parse(s);

        if (args.Length == 0)
        {
            Console.WriteLine("Versja CLI tool.\n" +
                "Usage: Versja.exe PROJECT_FILE_NAME\n" +
                "Where: PROJECT_FILE_NAME is the name of the project file (.csproj)");

            return;
        }

        string projectFile = args[0];

        Console.WriteLine($"Incrementing project version for {projectFile}");

        Incrementer incrementer = new Incrementer();

        try
        {
            incrementer.IncrementVersion(projectFile);
            Console.WriteLine($"Version successfully incremented for {projectFile}");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine($"Could not increment version. Error: {ae.Message}");
        }
    }
}
