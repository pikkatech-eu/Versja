namespace Versja.Gui.Controls
{
	partial class VersionControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._tlpVersion = new TableLayoutPanel();
			this._cbIsReleaseProject = new CheckBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this._cbAutoincrementPatch = new CheckBox();
			this._cxReleaseIdentifier = new ComboBox();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this._nudMajor = new NumericUpDown();
			this._nudMinor = new NumericUpDown();
			this._nudPatch = new NumericUpDown();
			this._nudRCNumber = new NumericUpDown();
			this._txTarget = new TextBox();
			this._txShaCode = new TextBox();
			this._btShaCode = new Button();
			this.label8 = new Label();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this._lblDate = new Label();
			this._lblCadence = new Label();
			this._tlpVersion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this._nudMajor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._nudMinor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._nudPatch).BeginInit();
			((System.ComponentModel.ISupportInitialize)this._nudRCNumber).BeginInit();
			this.SuspendLayout();
			// 
			// _tlpVersion
			// 
			this._tlpVersion.ColumnCount = 4;
			this._tlpVersion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
			this._tlpVersion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.05466F));
			this._tlpVersion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.94534F));
			this._tlpVersion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
			this._tlpVersion.Controls.Add(this._cbIsReleaseProject, 1, 0);
			this._tlpVersion.Controls.Add(this.label1, 0, 1);
			this._tlpVersion.Controls.Add(this.label2, 0, 2);
			this._tlpVersion.Controls.Add(this.label3, 0, 3);
			this._tlpVersion.Controls.Add(this._cbAutoincrementPatch, 1, 4);
			this._tlpVersion.Controls.Add(this._cxReleaseIdentifier, 1, 7);
			this._tlpVersion.Controls.Add(this.label4, 0, 7);
			this._tlpVersion.Controls.Add(this.label5, 0, 8);
			this._tlpVersion.Controls.Add(this.label6, 0, 9);
			this._tlpVersion.Controls.Add(this.label7, 0, 10);
			this._tlpVersion.Controls.Add(this._nudMajor, 1, 1);
			this._tlpVersion.Controls.Add(this._nudMinor, 1, 2);
			this._tlpVersion.Controls.Add(this._nudPatch, 1, 3);
			this._tlpVersion.Controls.Add(this._nudRCNumber, 1, 8);
			this._tlpVersion.Controls.Add(this._txTarget, 1, 9);
			this._tlpVersion.Controls.Add(this._txShaCode, 1, 10);
			this._tlpVersion.Controls.Add(this._btShaCode, 3, 10);
			this._tlpVersion.Controls.Add(this.label8, 2, 1);
			this._tlpVersion.Controls.Add(this.label9, 2, 2);
			this._tlpVersion.Controls.Add(this.label10, 2, 3);
			this._tlpVersion.Controls.Add(this.label11, 0, 5);
			this._tlpVersion.Controls.Add(this.label12, 0, 6);
			this._tlpVersion.Controls.Add(this._lblDate, 1, 5);
			this._tlpVersion.Controls.Add(this._lblCadence, 1, 6);
			this._tlpVersion.Dock = DockStyle.Fill;
			this._tlpVersion.Location = new Point(0, 0);
			this._tlpVersion.Name = "_tlpVersion";
			this._tlpVersion.RowCount = 12;
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
			this._tlpVersion.RowStyles.Add(new RowStyle());
			this._tlpVersion.Size = new Size(467, 462);
			this._tlpVersion.TabIndex = 0;
			// 
			// _cbIsReleaseProject
			// 
			this._cbIsReleaseProject.AutoSize = true;
			this._cbIsReleaseProject.Checked = true;
			this._cbIsReleaseProject.CheckState = CheckState.Checked;
			this._tlpVersion.SetColumnSpan(this._cbIsReleaseProject, 2);
			this._cbIsReleaseProject.Dock = DockStyle.Fill;
			this._cbIsReleaseProject.Location = new Point(111, 3);
			this._cbIsReleaseProject.Name = "_cbIsReleaseProject";
			this._cbIsReleaseProject.Size = new Size(305, 22);
			this._cbIsReleaseProject.TabIndex = 0;
			this._cbIsReleaseProject.Text = "Release Project?";
			this._cbIsReleaseProject.UseVisualStyleBackColor = true;
			this._cbIsReleaseProject.CheckedChanged += this.OnReleaseProjectChanged;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = DockStyle.Fill;
			this.label1.Location = new Point(3, 28);
			this.label1.Name = "label1";
			this.label1.Size = new Size(102, 28);
			this.label1.TabIndex = 1;
			this.label1.Text = "Major";
			this.label1.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = DockStyle.Fill;
			this.label2.Location = new Point(3, 56);
			this.label2.Name = "label2";
			this.label2.Size = new Size(102, 28);
			this.label2.TabIndex = 2;
			this.label2.Text = "Minor";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = DockStyle.Fill;
			this.label3.Location = new Point(3, 84);
			this.label3.Name = "label3";
			this.label3.Size = new Size(102, 28);
			this.label3.TabIndex = 3;
			this.label3.Text = "Patch";
			this.label3.TextAlign = ContentAlignment.MiddleRight;
			// 
			// _cbAutoincrementPatch
			// 
			this._cbAutoincrementPatch.AutoSize = true;
			this._tlpVersion.SetColumnSpan(this._cbAutoincrementPatch, 2);
			this._cbAutoincrementPatch.Dock = DockStyle.Fill;
			this._cbAutoincrementPatch.Location = new Point(111, 115);
			this._cbAutoincrementPatch.Name = "_cbAutoincrementPatch";
			this._cbAutoincrementPatch.Size = new Size(305, 22);
			this._cbAutoincrementPatch.TabIndex = 4;
			this._cbAutoincrementPatch.Text = "Autoincrement Patch";
			this._cbAutoincrementPatch.UseVisualStyleBackColor = true;
			// 
			// _cxReleaseIdentifier
			// 
			this._tlpVersion.SetColumnSpan(this._cxReleaseIdentifier, 2);
			this._cxReleaseIdentifier.Dock = DockStyle.Fill;
			this._cxReleaseIdentifier.DropDownStyle = ComboBoxStyle.DropDownList;
			this._cxReleaseIdentifier.FormattingEnabled = true;
			this._cxReleaseIdentifier.Location = new Point(111, 199);
			this._cxReleaseIdentifier.Name = "_cxReleaseIdentifier";
			this._cxReleaseIdentifier.Size = new Size(305, 28);
			this._cxReleaseIdentifier.TabIndex = 5;
			this._cxReleaseIdentifier.SelectedIndexChanged += this.OnReleaseIdentifierChanged;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = DockStyle.Fill;
			this.label4.Location = new Point(3, 196);
			this.label4.Name = "label4";
			this.label4.Size = new Size(102, 32);
			this.label4.TabIndex = 6;
			this.label4.Text = "Release ID";
			this.label4.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = DockStyle.Fill;
			this.label5.Location = new Point(3, 228);
			this.label5.Name = "label5";
			this.label5.Size = new Size(102, 28);
			this.label5.TabIndex = 7;
			this.label5.Text = "RC Number";
			this.label5.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = DockStyle.Fill;
			this.label6.Location = new Point(3, 256);
			this.label6.Name = "label6";
			this.label6.Size = new Size(102, 28);
			this.label6.TabIndex = 8;
			this.label6.Text = "Target";
			this.label6.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = DockStyle.Fill;
			this.label7.Location = new Point(3, 284);
			this.label7.Name = "label7";
			this.label7.Size = new Size(102, 28);
			this.label7.TabIndex = 9;
			this.label7.Text = "SHA Code";
			this.label7.TextAlign = ContentAlignment.MiddleRight;
			// 
			// _nudMajor
			// 
			this._nudMajor.Dock = DockStyle.Fill;
			this._nudMajor.Location = new Point(111, 31);
			this._nudMajor.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this._nudMajor.Name = "_nudMajor";
			this._nudMajor.Size = new Size(159, 27);
			this._nudMajor.TabIndex = 10;
			this._nudMajor.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// _nudMinor
			// 
			this._nudMinor.Dock = DockStyle.Fill;
			this._nudMinor.Location = new Point(111, 59);
			this._nudMinor.Name = "_nudMinor";
			this._nudMinor.Size = new Size(159, 27);
			this._nudMinor.TabIndex = 11;
			// 
			// _nudPatch
			// 
			this._nudPatch.Dock = DockStyle.Fill;
			this._nudPatch.Location = new Point(111, 87);
			this._nudPatch.Name = "_nudPatch";
			this._nudPatch.Size = new Size(159, 27);
			this._nudPatch.TabIndex = 12;
			// 
			// _nudRCNumber
			// 
			this._nudRCNumber.Dock = DockStyle.Fill;
			this._nudRCNumber.Location = new Point(111, 231);
			this._nudRCNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			this._nudRCNumber.Name = "_nudRCNumber";
			this._nudRCNumber.Size = new Size(159, 27);
			this._nudRCNumber.TabIndex = 13;
			this._nudRCNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// _txTarget
			// 
			this._tlpVersion.SetColumnSpan(this._txTarget, 2);
			this._txTarget.Dock = DockStyle.Fill;
			this._txTarget.Location = new Point(111, 259);
			this._txTarget.Name = "_txTarget";
			this._txTarget.Size = new Size(305, 27);
			this._txTarget.TabIndex = 14;
			// 
			// _txShaCode
			// 
			this._tlpVersion.SetColumnSpan(this._txShaCode, 2);
			this._txShaCode.Dock = DockStyle.Fill;
			this._txShaCode.Location = new Point(111, 287);
			this._txShaCode.Name = "_txShaCode";
			this._txShaCode.Size = new Size(305, 27);
			this._txShaCode.TabIndex = 15;
			// 
			// _btShaCode
			// 
			this._btShaCode.Dock = DockStyle.Fill;
			this._btShaCode.Location = new Point(419, 284);
			this._btShaCode.Margin = new Padding(0);
			this._btShaCode.Name = "_btShaCode";
			this._btShaCode.Size = new Size(48, 28);
			this._btShaCode.TabIndex = 16;
			this._btShaCode.Text = "...";
			this._btShaCode.UseVisualStyleBackColor = true;
			this._btShaCode.Click += this.OnShaCodeSearch;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this._tlpVersion.SetColumnSpan(this.label8, 2);
			this.label8.Dock = DockStyle.Fill;
			this.label8.Location = new Point(276, 28);
			this.label8.Name = "label8";
			this.label8.Padding = new Padding(0, 0, 3, 0);
			this.label8.Size = new Size(188, 28);
			this.label8.TabIndex = 17;
			this.label8.Text = "Breaking changes";
			this.label8.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this._tlpVersion.SetColumnSpan(this.label9, 2);
			this.label9.Dock = DockStyle.Fill;
			this.label9.Location = new Point(276, 56);
			this.label9.Name = "label9";
			this.label9.Padding = new Padding(0, 0, 3, 0);
			this.label9.Size = new Size(188, 28);
			this.label9.TabIndex = 18;
			this.label9.Text = "New features";
			this.label9.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this._tlpVersion.SetColumnSpan(this.label10, 2);
			this.label10.Dock = DockStyle.Fill;
			this.label10.Location = new Point(276, 84);
			this.label10.Name = "label10";
			this.label10.Padding = new Padding(0, 0, 3, 0);
			this.label10.Size = new Size(188, 28);
			this.label10.TabIndex = 19;
			this.label10.Text = "Bug Fixes";
			this.label10.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Dock = DockStyle.Fill;
			this.label11.Location = new Point(3, 140);
			this.label11.Name = "label11";
			this.label11.Size = new Size(102, 28);
			this.label11.TabIndex = 20;
			this.label11.Text = "Date";
			this.label11.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Dock = DockStyle.Fill;
			this.label12.Location = new Point(3, 168);
			this.label12.Name = "label12";
			this.label12.Size = new Size(102, 28);
			this.label12.TabIndex = 21;
			this.label12.Text = "Cadence";
			this.label12.TextAlign = ContentAlignment.MiddleRight;
			// 
			// _lblDate
			// 
			this._lblDate.AutoSize = true;
			this._lblDate.Dock = DockStyle.Fill;
			this._lblDate.Location = new Point(111, 140);
			this._lblDate.Name = "_lblDate";
			this._lblDate.Size = new Size(159, 28);
			this._lblDate.TabIndex = 22;
			this._lblDate.Text = "****";
			this._lblDate.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// _lblCadence
			// 
			this._lblCadence.AutoSize = true;
			this._lblCadence.Dock = DockStyle.Fill;
			this._lblCadence.Location = new Point(111, 168);
			this._lblCadence.Name = "_lblCadence";
			this._lblCadence.Size = new Size(159, 28);
			this._lblCadence.TabIndex = 23;
			this._lblCadence.Text = "1";
			this._lblCadence.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// VersionControl
			// 
			this.AutoScaleDimensions = new SizeF(9F, 20F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this._tlpVersion);
			this.Font = new Font("Consolas", 10F);
			this.Margin = new Padding(0);
			this.Name = "VersionControl";
			this.Size = new Size(467, 462);
			this._tlpVersion.ResumeLayout(false);
			this._tlpVersion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this._nudMajor).EndInit();
			((System.ComponentModel.ISupportInitialize)this._nudMinor).EndInit();
			((System.ComponentModel.ISupportInitialize)this._nudPatch).EndInit();
			((System.ComponentModel.ISupportInitialize)this._nudRCNumber).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private TableLayoutPanel _tlpVersion;
		private CheckBox _cbIsReleaseProject;
		private Label label1;
		private Label label2;
		private Label label3;
		private CheckBox _cbAutoincrementPatch;
		private ComboBox _cxReleaseIdentifier;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private NumericUpDown _nudMajor;
		private NumericUpDown _nudMinor;
		private NumericUpDown _nudPatch;
		private NumericUpDown _nudRCNumber;
		private TextBox _txTarget;
		private TextBox _txShaCode;
		private Button _btShaCode;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label11;
		private Label label12;
		private Label _lblDate;
		private Label _lblCadence;
	}
}
