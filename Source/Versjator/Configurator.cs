/***********************************************************************************
* File:         Configurator.cs                                                    *
* Contents:     Class Configurator                                                 *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-17 22:12                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using Versja.Domain.GUI.Dialogs;
using VD = Versja.Domain;

namespace Versja.Configurator
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
			VD.Version versionConfig	= this.GetConfigurationVersion();

			VD.Version version			= this.GetVersion(versionConfig);

			Console.WriteLine($"New version: {version}");

			this.WriteToConfigurationFile(version);
		}

		/// <summary>
		/// Reads the instance of Version from configuration file;
		/// If the latter does not exist, creates it.
		/// </summary>
		/// <returns>Instance of confuguration Version, read or created.</returns>
		private VD.Version GetConfigurationVersion()
		{
			VD.Version version = null;

			try
			{
				version = VD.Version.Load(Path.Combine(this.WorkingFolder, VERSION_FILE_NAME));
			}
			catch (Exception)
			{
				version = new VD.Version();
			}

			return version;
		}

		private VD.Version GetVersion(VD.Version version)
		{
			VersionDialog dialog	= new VersionDialog();
			dialog.Version			= version;
			dialog.WorkingDirectory	= this.WorkingFolder;

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				return dialog.Version;
			}
			else
			{
				return null;
			}
		}

		private void WriteToConfigurationFile(VD.Version version)
		{
			version.Save(Path.Combine(this.WorkingFolder, VERSION_FILE_NAME));
		}
	}
}
