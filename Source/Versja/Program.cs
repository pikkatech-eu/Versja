/***********************************************************************************
* File:         Program.cs                                                         *
* Contents:     Class Program                                                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-19 19:55                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/


using Factotum.Logging;

namespace Versja
{
	public static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Logger.Open("Versja");

			if (args.Length == 2)
			{
				string projectFileName	= args[0];
				string action			= args[1];

				if (action == "increment")
				{
					Incrementer incrementer = new Incrementer();
					incrementer.IncrementVersion(projectFileName);
					return;
				}
				else if (action == "configure")
				{
					Configurator configurator = new Configurator();
					configurator.Configure(projectFileName);
					return;
				}
				else
				{
					return;
				}
			}
			else
			{
				Console.WriteLine("Versja: Tool to semi-automated increment versions of VS projects.");
				Console.WriteLine("Usage: versja.exe FULL_PROJECT_FILE_NAME ACTION");
				Console.WriteLine("FULL_PROJECT_FILE_NAME: full path to the .csproj file");
				Console.WriteLine("ACTION: \"increment\" to automatically increment version");
				Console.WriteLine("        \"configure\" to manually configure");
			}
		}
	}
}
