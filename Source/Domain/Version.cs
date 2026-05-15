/***********************************************************************************
* File:         Version.cs                                                         *
* Contents:     Class Version                                                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-15 18:38                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Versja.Domain
{
	/// <summary>
	/// Describes a version, a pragmatic view.
	/// </summary>
	public class Version
	{
		#region Properties
		/// <summary>
		/// Date of the version.
		/// </summary>
		public DateTime?			Date				{get;set;} = null;

		/// <summary>
		/// Major number (breaking changes).
		/// </summary>
		public int					Major				{get;set;} = 1;

		/// <summary>
		/// Minor number (new features, backward-compatible).
		/// </summary>
		public int					Minor				{get;set;} = 0;

		/// <summary>
		/// Patch number (bug fixes).
		/// </summary>
		public int					Patch				{get;set;} = 0;

		/// <summary>
		/// Cadence to add after patch if made on the same date.
		/// </summary>
		public int					Cadence				{get;set;} = 1;

		/// <summary>
		/// Optional (pre)release identifier.
		/// </summary>
		public ReleaseIdentifier	ReleaseIdentifier	{get;set;} = ReleaseIdentifier.None;

		/// <summary>
		/// Release candidate number (e.g. "rc1", "rc2", etc.)
		/// </summary>
		public int					RCNumber			{get;set;} = 1;

		/// <summary>
		/// E.g. "net6.0.
		/// </summary>
		public string				RuntimeTarget		{get;set;} = null;

		/// <summary>
		/// Optional Git SHA-1 code.
		/// </summary>
		public string				GitShaCode			{get;set;} = null;

		/// <summary>
		/// Indicates if the project should be mentioned in a future solution-centric versioning project.
		/// </summary>
		public bool					IsReleaseProject	{get;set;} = true;
		#endregion

		public override string ToString()
		{
			return base.ToString();
		}

		public static Version Parse(string source)
		{
			throw new NotImplementedException();
		}


		public static bool TryParse(string source, out Version version)
		{
			try
			{
				version = Parse(source);
				return true;
			}
			catch (Exception)
			{
				version = null;
				return false;
			}
		}

		public string ToJson()
		{
			JsonSerializerOptions options = new JsonSerializerOptions{WriteIndented=true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)};

			return JsonSerializer.Serialize(this, options);
		}

		public static Version FromJson(string json)
		{
			return JsonSerializer.Deserialize<Version>(json);
		}

		public void Save(string fileName)
		{
			using StreamWriter writer = new StreamWriter(fileName);
			writer.Write(this.ToJson());
		}

		public static Version Load(string fileName)
		{
			using StreamReader reader = new StreamReader(fileName);

			string json = reader.ReadToEnd();

			return FromJson(json);
		}
	}
}
