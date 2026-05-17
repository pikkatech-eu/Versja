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
	public class Incrementer
	{
		private const string VERSION_FILE_NAME = "version.json";

		public string ProjectFileName	{get;set;} = null;
		public string WorkingFolder		{get;set;} = null;

		public void IncrementVersion(string projectFileName)
		{
			this.ProjectFileName	= projectFileName;

			this.WorkingFolder		= new DirectoryInfo(this.ProjectFileName).Parent.FullName;

			// Read configurated version from version.json
			VD.Version versionConfig = this.GetConfigVersion();

			// Read current version from .csproj
			VD.Version versionProject = this.ReadProjectVersion();

			// Update Build and Patch in versionConfig using values from versionProject
			VD.Version version		= this.MergeVersions(versionProject, versionConfig);

			// Increment Build and Patch in versionConfig
			this.IncrementBuildAndPatch(version);

			// write to .csproj
			this.WriteToConfigFile(version);

			// write to version.json
			this.WriteToProjectFile(version);
		}

		private void WriteToProjectFile(VD.Version version)
		{
			string sVersion = version.ToString();

			XElement x = XElement.Load(this.ProjectFileName);

			XElement xGroup = x.Elements("PropertyGroup").FirstOrDefault(xg => xg.Element("Version") != null);

			if (xGroup == null)
			{
				xGroup = x.Elements("PropertyGroup").First();
			}

			if (xGroup.Element("Version") == null)
			{
				xGroup.Add(new XElement("Version"));
			}
			
			if (xGroup.Element("IsReleaseProject") == null)
			{
				xGroup.Add(new XElement("IsReleaseProject"));
			}
			
			XElement xVersion			= xGroup.Element("Version");
			xVersion.Value				= sVersion;
			XElement xIsReleaseProject	= xGroup.Element("IsReleaseProject");
			xIsReleaseProject.Value		= version.IsReleaseProject.ToString();

			x.Save(this.ProjectFileName);
		}

		private void WriteToConfigFile(VD.Version version)
		{
			version.Save(Path.Combine(this.WorkingFolder, VERSION_FILE_NAME));
		}

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

		private VD.Version MergeVersions(VD.Version versionProject, VD.Version versionConfig)
		{
			VD.Version version		= versionConfig;
			version.VersionDateTime	= versionProject.VersionDateTime;
			version.Cadence			= versionProject.Cadence;
			
			return version;
		}

		private VD.Version GetConfigVersion()
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

		private void GetProjectFileName()
		{
			if (String.IsNullOrEmpty(this.WorkingFolder))
			{
				return;
			}

			string[] fileNames = Directory.GetFiles(this.WorkingFolder, "*.csproj");

			if (fileNames.Length == 1)
			{
				this.ProjectFileName = fileNames[0];
			}
			else
			{
				throw new FileNotFoundException($"Directory {this.WorkingFolder}\ndoes not have a project file or has more than one.\nStopping.");
			}
		}

		private VD.Version ReadProjectVersion()
		{
			XElement x = XElement.Load(this.ProjectFileName);

			// Find child XElement "PropertyGroup" containing element "Version".
			// If it does not exist, take the first one.
			XElement xGroup = x.Elements("PropertyGroup").FirstOrDefault(xg => xg.Element("Version") != null);

			if (xGroup == null)
			{
				xGroup = x.Elements("PropertyGroup").First();
			}

			VD.Version version = null;

			// Find child element "Version" in xGroup.
			// If found, parse its value to this.Version.
			// Othervise, initialize this.Version with default values.
			if (xGroup.Element("Version") != null)
			{
				string sVersion	= xGroup.Element("Version").Value;
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
	}
}
