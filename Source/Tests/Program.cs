using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versja;

namespace Tests
{
	public class Program
	{
		[STAThread]
		static void Main()
		{
			string projectFileName = "C:\\pikkatech.eu\\Projects\\.Net\\Zoo\\Versja\\Source\\Tests\\Tests.csproj";

			Incrementer incrementer = new Incrementer();
			incrementer.IncrementVersion(projectFileName);

			//Configurator configurator = new Configurator();
			//configurator.Configure(projectFileName);
		}
	}
}
