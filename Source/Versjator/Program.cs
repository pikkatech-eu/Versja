/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-18 10:18                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Versja.Configurator
{
	internal static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Versja CLI tool.\n" +
					"Usage: Versjator.exe PROJECT_FILE_NAME\n" +
					"Where: PROJECT_FILE_NAME is the name of the project file (.csproj)");

				return;
			}

			string projectFile = args[0];

			Console.WriteLine($"Configuring project version for {projectFile}");

			Configurator configurator = new Configurator();
			configurator.Configure(projectFile);

			Console.WriteLine($"Version successfully configured for {projectFile}");
		}
	}
}