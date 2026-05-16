namespace Versja.Gui.Dialogs
{
	partial class VersionDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionDialog));
			this._btOk = new Button();
			this._btCancel = new Button();
			this._ctrlVersion = new Versja.Gui.Controls.VersionControl();
			this.SuspendLayout();
			// 
			// _btOk
			// 
			this._btOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this._btOk.DialogResult = DialogResult.OK;
			this._btOk.Location = new Point(12, 393);
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
			this._btCancel.Location = new Point(108, 393);
			this._btCancel.Margin = new Padding(0);
			this._btCancel.Name = "_btCancel";
			this._btCancel.Size = new Size(80, 32);
			this._btCancel.TabIndex = 1;
			this._btCancel.Text = "Cancel";
			this._btCancel.UseVisualStyleBackColor = true;
			this._btCancel.Click += this.OnCancel;
			// 
			// _ctrlVersion
			// 
			this._ctrlVersion.Dock = DockStyle.Top;
			this._ctrlVersion.Font = new Font("Consolas", 10F);
			this._ctrlVersion.Location = new Point(0, 0);
			this._ctrlVersion.Margin = new Padding(0, 0, 3, 0);
			this._ctrlVersion.Name = "_ctrlVersion";
			this._ctrlVersion.Size = new Size(655, 324);
			this._ctrlVersion.TabIndex = 2;
			// 
			// VersionDialog
			// 
			this.AcceptButton = this._btOk;
			this.AutoScaleDimensions = new SizeF(9F, 23F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.CancelButton = this._btCancel;
			this.ClientSize = new Size(658, 433);
			this.Controls.Add(this._ctrlVersion);
			this.Controls.Add(this._btCancel);
			this.Controls.Add(this._btOk);
			this.Font = new Font("Segoe UI", 10F);
			this.Icon = (Icon)resources.GetObject("$this.Icon");
			this.Name = "VersionDialog";
			this.Padding = new Padding(0, 0, 3, 0);
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "VersionDialog";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _btOk;
		private System.Windows.Forms.Button _btCancel;
		private Controls.VersionControl _ctrlVersion;
	}
}