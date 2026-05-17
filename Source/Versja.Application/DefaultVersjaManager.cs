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
	public class DefaultVersjaManager : IVersjaManager
	{
		private const string VERSION_FILE_NAME = "version.json";

		#region Properties
		/// <summary>
		/// Working project directory (contains .csproj file).
		/// </summary>
		public string		WorkingDirectory	{get;set;} = null;

		/// <summary>
		/// Name of the project file.
		/// </summary>
		public string		ProjectFileName		{get;set;} = null;

		/// <summary>
		/// Value of Version.
		/// </summary>
		public VD.Version	Version				{get;set;} = null;

		/// <summary>
		/// Pattern value of Version, as read from the version file.
		/// </summary>
		public VD.Version	PatternVersion		{get;set;} = null;
		#endregion

		#region Construction
		/// <summary>
		///		Initializes WorkingDirectory, ProjectFileName and Version.
		/// </summary>
		/// <param name="workingDirectory">Working directory in which to initialize data.</param>
		/// <exception cref="FileNotFoundException">Thrown if project file was not found in WorkingDirectory.</exception>
		public DefaultVersjaManager(string workingDirectory = null)
		{
			this.WorkingDirectory	= workingDirectory;

			this.GetProjectFileName();
		}
		#endregion

		#region Public features
		/// <summary>
		/// Tries to read project file in WorkingDirectory and to extract Version.
		/// </summary>
		public void ReadProjectFile()
		{
			this.ReadVersionFile();
			this.Version = ExtractVersion();
		}

		/// <summary>
		/// Tries to read Version from version file in WorkingDirectory.
		/// If not found, creates it.
		/// </summary>
		public void ReadVersionFile()
		{
			try
			{
				this.PatternVersion = VD.Version.Load(Path.Combine(this.WorkingDirectory, VERSION_FILE_NAME));
			}
			catch (Exception)
			{
				this.CreateVersionFile();
			}
		}

		/// <summary>
		/// Creates Version file in WorkingDirectory with default value of Version.
		/// </summary>
		public void CreateVersionFile()
		{
			this.PatternVersion = new VD.Version();
			this.PatternVersion.Save(Path.Combine(this.WorkingDirectory, VERSION_FILE_NAME));
		}

		/// <summary>
		/// Increments BUILD component of Version (Date and Cadence).
		/// If AutoIncrementPatch is true, increments Patch.
		/// Takes all other values from PatternVersion (as those may have been modified by configurator).
		/// </summary>
		public void IncrementVersion()
		{
			// Increment date and cadence.
			if (this.Version.VersionDateTime?.Date == DateTime.Today.Date)
			{
				this.Version.Cadence++;
			}
			else
			{
				this.Version.VersionDateTime = DateTime.Today;
				this.Version.Cadence = 1;
			}

			// all other values have been taken from the pattern version.
		}

		/// <summary>
		/// Serializes Version in version file.
		/// </summary>
		public void WriteVersion()
		{
			
		}

		/// <summary>
		/// Writes version entries into project file.
		/// </summary>
		public void WriteProjectFile()
		{
			
		}
		#endregion

		#region Private Auxiliary
		private void GetProjectFileName()
		{
			if (String.IsNullOrEmpty(this.WorkingDirectory))
			{
				return;
			}

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

		private VD.Version ExtractVersion()
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
		#endregion
	}
}
