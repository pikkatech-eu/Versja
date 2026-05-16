using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Versja.Domain;

namespace Versja.Gui.Dialogs
{
	public partial class SettingsDialog : Form
	{
		public SettingsDialog()
		{
			InitializeComponent();
		}

		private void OnOk(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OnCancel(object sender, EventArgs e)
		{

		}


		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Settings Settings
		{
			get
			{
				return this._pgSettings.SelectedObject as Settings;
			}


			set
			{
				this._pgSettings.SelectedObject = value;
			}
		}
	}
}
