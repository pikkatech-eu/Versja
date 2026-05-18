/***********************************************************************************
* File:         DefaultVersjaManager.cs                                            *
* Contents:     Class DefaultVersjaManager                                         *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-17 13:57                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Xml.Linq;
using VD = Versja.Domain;

namespace Versja.Application
{
	/// <summary>
	/// Incrementer: 
	/// reads version from project file and configuration file, 
	/// merges them, increments build and (if defined) patch; 
	/// saves project file and configuration file.
	/// </summary>
	public class Incrementer
	{
		#region Constants
		private const string VERSION_FILE_NAME	= "version.json";
		private const string PROPERTY_GROUP		= "PropertyGroup";
		private const string VERSION			= "Version";
		private const string IS_RELEASE_PROJECT	= "IsReleaseProject";
		#endregion

		#region Properties
		public string ProjectFileName	{get;set;} = null;
		public string WorkingFolder		{get;set;} = null;
		#endregion

		#region Public feature
		/// <summary>
		/// Reads version from project file and configuration file, 
		/// merges them, increments build and (if defined) patch; 
		/// saves project file and configuration file.
		/// </summary>
		/// <param name="projectFileName">Name of the project file.</param>
		public void IncrementVersion(string projectFileName)
		{
			this.ProjectFileName		= projectFileName;

			this.WorkingFolder			= new DirectoryInfo(this.ProjectFileName).Parent.FullName;

			// Read configurated version from version.json
			VD.Version versionConfig	= this.GetConfigurationVersion();

			// Read current version from .csproj
			VD.Version versionProject	= this.ReadProjectVersion();

			// Update Build and Patch in versionConfiguration using values from versionProject
			VD.Version version			= this.MergeVersions(versionProject, versionConfig);

			// Increment Build and Patch in versionConfiguration
			this.IncrementBuildAndPatch(version);

			Console.WriteLine($"New version: {version}");

			// write to .csproj
			this.WriteToConfigurationFile(version);

			// write to version.json
			this.WriteToProjectFile(version);
		}
		#endregion

		#region Private Auxiliary
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

		/// <summary>
		/// Reads the instance of Version from XML element of project file (.csproj).
		/// </summary>
		/// <returns>Instance of Version from XML in .csproj file.</returns>
		private VD.Version ReadProjectVersion()
		{
			XElement x = XElement.Load(this.ProjectFileName);

			// Find child XElement "PropertyGroup" containing element "Version".
			// If it does not exist, take the first one.
			XElement xGroup = x.Elements(PROPERTY_GROUP).FirstOrDefault(xg => xg.Element(VERSION) != null);

			if (xGroup == null)
			{
				xGroup = x.Elements(PROPERTY_GROUP).First();
			}

			VD.Version version = null;

			// Find child element "Version" in xGroup.
			// If found, parse its value to this.Version.
			// Othervise, initialize this.Version with default values.
			if (xGroup.Element(VERSION) != null)
			{
				string sVersion	= xGroup.Element(VERSION).Value;
				version	= VD.Version.Parse(sVersion);
			}
			else
			{
				version	= new VD.Version();
			}

			// Detect runtime target (if there aré more than one, take the first one).
			if (xGroup.Element("TargetFramework") != null)
			{
				string target = xGroup.Element("TargetFramework").Value;

				if (!String.IsNullOrEmpty(target))
				{
					string[] targets			= target.Split(';');
					version.RuntimeTarget	= targets[0];
				}
			}

			return version;
		}

		/// <summary>
		/// Merges instances of Version from configuration and from project.
		/// Takes DateTime, cadence and patch from the project instance.
		/// </summary>
		/// <param name="versionProject"></param>
		/// <param name="versionConfiguration"></param>
		/// <returns>Instance of Version merged.</returns>
		private VD.Version MergeVersions(VD.Version versionProject, VD.Version versionConfiguration)
		{
			VD.Version version		= versionConfiguration;
			version.VersionDateTime	= versionProject.VersionDateTime;
			version.Cadence			= versionProject.Cadence;
			
			return version;
		}

		/// <summary>
		/// Increments Build values in an instance of Version:
		/// DateTime, cadence and, if AutoincrementPatch is set, also the patch.
		/// </summary>
		/// <param name="version">Instance of Version with values incremented.</param>
		private void IncrementBuildAndPatch(VD.Version version)
		{
			// Increment date and cadence.
			if (version.VersionDateTime?.Date == DateTime.Today.Date)
			{
				version.Cadence++;
			}
			else
			{
				version.VersionDateTime = DateTime.Today;
				version.Cadence = 1;
			}

			if (version.AutoIncrementPatch)
			{
				version.Patch++;
			}
		}

		/// <summary>
		/// Writes an instance of Version ito configuration file.
		/// </summary>
		/// <param name="version">Version to write.</param>
		private void WriteToConfigurationFile(VD.Version version)
		{
			version.Save(Path.Combine(this.WorkingFolder, VERSION_FILE_NAME));
		}

		/// <summary>
		/// Writes an instance of Version into projectz file (.csproj).
		/// </summary>
		/// <param name="version"></param>
		private void WriteToProjectFile(VD.Version version)
		{
			string sVersion = version.ToString();

			XElement x = XElement.Load(this.ProjectFileName);

			XElement xGroup = x.Elements(PROPERTY_GROUP).FirstOrDefault(xg => xg.Element(VERSION) != null);

			if (xGroup == null)
			{
				xGroup = x.Elements(PROPERTY_GROUP).First();
			}

			if (xGroup.Element(VERSION) == null)
			{
				xGroup.Add(new XElement(VERSION));
			}
			
			if (xGroup.Element(IS_RELEASE_PROJECT) == null)
			{
				xGroup.Add(new XElement(IS_RELEASE_PROJECT));
			}
			
			XElement xVersion			= xGroup.Element(VERSION);
			xVersion.Value				= sVersion;
			XElement xIsReleaseProject	= xGroup.Element(IS_RELEASE_PROJECT);
			xIsReleaseProject.Value		= version.IsReleaseProject.ToString();

			x.Save(this.ProjectFileName);
		}
		#endregion
	}
}
