/***********************************************************************************
* File:         VersionInfo.cs                                                     *
* Contents:     Class VersionInfo                                                  *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-19 20:03                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

namespace Versja
{
	using System;
	using System.Globalization;
	using System.Text;
	using System.Text.Encodings.Web;
	using System.Text.Json;
	using System.Text.RegularExpressions;
	using System.Text.Unicode;

	public class VersionInfo
	{
		#region Properties
		public int			Major			{get;set;} = 1;
		public int			Minor			{get;set;} = 0;
		public int			Build			{get;set;} = 0;
		public int			Revision		{get;set;} = 0;

		public string?		PrereleaseId	{get;set;} = "build";
		public DateTime?	Date			{get;set;} = DateTime.Today;
		public int?			Cadence			{get;set;} = 0;
		public string?		RuntimeTarget	{get;set;} = null;
		#endregion

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.Append($"{Major}.{Minor}.{Build}.{Revision}");

			if (!string.IsNullOrWhiteSpace(PrereleaseId))
			{
				sb.Append('-');
				sb.Append(PrereleaseId);

				if (Date.HasValue)
				{
					sb.Append('.');
					sb.Append(Date.Value.ToString("yyyyMMdd"));

					if (Cadence.HasValue)
					{
						sb.Append('.');
						sb.Append(Cadence.Value);
					}
				}
			}

			if (!string.IsNullOrWhiteSpace(RuntimeTarget))
			{
				sb.Append('+');
				sb.Append(RuntimeTarget);
			}

			return sb.ToString();
		}

		public static VersionInfo Parse(string source)
		{
			var pattern =
				@"^
            (?<major>\d+)
            (?:\.(?<minor>\d+))?
            (?:\.(?<build>\d+))?
            (?:\.(?<revision>\d+))?

            (?:-
                (?<pre>[A-Za-z0-9\-]+)

                (?:\.
                    (?<date>\d{8})

                    (?:\.
                        (?<cadence>\d+)
                    )?
                )?
            )?

            (?:\+
                (?<runtime>[A-Za-z0-9\.\-]+)
            )?
            $";

			var match = Regex.Match(source, pattern, RegexOptions.IgnorePatternWhitespace);

			if (!match.Success)
			{
				throw new FormatException("Invalid version string.");
			}

			var result = new VersionInfo();

			result.Major = ParseInt(match, "major", 1);
			result.Minor = ParseInt(match, "minor", 0);
			result.Build = ParseInt(match, "build", 0);
			result.Revision = ParseInt(match, "revision", 0);

			result.PrereleaseId = Get(match, "pre");

			var dateText = Get(match, "date");

			if (dateText != null)
			{
				result.Date = DateTime.ParseExact(dateText, "yyyyMMdd",	CultureInfo.InvariantCulture);
			}

			var cadenceText = Get(match, "cadence");

			if (cadenceText != null)
			{
				result.Cadence = int.Parse(cadenceText);
			}

			result.RuntimeTarget = Get(match, "runtime");

			return result;
		}

		public static bool TryParse(string source, out VersionInfo vi)
		{
			try
			{
				vi = Parse(source);
				return true;
			}
			catch (Exception)
			{
				vi = null;
				return false;
			}
		}

		#region JSON & I/O
		public string ToJson()
		{
			JsonSerializerOptions options = new JsonSerializerOptions{WriteIndented=true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)};

			return JsonSerializer.Serialize(this, options);
		}

		public static VersionInfo FromJson(string json)
		{
			return JsonSerializer.Deserialize<VersionInfo>(json);
		}

		public void Save(string fileName)
		{
			using StreamWriter writer = new StreamWriter(fileName);
			writer.Write(this.ToJson());
		}

		public static VersionInfo Load(string fileName)
		{
			using StreamReader reader = new StreamReader(fileName);

			string json = reader.ReadToEnd();

			return FromJson(json);
		}
		#endregion

		#region Private static auxiliary
		private static int ParseInt(Match match, string group, int defaultValue)
		{
			var s = Get(match, group);

			return s == null ? defaultValue : int.Parse(s);
		}

		private static string? Get(Match match, string group)
		{
			var g = match.Groups[group];

			return g.Success ? g.Value : null;
		}
		#endregion
	}
}
