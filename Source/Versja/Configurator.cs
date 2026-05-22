/***********************************************************************************
* File:         Configurator.cs                                                    *
* Contents:     Class Configurator                                                 *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-20 09:34                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factotum.Logging;

namespace Versja
{
	public class Configurator
	{
		private const string VERSION_FILE_NAME	= "version.json";

		#region Properties
		public string ProjectFileName	{get;set;} = null;
		public string WorkingFolder		{get;set;} = null;
		#endregion

		public void Configure(string projectFileName)
		{
			this.ProjectFileName		= projectFileName;

			this.WorkingFolder			= new DirectoryInfo(this.ProjectFileName).Parent.FullName;

			// Read configurated version from version.json
			VersionInfo versionConfig	= this.GetConfigurationVersion();

			VersionInfo version			= this.GetVersion(versionConfig);

			Logger.Trace($"versionConfig={versionConfig}");

			Console.WriteLine($"New version: {version}");

			this.WriteToConfigurationFile(version);
		}

		private void WriteToConfigurationFile(VersionInfo version)
		{
			if (version != null)
			{
				version.Save(Path.Combine(this.WorkingFolder, VERSION_FILE_NAME));
			}
		}

		private VersionInfo GetVersion(VersionInfo version)
		{
			VersionInfoDialog dialog	= new VersionInfoDialog();
			dialog.VersionInfo			= version;
			dialog.WorkingDirectory		= this.WorkingFolder;

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				return dialog.VersionInfo;
			}
			else
			{
				return null;
			}
		}

		private VersionInfo GetConfigurationVersion()
		{
			VersionInfo version = null;

			try
			{
				version = VersionInfo.Load(Path.Combine(this.WorkingFolder, VERSION_FILE_NAME));
			}
			catch (Exception)
			{
				version = new VersionInfo();
			}

			return version;
		}
	}
}
