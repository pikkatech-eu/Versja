/***********************************************************************************
* File:         VersionControl.cs                                                  *
* Contents:     Class VersionControl                                               *
* Author:       Alexander Konnen (alex@pikkatech.eu)                               *
* Date:         2026-05-16 08:27                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System.ComponentModel;
using Versja.Domain;
using VD = Versja.Domain;

namespace Versja.Gui.Controls
{
	public partial class VersionControl : UserControl
	{
		private static readonly string _gitFolder		= ".git";
		private static readonly string _logsRefsHeads	= "logs\\refs\\heads";


		public VersionControl()
		{
			InitializeComponent();

			this._cxReleaseIdentifier.DataSource = Enum.GetValues<ReleaseIdentifier>();
			this._cxReleaseIdentifier.SelectedItem = ReleaseIdentifier.None;

			this._lblDate.Text	= DateTime.Today.ToString("yyyy-MM-dd");
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public VD.Version Version
		{
			get
			{
				VD.Version version = new VD.Version();

				version.IsReleaseProject	= this._cbIsReleaseProject.Checked;
				version.Major				= (int)this._nudMajor.Value;
				version.Minor				= (int)this._nudMinor.Value;
				version.Patch				= (int)this._nudPatch.Value;
				version.AutoIncrementPatch	= this._cbAutoincrementPatch.Checked;
				version.ReleaseIdentifier	= (ReleaseIdentifier)this._cxReleaseIdentifier.SelectedItem;
				version.RCNumber			= (int)this._nudRCNumber.Value;
				version.RuntimeTarget		= this._txTarget.Text;
				version.GitShaCode			= this._txShaCode.Text;

				return version;
			}

			set
			{
				this._cbIsReleaseProject.Checked		= value.IsReleaseProject;
				this._nudMajor.Value					= value.Major;
				this._nudMinor.Value					= value.Minor;
				this._nudPatch.Value					= value.Patch;
				this._cbAutoincrementPatch.Checked		= value.AutoIncrementPatch;
				this._cxReleaseIdentifier.SelectedItem	= value.ReleaseIdentifier;
				this._nudRCNumber.Value					= value.RCNumber;
				this._txTarget.Text						= value.RuntimeTarget;
				this._txShaCode.Text					= value.GitShaCode;
				this._lblDate.Text						= $"{value.VersionDateTime:yyyy-MM-dd}";
				this._lblCadence.Text					= value.Cadence.ToString();
			}

		}


		private void OnShaCodeSearch(object sender, EventArgs e)
		{
			string gitFolder = this.FindGitDirectory(Directory.GetCurrentDirectory());

			if (gitFolder != null)
			{
				string headsFolderName	= Path.Combine(gitFolder, _gitFolder, _logsRefsHeads);

				string[] heads	= Directory.GetFiles(headsFolderName);

				string head		= heads.Select(h=>new FileInfo(h)).OrderBy(h1 => h1.LastWriteTime).First().FullName;

				using StreamReader reader = new StreamReader(head);

				string line = reader.ReadLine();

				string[] cells = line.Split(' ');

				string sha = cells[1];

				this._txShaCode.Text	= sha;
			}
		}

		private void OnReleaseProjectChanged(object sender, EventArgs e)
		{
			// if unchecked, disable all other controls
		}

		private void OnReleaseIdentifierChanged(object sender, EventArgs e)
		{
			this._nudRCNumber.Enabled = (ReleaseIdentifier)this._cxReleaseIdentifier.SelectedItem == ReleaseIdentifier.ReleaseCandidate;
		}

		public string FindGitDirectory(string initialFolder)
		{
			if (Directory.Exists(Path.Combine(initialFolder, _gitFolder)))
			{
				return initialFolder;
			}
			else
			{
				DirectoryInfo diParent	= Directory.GetParent(initialFolder);

				if (diParent  != null)
				{
					return this.FindGitDirectory(diParent.FullName);
				}
				else
				{
					return null;
				}
			}
		}

	}
}
