/***********************************************************************************
* File:         Incrementer.cs                                                     *
* Contents:     Class Incrementer                                                  *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-20 08:57                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Versja
{
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
			VersionInfo versionConfig	= this.GetConfigurationVersion();

			Console.WriteLine($"Version from {VERSION_FILE_NAME}: {versionConfig}");

			// Read current version from .csproj
			VersionInfo versionProject	= this.ReadProjectVersion();

			Console.WriteLine($"Version from {this.ProjectFileName}: {versionProject}");

			// Update Build and Patch in versionConfiguration using values from versionProject
			VersionInfo version			= this.MergeVersions(versionProject, versionConfig);

			// Increment Build and Patch in versionConfiguration
			this.IncrementRevisionAndDate(version);

			// Console output: resulting version
			Console.WriteLine($"New version: {version}");

			// write to .csproj
			this.WriteToConfigurationFile(version);

			// write to version.json
			this.WriteToProjectFile(version);
		}

		private void WriteToProjectFile(VersionInfo version)
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

			x.Save(this.ProjectFileName);
		}

		private void WriteToConfigurationFile(VersionInfo version)
		{
			version.Save(Path.Combine(this.WorkingFolder, VERSION_FILE_NAME));
		}

		private void IncrementRevisionAndDate(VersionInfo version)
		{
			// Increment date and cadence.
			if (version.Date == DateTime.Today.Date)
			{
				version.Cadence++;
			}
			else
			{
				version.Date = DateTime.Today;
				version.Cadence = 1;
			}

			version.Revision++;
		}

		private VersionInfo MergeVersions(VersionInfo versionProject, VersionInfo versionConfig)
		{
			VersionInfo version		= versionConfig;
			version.Date			= versionProject.Date;
			version.Cadence			= versionProject.Cadence;

			if (String.IsNullOrEmpty(version.RuntimeTarget) && !String.IsNullOrEmpty(versionProject.RuntimeTarget))
			{
				version.RuntimeTarget	= versionProject.RuntimeTarget;
			}
			
			return version;
		}

		private VersionInfo ReadProjectVersion()
		{
			XElement x = XElement.Load(this.ProjectFileName);

			// Find child XElement "PropertyGroup" containing element "Version".
			// If it does not exist, take the first one.
			XElement xGroup = x.Elements(PROPERTY_GROUP).FirstOrDefault(xg => xg.Element(VERSION) != null);

			if (xGroup == null)
			{
				xGroup = x.Elements(PROPERTY_GROUP).First();
			}

			VersionInfo version = null;

			// Find child element "Version" in xGroup.
			// If found, parse its value to this.Version.
			// Othervise, initialize this.Version with default values.
			if (xGroup.Element(VERSION) != null)
			{
				string sVersion	= xGroup.Element(VERSION).Value;

				bool canParse	= VersionInfo.TryParse(sVersion, out version);

				if (!canParse)
				{
					return null;
				}
			}
			else
			{
				version	= new VersionInfo();
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
		#endregion
	}
}
