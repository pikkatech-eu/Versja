using Versja.Domain;
using Versja.Gui.Dialogs;

namespace Versja
{
	public partial class VersjaForm : Form
	{

		private DefaultVersionManager _manager = new DefaultVersionManager();

		public VersjaForm()
		{
			InitializeComponent();

			try
			{
				this._manager.LoadSettings();

				if (this._manager.Settings.AutoLoadLastProject)
				{
					this._manager.ProjectFileName = this._manager.Settings.LastProjectFileName;
					this.UpdateProject();
				}
			}
			catch (Exception)
			{
			}
		}

		private void OnProjectLoad(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Project files (*.csproj)|*.csproj";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				this._manager.ProjectFileName = dialog.FileName;
				this._manager.Settings.LastProjectFileName = this._manager.ProjectFileName;
				this._manager.SaveSettings();
				this.UpdateProject();
			}
		}

		private void UpdateProject()
		{
			this._manager.WorkingDirectory = Directory.GetParent(this._manager.ProjectFileName).FullName;
			this._manager.ExtractVersion();

			if (this._manager.Settings.AutoIncrementPatch)
			{
				this._manager.Version.AutoIncrementPatch = true;
			}

			this._ctrlVersion.Version = this._manager.Version;

			this._lblInfo.Text = new FileInfo(this._manager.ProjectFileName).Name;
		}

		private void OnProjectSave(object sender, EventArgs e)
		{

			this._manager.Version = this._ctrlVersion.Version;
			this._manager.IncrementVersion();
			this._ctrlVersion.Version = this._manager.Version;
			this._manager.SaveVersion();

			this._manager.InjectVersion();
		}

		private void OnProjectQuit(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnToolsSettings(object sender, EventArgs e)
		{
			SettingsDialog dialog	= new SettingsDialog();
			dialog.Settings			= this._manager.Settings;

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				this._manager.Settings = dialog.Settings;
				this._manager.SaveSettings();
			}
		}
	}
}
