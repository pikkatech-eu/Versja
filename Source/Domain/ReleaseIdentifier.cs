/***********************************************************************************
* File:         ReleaseIdentifier.cs                                               *
* Contents:     Enum ReleaseIdentifier                                             *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-15 18:38                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.Text.Json.Serialization;

namespace Versja.Domain
{
	/// <summary>
	/// https://semver.org/
	/// </summary>
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum ReleaseIdentifier
	{
		None,
		Alpha,				// (e.g., 1.0.0-alpha)
		Beta,				// (e.g., 1.0.0-beta)
		ReleaseCandidate,	// or RC (e.g., 1.0.0-rc.1)
		Snapshot,			// (often used in Maven/Java)
		Preview,
		Development,		// Dev
		Unstable,
		Patch				// (when denoting a bugfix version)
	}
}
