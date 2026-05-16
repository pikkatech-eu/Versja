namespace Versja
{
	partial class VersjaForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new MenuStrip();
			this.projectToolStripMenuItem = new ToolStripMenuItem();
			this.loadToolStripMenuItem = new ToolStripMenuItem();
			this.editToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.quitToolStripMenuItem = new ToolStripMenuItem();
			this.statusStrip1 = new StatusStrip();
			this._lblInfo = new ToolStripStatusLabel();
			this.toolStrip1 = new ToolStrip();
			this._ctrlVersion = new Versja.Gui.Controls.VersionControl();
			this.toolsToolStripMenuItem = new ToolStripMenuItem();
			this.settingsToolStripMenuItem = new ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new Size(20, 20);
			this.menuStrip1.Items.AddRange(new ToolStripItem[] { this.projectToolStripMenuItem, this.toolsToolStripMenuItem });
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size(598, 29);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.loadToolStripMenuItem, this.editToolStripMenuItem, this.toolStripSeparator1, this.quitToolStripMenuItem });
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new Size(72, 25);
			this.projectToolStripMenuItem.Text = "&Project";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new Size(128, 26);
			this.loadToolStripMenuItem.Text = "&Load";
			this.loadToolStripMenuItem.Click += this.OnProjectLoad;
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new Size(128, 26);
			this.editToolStripMenuItem.Text = "&Save";
			this.editToolStripMenuItem.Click += this.OnProjectSave;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(125, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new Size(128, 26);
			this.quitToolStripMenuItem.Text = "&Quit";
			this.quitToolStripMenuItem.Click += this.OnProjectQuit;
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new Size(20, 20);
			this.statusStrip1.Items.AddRange(new ToolStripItem[] { this._lblInfo });
			this.statusStrip1.Location = new Point(0, 429);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(598, 31);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// _lblInfo
			// 
			this._lblInfo.Font = new Font("Segoe UI", 11F);
			this._lblInfo.Name = "_lblInfo";
			this._lblInfo.Size = new Size(71, 25);
			this._lblInfo.Text = "ready...";
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new Size(20, 20);
			this.toolStrip1.Location = new Point(0, 29);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new Size(598, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// _ctrlVersion
			// 
			this._ctrlVersion.Dock = DockStyle.Top;
			this._ctrlVersion.Font = new Font("Consolas", 10F);
			this._ctrlVersion.Location = new Point(0, 54);
			this._ctrlVersion.Margin = new Padding(0);
			this._ctrlVersion.Name = "_ctrlVersion";
			this._ctrlVersion.Size = new Size(598, 321);
			this._ctrlVersion.TabIndex = 3;
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.settingsToolStripMenuItem });
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new Size(59, 25);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new Size(224, 26);
			this.settingsToolStripMenuItem.Text = "&Settings";
			this.settingsToolStripMenuItem.Click += this.OnToolsSettings;
			// 
			// VersjaForm
			// 
			this.AutoScaleDimensions = new SizeF(11F, 28F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(598, 460);
			this.Controls.Add(this._ctrlVersion);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new Font("Segoe UI", 12F);
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new Padding(4);
			this.Name = "VersjaForm";
			this.Text = "Versja 1.0.0";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem projectToolStripMenuItem;
		private ToolStripMenuItem loadToolStripMenuItem;
		private ToolStripMenuItem editToolStripMenuItem;
		private StatusStrip statusStrip1;
		private ToolStrip toolStrip1;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem quitToolStripMenuItem;
		private Gui.Controls.VersionControl _ctrlVersion;
		private ToolStripStatusLabel _lblInfo;
		private ToolStripMenuItem toolsToolStripMenuItem;
		private ToolStripMenuItem settingsToolStripMenuItem;
	}
}
