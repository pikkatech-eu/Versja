/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-17 21:50                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Versja.Application;

class Program
{
    static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Versja CLI tool.\n" +
                "Usage: Versja.Application.exe PROJECT_FILE_NAME\n" +
                "Where: PROJECT_FILE_NAME is the name of the project file (.csproj)");

            return;
        }

        string projectFile = args[0];

        Incrementer incrementer = new Incrementer();
        incrementer.IncrementVersion(projectFile);
    }
}
