/***********************************************************************************
* File:         VersionInfoDialog.cs                                               *
* Contents:     Class VersionInfoDialog                                            *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-19 20:32                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.ComponentModel;

namespace Versja
{
	public partial class VersionInfoDialog : Form
	{
		private static readonly string[] PRERELEASE_IDENTIFIERS =	["build", "alpha", "beta", "rc", "preview", "nightly"];
		private static readonly string[] RUNTIME_TARGETS		= 
																	[
																		"net6.0",
																		"net6.0-android",
																		"net6.0-ios",
																		"net8.0", 		
																		"net8.0-android",
																		"net8.0-ios",
																		"net8.0-windows",
																		"net9.0",	
																		"net9.0-android",
																		"net9.0-ios",
																		"net9.0-windows",
																		"net10.0",
																		"net10.0-android",
																		"net10.0-ios",
																		"net10.0-windows"
																	];

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string WorkingDirectory			{get;set;}

		public VersionInfoDialog()
		{
			InitializeComponent();

			this._cxPrereleaseId.DataSource		= PRERELEASE_IDENTIFIERS;
			this._cxPrereleaseId.SelectedIndex	= 0;

			this._cxRuntimeTarget.DataSource	= RUNTIME_TARGETS;
			this._cxRuntimeTarget.SelectedIndex	= 0;
		}

		private void OnOk(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnCancel(object sender, EventArgs e)
		{

		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public VersionInfo VersionInfo
		{
			get
			{
				VersionInfo vi		= new VersionInfo();

				vi.Major			= (int)this._nudMajor.Value;
				vi.Minor			= (int)this._nudMinor.Value;
				vi.Build			= (int)this._nudBuild.Value;
				vi.Revision			= (int)this._nudRevision.Value;
				vi.PrereleaseId		= this._cxPrereleaseId.SelectedItem.ToString();
				vi.Date				= this._dtpDate.Value;
				vi.Cadence			= (int)this._nudCadence.Value;
				vi.RuntimeTarget	= this._cxRuntimeTarget.SelectedItem.ToString();

				return vi;
			}

			set
			{
				this._nudMajor.Value				= value.Major;
				this._nudMinor.Value				= value.Minor;
				this._nudBuild.Value				= value.Build;
				this._nudRevision.Value				= value.Revision;

				this._cxPrereleaseId.SelectedItem	= value.PrereleaseId;
				this._dtpDate.Value					= value.Date??DateTime.Today;
				this._nudCadence.Value				= (int)value.Cadence;
				this._cxRuntimeTarget.SelectedItem	= value.RuntimeTarget;
			}
		}
	}
}
