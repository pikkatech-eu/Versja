using Versja.Domain;

namespace Versja
{
	public partial class VersjaForm : Form
	{

		private DefaultVersionManager _manager = new DefaultVersionManager();

		public VersjaForm()
		{
			InitializeComponent();
		}

		private void OnProjectLoad(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Project files (*.csproj)|*.csproj";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				this._manager.ProjectFileName	= dialog.FileName;
				this._manager.WorkingDirectory	= Directory.GetParent(this._manager.ProjectFileName).FullName;
				this._manager.ExtractVersion();
				this._ctrlVersion.Version		= this._manager.Version;
			}
		}

		private void OnProjectSave(object sender, EventArgs e)
		{

			this._manager.Version		= this._ctrlVersion.Version;
			this._manager.IncrementVersion();
			this._ctrlVersion.Version	= this._manager.Version;
			this._manager.SaveVersion();

			this._manager.InjectVersion();
		}

		private void OnProjectQuit(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
