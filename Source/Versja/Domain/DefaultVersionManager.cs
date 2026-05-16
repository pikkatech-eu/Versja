/***********************************************************************************
* File:         DefaultVersionManager.cs                                           *
* Contents:     Class DefaultVersionManager                                        *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-15 22:22                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Xml.Linq;

namespace Versja.Domain
{
	public class DefaultVersionManager : IVersionManager
	{
		private const string VERSION_FILE_NAME = "version.json";
		
		#region Properties
		public string WorkingDirectory		{get;set;} = "";
		public string ProjectFileName		{get;set;} = "";
		public Version Version				{get;set;} = null;
		#endregion

		public DefaultVersionManager(string workingDirectory = "")
		{
			this.WorkingDirectory	= workingDirectory;
		}

		public void GetProjectFileName()
		{
			string[] fileNames = Directory.GetFiles(this.WorkingDirectory, "*.csproj");

			if (fileNames.Length == 1)
			{
				this.ProjectFileName = fileNames[0];
			}
			else
			{
				throw new FileNotFoundException($"Directory {this.WorkingDirectory}\ndoes not have a project file or has more than one.\nStopping.");
			}
		}

		public void CreateVersion()
		{
			this.Version = new Version();
		}

		public void LoadVersion()
		{
			try
			{
				this.Version = Version.Load(Path.Combine(this.WorkingDirectory, VERSION_FILE_NAME));
			}
			catch (Exception)
			{
				this.CreateVersion();
			}
		}

		public void SaveVersion()
		{
			this.Version.Save(Path.Combine(this.WorkingDirectory, VERSION_FILE_NAME));
		}

		public void IncrementVersion()
		{
			switch (this.Version.ReleaseIdentifier)
			{
				case ReleaseIdentifier.Alpha:
				case ReleaseIdentifier.Beta:
				case ReleaseIdentifier.Patch:
				case ReleaseIdentifier.Preview:
				case ReleaseIdentifier.Unstable:
				case ReleaseIdentifier.Development:
					if (this.Version.AutoIncrementPatch)
					{
						this.Version.Patch++;
					}
					
					break;

				case ReleaseIdentifier.ReleaseCandidate:
					this.Version.RCNumber++;
					break;

				case ReleaseIdentifier.Snapshot:
				case ReleaseIdentifier.None:
				default:
					break;
			}

			DateTime today = DateTime.Today;

			if (today.Date == ((DateTime)this.Version.VersionDateTime).Date)
			{
				this.Version.Cadence++;
			}
			else
			{
				this.Version.VersionDateTime = today;
			}
		}

		public void ExtractVersion()
		{
			XElement x = XElement.Load(this.ProjectFileName);

			XElement xGroup = x.Elements("PropertyGroup").FirstOrDefault(xg => xg.Element("Version") != null);

			if (xGroup == null)
			{
				xGroup = x.Elements("PropertyGroup").First();
			}

			if (xGroup.Element("Version") != null)
			{
				string sVersion	= xGroup.Element("Version").Value;
				this.Version	= Version.Parse(sVersion);
			}
			else
			{
				this.CreateVersion();
			}

			if (xGroup.Element("TargetFramework") != null)
			{
				string target					= xGroup.Element("TargetFramework").Value;

				if (!String.IsNullOrEmpty(target))
				{
					string[] targets			= target.Split(';');
					this.Version.RuntimeTarget	= targets[0];
				}
			}
		}

		public void InjectVersion()
		{
			string sVersion = this.Version.ToString();

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
			xIsReleaseProject.Value		= this.Version.IsReleaseProject.ToString();

			x.Save(this.ProjectFileName);
		}
	}
}
