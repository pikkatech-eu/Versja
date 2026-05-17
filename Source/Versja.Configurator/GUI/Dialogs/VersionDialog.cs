/***********************************************************************************
* File:         VersionDialog.cs                                                   *
* Contents:     Class VersionDialog                                                *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-16 11:22                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.ComponentModel;

namespace Versja.Domain.GUI.Dialogs
{
	public partial class VersionDialog : Form
	{

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string WorkingDirectory		
		{
			get	=> this._ctrlVersion.WorkingDirectory;
			set => this._ctrlVersion.WorkingDirectory = value;
		}

		public VersionDialog()
		{
			InitializeComponent();
		}

		private void OnOk(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnCancel(object sender, EventArgs e)	{}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Version Version
		{
			get	{return this._ctrlVersion.Version;}

			set
			{
				this._ctrlVersion.Version = value;
			}
		}


	}
}
