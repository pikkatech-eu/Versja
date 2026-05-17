/***********************************************************************************
* File:         IVersjaManager.cs                                                  *
* Contents:     Interface IVersjaManager                                           *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-17 13:39                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using VD = Versja.Domain;

namespace Versja.Application
{
	public interface IVersjaManager
	{
		#region Properties
		/// <summary>
		/// Working project directory (contains .csproj file).
		/// </summary>
		string		WorkingDirectory	{get;set;}

		/// <summary>
		/// Name of the project file.
		/// </summary>
		string		ProjectFileName		{get;set;}

		/// <summary>
		/// Value of Version.
		/// </summary>
		VD.Version	Version				{get;set;}
		#endregion

		/// <summary>
		/// Tries to read ProjectFileName in WorkingDirectory.
		/// Raises exception if not found.
		/// </summary>
		void ReadProjectFile();

		/// <summary>
		/// Tries to read Version from version file in WorkingDirectory.
		/// If not found, creates it.
		/// </summary>
		void ReadVersionFile();

		/// <summary>
		/// Creates Version file in WorkingDirectory with default value of Version.
		/// </summary>
		void CreateVersionFile();

		/// <summary>
		/// Increments BUILD component of Version (Date and Cadence).
		/// If AutoIncrementPatch is true, increments Patch.
		/// </summary>
		void IncrementVersion();

		/// <summary>
		/// Serializes Version in version file.
		/// </summary>
		void WriteVersion();

		/// <summary>
		/// Writes version entries into project file.
		/// </summary>
		void WriteProjectFile();
	}
}
