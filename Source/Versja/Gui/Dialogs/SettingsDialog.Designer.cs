namespace Versja.Gui.Dialogs
{
	partial class SettingsDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
			this._btOk = new Button();
			this._btCancel = new Button();
			this._pgSettings = new PropertyGrid();
			this.SuspendLayout();
			// 
			// _btOk
			// 
			this._btOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this._btOk.DialogResult = DialogResult.OK;
			this._btOk.Location = new Point(12, 298);
			this._btOk.Margin = new Padding(0);
			this._btOk.Name = "_btOk";
			this._btOk.Size = new Size(80, 32);
			this._btOk.TabIndex = 0;
			this._btOk.Text = "OK";
			this._btOk.UseVisualStyleBackColor = true;
			this._btOk.Click += this.OnOk;
			// 
			// _btCancel
			// 
			this._btCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this._btCancel.DialogResult = DialogResult.Cancel;
			this._btCancel.Location = new Point(108, 298);
			this._btCancel.Margin = new Padding(0);
			this._btCancel.Name = "_btCancel";
			this._btCancel.Size = new Size(80, 32);
			this._btCancel.TabIndex = 1;
			this._btCancel.Text = "Cancel";
			this._btCancel.UseVisualStyleBackColor = true;
			this._btCancel.Click += this.OnCancel;
			// 
			// _pgSettings
			// 
			this._pgSettings.BackColor = SystemColors.Control;
			this._pgSettings.Dock = DockStyle.Top;
			this._pgSettings.Location = new Point(0, 0);
			this._pgSettings.Name = "_pgSettings";
			this._pgSettings.Size = new Size(467, 278);
			this._pgSettings.TabIndex = 2;
			// 
			// SettingsDialog
			// 
			this.AcceptButton = this._btOk;
			this.AutoScaleDimensions = new SizeF(9F, 23F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.CancelButton = this._btCancel;
			this.ClientSize = new Size(467, 338);
			this.Controls.Add(this._pgSettings);
			this.Controls.Add(this._btCancel);
			this.Controls.Add(this._btOk);
			this.Font = new Font("Segoe UI", 10F);
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.Icon = (Icon)resources.GetObject("$this.Icon");
			this.Name = "SettingsDialog";
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _btOk;
		private System.Windows.Forms.Button _btCancel;
		private PropertyGrid _pgSettings;
	}
}