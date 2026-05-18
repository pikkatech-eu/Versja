using Versja.Application;

namespace Versja.Configurator
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
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

			Configurator configurator = new Configurator();
			configurator.Configure(projectFile);
		}
	}
}