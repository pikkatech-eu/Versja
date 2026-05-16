/***********************************************************************************
* File:         IVersionManager.cs                                                 *
* Contents:     Interface IVersionManager                                          *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-15 22:18                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Versja.Domain
{
	public interface IVersionManager
	{
		#region Properties
		string WorkingDirectory		{get;set;}
		string ProjectFileName		{get;set;}
		Version Version				{get;set;}
		Settings Settings			{get;set;}
		#endregion

		void GetProjectFileName();
		void CreateVersion();
		void LoadVersion();
		void SaveVersion();
		void IncrementVersion();
		void ExtractVersion();
		void InjectVersion();

		void LoadSettings();
		void SaveSettings();
		void EditSettings();
	}
}
