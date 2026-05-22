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

			Logger.Info("Label 1");

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
			Logger.Info("Label 2");

			VersionInfoDialog dialog	= new VersionInfoDialog();

			Logger.Info("Label 3");

			if (version == null)
			{
				Logger.Trace("GetVersion: version == null");
			}
			else
			{
				Logger.Trace($"GetVersion: version == {version}");
			}

			Logger.Info("Label 3.1");
			dialog.VersionInfo			= version;
			Logger.Info("Label 3.2");

			dialog.WorkingDirectory		= this.WorkingFolder;

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Logger.Info("Label 4");
				return dialog.VersionInfo;
			}
			else
			{

				Logger.Info("Label 5");
				return null;
			}
		}

		private VersionInfo GetConfigurationVersion()
		{
			VersionInfo version = null;

			string fileName = Path.Combine(this.WorkingFolder, VERSION_FILE_NAME);

			Logger.Trace($"GetConfigurationVersion: {fileName}");

			if (File.Exists(fileName))
			{
				Logger.Trace("GetConfigurationVersion: file exists");

				version = VersionInfo.Load(fileName);
			}
			else
			{
				Logger.Trace("GetConfigurationVersion: file does not exist");
				version = new VersionInfo();
			}
			
			Logger.Trace($"GetConfigurationVersion: {version}");

			return version;
		}
	}
}
