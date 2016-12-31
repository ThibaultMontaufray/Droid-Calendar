/*
 * User: Thibault MONTAUFRAY
 */
namespace Assistant
{
	partial class FormExport
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxExportPath = new System.Windows.Forms.TextBox();
            this.ButtonPathBrowse = new System.Windows.Forms.Button();
            this.labelFIleName = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(590, 111);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(49, 23);
            this.buttonExport.TabIndex = 0;
            this.buttonExport.Text = "GO";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExportClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(516, 111);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(68, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(118, 12);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(521, 20);
            this.dateTimePickerStart.TabIndex = 2;
            // 
            // labelStartDate
            // 
            this.labelStartDate.Location = new System.Drawing.Point(12, 18);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(100, 23);
            this.labelStartDate.TabIndex = 3;
            this.labelStartDate.Text = "Start date :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "End date :";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(118, 35);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(521, 20);
            this.dateTimePickerEnd.TabIndex = 5;
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(12, 65);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(100, 23);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "Export path :";
            // 
            // textBoxExportPath
            // 
            this.textBoxExportPath.Location = new System.Drawing.Point(118, 62);
            this.textBoxExportPath.Name = "textBoxExportPath";
            this.textBoxExportPath.Size = new System.Drawing.Size(440, 20);
            this.textBoxExportPath.TabIndex = 7;
            // 
            // ButtonPathBrowse
            // 
            this.ButtonPathBrowse.Location = new System.Drawing.Point(564, 60);
            this.ButtonPathBrowse.Name = "ButtonPathBrowse";
            this.ButtonPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonPathBrowse.TabIndex = 8;
            this.ButtonPathBrowse.Text = "Browse";
            this.ButtonPathBrowse.UseVisualStyleBackColor = true;
            this.ButtonPathBrowse.Click += new System.EventHandler(this.ButtonPathBrowseClick);
            // 
            // labelFIleName
            // 
            this.labelFIleName.Location = new System.Drawing.Point(12, 91);
            this.labelFIleName.Name = "labelFIleName";
            this.labelFIleName.Size = new System.Drawing.Size(100, 23);
            this.labelFIleName.TabIndex = 9;
            this.labelFIleName.Text = "Export file name :";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(118, 88);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(521, 20);
            this.textBoxFileName.TabIndex = 10;
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 146);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.labelFIleName);
            this.Controls.Add(this.ButtonPathBrowse);
            this.Controls.Add(this.textBoxExportPath);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.TextBox textBoxFileName;
		private System.Windows.Forms.Label labelFIleName;
		private System.Windows.Forms.Button ButtonPathBrowse;
		private System.Windows.Forms.DateTimePicker dateTimePickerStart;
		private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
		private System.Windows.Forms.TextBox textBoxExportPath;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelStartDate;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonExport;
	}
}
