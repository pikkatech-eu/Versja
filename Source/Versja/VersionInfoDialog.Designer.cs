namespace Versja
{
	partial class VersionInfoDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionInfoDialog));
			this._btOk = new Button();
			this._btCancel = new Button();
			this._tlpVersionInfo = new TableLayoutPanel();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this._nudMajor = new NumericUpDown();
			this._nudMinor = new NumericUpDown();
			this._nudBuild = new NumericUpDown();
			this._nudRevision = new NumericUpDown();
			this._cxPrereleaseId = new ComboBox();
			this._dtpDate = new DateTimePicker();
			this._nudCadence = new NumericUpDown();
			this._cxRuntimeTarget = new ComboBox();
			this._tlpVersionInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this._nudMajor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._nudMinor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._nudBuild).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._nudRevision).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._nudCadence).BeginInit();
			this.SuspendLayout();
			// 
			// _btOk
			// 
			this._btOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this._btOk.DialogResult = DialogResult.OK;
			this._btOk.Location = new Point(12, 263);
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
			this._btCancel.Location = new Point(108, 263);
			this._btCancel.Margin = new Padding(0);
			this._btCancel.Name = "_btCancel";
			this._btCancel.Size = new Size(80, 32);
			this._btCancel.TabIndex = 1;
			this._btCancel.Text = "Cancel";
			this._btCancel.UseVisualStyleBackColor = true;
			this._btCancel.Click += this.OnCancel;
			// 
			// _tlpVersionInfo
			// 
			this._tlpVersionInfo.ColumnCount = 3;
			this._tlpVersionInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
			this._tlpVersionInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			this._tlpVersionInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			this._tlpVersionInfo.Controls.Add(this.label1, 0, 0);
			this._tlpVersionInfo.Controls.Add(this.label2, 0, 1);
			this._tlpVersionInfo.Controls.Add(this.label3, 0, 2);
			this._tlpVersionInfo.Controls.Add(this.label4, 0, 3);
			this._tlpVersionInfo.Controls.Add(this.label5, 0, 4);
			this._tlpVersionInfo.Controls.Add(this.label6, 0, 5);
			this._tlpVersionInfo.Controls.Add(this.label7, 0, 6);
			this._tlpVersionInfo.Controls.Add(this.label8, 0, 7);
			this._tlpVersionInfo.Controls.Add(this._nudMajor, 1, 0);
			this._tlpVersionInfo.Controls.Add(this._nudMinor, 1, 1);
			this._tlpVersionInfo.Controls.Add(this._nudBuild, 1, 2);
			this._tlpVersionInfo.Controls.Add(this._nudRevision, 1, 3);
			this._tlpVersionInfo.Controls.Add(this._cxPrereleaseId, 1, 4);
			this._tlpVersionInfo.Controls.Add(this._dtpDate, 1, 5);
			this._tlpVersionInfo.Controls.Add(this._nudCadence, 1, 6);
			this._tlpVersionInfo.Controls.Add(this._cxRuntimeTarget, 1, 7);
			this._tlpVersionInfo.Dock = DockStyle.Top;
			this._tlpVersionInfo.Location = new Point(0, 0);
			this._tlpVersionInfo.Name = "_tlpVersionInfo";
			this._tlpVersionInfo.RowCount = 9;
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersionInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			this._tlpVersionInfo.Size = new Size(305, 245);
			this._tlpVersionInfo.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = DockStyle.Fill;
			this.label1.Location = new Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(121, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Major";
			this.label1.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = DockStyle.Fill;
			this.label2.Location = new Point(3, 28);
			this.label2.Name = "label2";
			this.label2.Size = new Size(121, 28);
			this.label2.TabIndex = 1;
			this.label2.Text = "Minor";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = DockStyle.Fill;
			this.label3.Location = new Point(3, 56);
			this.label3.Name = "label3";
			this.label3.Size = new Size(121, 28);
			this.label3.TabIndex = 2;
			this.label3.Text = "Build";
			this.label3.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = DockStyle.Fill;
			this.label4.Location = new Point(3, 84);
			this.label4.Name = "label4";
			this.label4.Size = new Size(121, 28);
			this.label4.TabIndex = 3;
			this.label4.Text = "Revision";
			this.label4.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = DockStyle.Fill;
			this.label5.Location = new Point(3, 112);
			this.label5.Name = "label5";
			this.label5.Size = new Size(121, 32);
			this.label5.TabIndex = 4;
			this.label5.Text = "Prerelease ID";
			this.label5.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = DockStyle.Fill;
			this.label6.Location = new Point(3, 144);
			this.label6.Name = "label6";
			this.label6.Size = new Size(121, 32);
			this.label6.TabIndex = 5;
			this.label6.Text = "Date";
			this.label6.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = DockStyle.Fill;
			this.label7.Location = new Point(3, 176);
			this.label7.Name = "label7";
			this.label7.Size = new Size(121, 28);
			this.label7.TabIndex = 6;
			this.label7.Text = "Cadence";
			this.label7.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Dock = DockStyle.Fill;
			this.label8.Location = new Point(3, 204);
			this.label8.Name = "label8";
			this.label8.Size = new Size(121, 28);
			this.label8.TabIndex = 7;
			this.label8.Text = "RuntimeTarget";
			this.label8.TextAlign = ContentAlignment.MiddleRight;
			// 
			// _nudMajor
			// 
			this._nudMajor.Location = new Point(130, 3);
			this._nudMajor.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this._nudMajor.Name = "_nudMajor";
			this._nudMajor.Size = new Size(150, 30);
			this._nudMajor.TabIndex = 8;
			this._nudMajor.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// _nudMinor
			// 
			this._nudMinor.Location = new Point(130, 31);
			this._nudMinor.Name = "_nudMinor";
			this._nudMinor.Size = new Size(150, 30);
			this._nudMinor.TabIndex = 9;
			// 
			// _nudBuild
			// 
			this._nudBuild.Location = new Point(130, 59);
			this._nudBuild.Name = "_nudBuild";
			this._nudBuild.Size = new Size(150, 30);
			this._nudBuild.TabIndex = 10;
			// 
			// _nudRevision
			// 
			this._nudRevision.Location = new Point(130, 87);
			this._nudRevision.Name = "_nudRevision";
			this._nudRevision.Size = new Size(150, 30);
			this._nudRevision.TabIndex = 11;
			// 
			// _cxPrereleaseId
			// 
			this._cxPrereleaseId.FormattingEnabled = true;
			this._cxPrereleaseId.Location = new Point(130, 115);
			this._cxPrereleaseId.Name = "_cxPrereleaseId";
			this._cxPrereleaseId.Size = new Size(151, 31);
			this._cxPrereleaseId.TabIndex = 12;
			// 
			// _dtpDate
			// 
			this._dtpDate.Location = new Point(130, 147);
			this._dtpDate.Name = "_dtpDate";
			this._dtpDate.Size = new Size(152, 30);
			this._dtpDate.TabIndex = 13;
			// 
			// _nudCadence
			// 
			this._nudCadence.Location = new Point(130, 179);
			this._nudCadence.Name = "_nudCadence";
			this._nudCadence.Size = new Size(150, 30);
			this._nudCadence.TabIndex = 14;
			// 
			// _cxRuntimeTarget
			// 
			this._cxRuntimeTarget.FormattingEnabled = true;
			this._cxRuntimeTarget.Location = new Point(130, 207);
			this._cxRuntimeTarget.Name = "_cxRuntimeTarget";
			this._cxRuntimeTarget.Size = new Size(151, 31);
			this._cxRuntimeTarget.TabIndex = 15;
			// 
			// VersionInfoDialog
			// 
			this.AcceptButton = this._btOk;
			this.AutoScaleDimensions = new SizeF(9F, 23F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.CancelButton = this._btCancel;
			this.ClientSize = new Size(305, 303);
			this.Controls.Add(this._tlpVersionInfo);
			this.Controls.Add(this._btCancel);
			this.Controls.Add(this._btOk);
			this.Font = new Font("Segoe UI", 10F);
			this.Icon = (Icon)resources.GetObject("$this.Icon");
			this.Name = "VersionInfoDialog";
			this.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Version Info";
			this._tlpVersionInfo.ResumeLayout(false);
			this._tlpVersionInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this._nudMajor).EndInit();
			((System.ComponentModel.ISupportInitialize)this._nudMinor).EndInit();
			((System.ComponentModel.ISupportInitialize)this._nudBuild).EndInit();
			((System.ComponentModel.ISupportInitialize)this._nudRevision).EndInit();
			((System.ComponentModel.ISupportInitialize)this._nudCadence).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _btOk;
		private System.Windows.Forms.Button _btCancel;
		private TableLayoutPanel _tlpVersionInfo;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label8;
		private NumericUpDown _nudMajor;
		private NumericUpDown _nudMinor;
		private NumericUpDown _nudBuild;
		private NumericUpDown _nudRevision;
		private ComboBox _cxPrereleaseId;
		private DateTimePicker _dtpDate;
		private NumericUpDown _nudCadence;
		private ComboBox _cxRuntimeTarget;
	}
}