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
		static void Main(string[] args)
		{


			File.AppendAllText(
								@"C:\Temp\versja.log",
								$"[{DateTime.Now:HH:mm:ss.fff}] " +
								$"PID={Environment.ProcessId} " +
								$"CMD={Environment.CommandLine}\n"
							);

			Logger.Open("Versja");

			Logger.Debug($"args.Length={args.Length}");

			for (int i = 0; i < args.Length; i++)
			{
				Logger.Debug($"i = {i}; arg[i]={args[i]}");
			}

			if (args.Length == 2)
			{
				string projectFileName	= args[0];
				string action			= args[1];

				Logger.Debug($"projectFileName={projectFileName}");
				Logger.Debug($"action={action}");

				if (action == "increment")
				{
					Logger.Info("action = increment");

					Incrementer incrementer = new Incrementer();
					incrementer.IncrementVersion(projectFileName);
					return;
				}
				else if (action == "configure")
				{
					Logger.Info("action = configure");

					Configurator configurator = new Configurator();
					configurator.Configure(projectFileName);
					return;
				}
				else
				{
					Logger.Info("action = default");

					Console.WriteLine("stupid");

					return;
				}
			}
			else
			{
				Logger.Info("wrong number of arguments");

				Console.WriteLine("Versja: Tool to semi-automated increment versions of VS projects.");
				Console.WriteLine("Usage: versja.exe FULL_PROJECT_FILE_NAME ACTION");
				Console.WriteLine("FULL_PROJECT_FILE_NAME: full path to the .csproj file");
				Console.WriteLine("ACTION: \"increment\" to automatically increment version");
				Console.WriteLine("        \"configure\" to manually configure");
			}
		}
	}
}
