/***********************************************************************************
* File:         Settings.cs                                                        *
* Contents:     Class Settings                                                     *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-16 20:23                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Versja.Domain
{
	public class Settings
	{
		#region Constants
		internal static readonly string DEFAULT_SETTINGS_FILE_NAME = "settings.json";
		#endregion

		#region Properties
		[Category("General")]
		[Description("If set to true, will try to open the last project.")]
		public bool AutoLoadLastProject		{get;set;} = false;

		[Category("General")]
		[Description("File name of the last project.")]
		public string LastProjectFileName	{get;set;} = "";

		[Category("General")]
		[Description("If set to true, patches will be auto incremented.")]
		public bool AutoIncrementPatch		{get;set;} = false;
		#endregion

		#region Serialization
		public string ToJson()
		{
			var options = new JsonSerializerOptions {WriteIndented = true};
			return JsonSerializer.Serialize<Settings>(this, options);
		}

		public static Settings FromJson(string json)
		{
			return JsonSerializer.Deserialize<Settings>(json);
		}

		/// <summary>
		/// Saves the settings to a file.
		/// </summary>
		/// <param name="fileName">The name of the file to save under.</param>
		public void Save(string fileName)
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				string json	= this.ToJson();
				writer.Write(json);
			}
		}

		/// <summary>
		/// Loads settings feom a JSON file.
		/// </summary>
		/// <param name="fileName">The name of the file to create from.</param>
		/// <returns>An instance of Settings, if succesful.s</returns>
		public static Settings Load(string fileName)
		{
			using (StreamReader reader= new StreamReader(fileName))
			{
				string json	= reader.ReadToEnd();

				return FromJson(json);
			}
		}

		public void Save()
		{
			string exeFolder = Application.StartupPath;
			string settingsPath	= Path.Combine(exeFolder, DEFAULT_SETTINGS_FILE_NAME);
			this.Save(settingsPath);
		}

		public static Settings Load()
		{
			string exeFolder	= Application.StartupPath;
			string settingsPath	= Path.Combine(exeFolder, DEFAULT_SETTINGS_FILE_NAME);

			if (File.Exists(settingsPath))
			{
				return Load(settingsPath);
			}
			else
			{
				Settings settings = new Settings();
				settings.Save();

				return settings;
			}
		}
		#endregion
	}
}
