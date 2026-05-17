/***********************************************************************************
* File:         Version.cs                                                         *
* Contents:     Class Version                                                      *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-15 18:38                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;

namespace Versja.Domain
{
	/// <summary>
	/// Describes a version, a pragmatic view.
	/// </summary>
	public class Version
	{
		private static readonly Regex RX_VERSION = new Regex(@"^(?<major>\d+)\.(?<minor>\d+)\.(?<patch>\d+)(?:-?(?<release>[A-Za-z0-9]*)(?:\.(?<date>\d{8})(?:\.(?<cadence>\d+))?)?)?(?:\+(?<runtime>[-A-Za-z0-9.]+))?$");
		private static readonly Regex RX_RCNUMBER	= new Regex(@"\d+");

		#region Properties
		/// <summary>
		/// Date of the version.
		/// </summary>
		public DateTime?			VersionDateTime		{get;set;} = DateTime.Now;

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
		/// If set to true, will auto increment patch.
		/// </summary>
		public bool					AutoIncrementPatch	{get;set;} = false;

		/// <summary>
		/// Indicates if the project should be mentioned in a future solution-centric versioning project.
		/// </summary>
		public bool					IsReleaseProject	{get;set;} = true;
		#endregion

		#region Construction
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Version()	{}

		/// <summary>
		/// Copying constructor.
		/// </summary>
		/// <param name="version"></param>
		public Version(Version version)
		{
			this.Major				= version.Major;
			this.Minor				= version.Minor;
			this.Patch				= version.Patch;
			this.Cadence			= version.Cadence;			
			this.ReleaseIdentifier	= version.ReleaseIdentifier;	
			this.RCNumber			= version.RCNumber;			
			this.RuntimeTarget		= version.RuntimeTarget;		
			this.GitShaCode			= version.GitShaCode;			
			this.AutoIncrementPatch	= version.AutoIncrementPatch;
			this.IsReleaseProject	= version.IsReleaseProject;
		}
		#endregion

		/// <summary>
		/// MAJOR.MINOR.PATCH[-RELEASE_IDENTIFIER][+BUILD_METADATA]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (!this.IsReleaseProject)
			{
				return null;
			}

			string result = $"{this.Major}.{this.Minor}.{this.Patch}";

			string identifier = "";

			switch (this.ReleaseIdentifier)
			{
				case ReleaseIdentifier.Alpha:
				case ReleaseIdentifier.Beta:
				case ReleaseIdentifier.Patch:
				case ReleaseIdentifier.Preview:
				case ReleaseIdentifier.Unstable:
					identifier = this.ReleaseIdentifier.ToString().ToLower();
					break;

				case ReleaseIdentifier.ReleaseCandidate:
					identifier = $"rc{this.RCNumber}";
					break;
				
				case ReleaseIdentifier.Development:
					identifier = "dev";
					break;

				case ReleaseIdentifier.Snapshot:
				case ReleaseIdentifier.None:
				default:
					break;
			}


			// 1.2.0-beta.20260515.1
			if (!System.String.IsNullOrEmpty(identifier))
			{
				result += $"-{identifier}";
			}

			string datetime = $"{this.VersionDateTime:yyyyMMdd}.{this.Cadence}";

			result += $".{datetime}";

			if (!System.String.IsNullOrEmpty(this.RuntimeTarget))
			{
				result += $"+{this.RuntimeTarget}";
			}

			return result;
		}

		public static Version Parse(string source)
		{
			Version version = new Version();

			Match match	= RX_VERSION.Match(source);

			string major	= match.Groups["major"].Value;
			string minor	= match.Groups["minor"].Value;
			string patch	= match.Groups["patch"].Value;
			string release	= match.Groups["release"].Value;
			string date		= match.Groups["date"].Value;
			string cadence	= match.Groups["cadence"].Value;
			string runtime	= match.Groups["runtime"].Value;

			version.Major	= Int32.Parse(major);
			version.Minor	= Int32.Parse(minor);
			version.Patch	= Int32.Parse(patch);

			version.ReleaseIdentifier	= GetReleaseIdentifier(release);

			if (version.ReleaseIdentifier == ReleaseIdentifier.ReleaseCandidate)
			{
				version.RCNumber	= GetReleaseCandidateNumber(release);
			}

			version.RuntimeTarget	= runtime;

			try
			{
				version.Cadence	= Int32.Parse(cadence);
			}
			catch (Exception)	{}

			try
			{
				version.VersionDateTime	= DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
			}
			catch (Exception)	{}

			return version;
		}

		private static int GetReleaseCandidateNumber(string release)
		{
			Match match			= RX_RCNUMBER.Match(release);

			try
			{
				return Int32.Parse(match.Value);
			}
			catch (Exception)
			{
				return 1;
			}
		}

		#region Json & I/O
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
		#endregion

		private static ReleaseIdentifier GetReleaseIdentifier(string source)
		{
			if (String.IsNullOrEmpty(source))
			{
				return ReleaseIdentifier.None;
			}

			if (source.ToLower().StartsWith("rc"))
			{
				return ReleaseIdentifier.ReleaseCandidate;
			}

			switch (source.ToLower())
			{
				case "alpha":
				case "beta":
				case "patch":
				case "preview":
				case "unstable":
					source = source.Substring(0, 1).ToUpper() + source.Substring(1);
					return Enum.Parse<ReleaseIdentifier>(source);

				case "dev":
					return ReleaseIdentifier.Development;

				default:
					return ReleaseIdentifier.None;
			}
		}
	}
}
