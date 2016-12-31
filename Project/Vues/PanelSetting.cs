// Log code 37 05

using Tools4Libraries;
/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assistant
{
	/// <summary>
	/// Description of FormSetting.
	/// </summary>
	public partial class PanelSetting : Panel
	{
		#region Attribute
		private System.Windows.Forms.DataGridViewTextBoxColumn Activity_ColumnDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn Activity_Columndesignation;
		private System.Windows.Forms.DataGridViewButtonColumn Activity_ColumnDelete;
		private System.Windows.Forms.DataGridViewButtonColumn Activity_ColumnColor;

        private System.Windows.Forms.DataGridView dgv_exportListExportation;
        private System.Windows.Forms.DataGridView dgv_activity;
        private System.Windows.Forms.DataGridView dgv_CalendarPreview;
        private System.Windows.Forms.DataGridView dgv_ExportPreview;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageActivity;
        private System.Windows.Forms.TabPage tabPageExport;
        private System.Windows.Forms.Panel panelCalendarSetting;
        private System.Windows.Forms.Panel panelExportSettings;
        private System.Windows.Forms.Panel panelCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeekDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSep;
        private System.Windows.Forms.DataGridViewTextBoxColumn MrA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MrB;
		private System.Windows.Forms.DataGridViewTextBoxColumn Export_ColumnName;
		private System.Windows.Forms.DataGridViewButtonColumn Export_ColumnUp;
		private System.Windows.Forms.DataGridViewButtonColumn Export_ColumnDown;
		private System.Windows.Forms.DataGridViewButtonColumn Export_ColumnDelete;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelKindOfActivity;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTrigramme;
        private System.Windows.Forms.Button buttonAddActivity;
        private System.Windows.Forms.CheckBox checkBoxDisplayHeader;
        
		private Interface_calendar int_cal;
		#endregion
		
		#region Properties
		#endregion
		
		#region Constructor
		public PanelSetting(Interface_calendar ic)
        {
            InitializeComponent();
			int_cal = ic;
        }
		#endregion

        #region Methods public
        public void refresh()
        {
            BuildAllPanel();

            LoadExport();
            LoadActivity();

            RefreshPreviewExport();
        }
        #endregion

        #region Methods private
        private void BuildAllPanel()
        {
            BuildTabControl();
            BuildDGVCalendar();
            BuildDGVPreview();
            BuildPanelCommand();

            this.Controls.Add(this.dgv_ExportPreview);
            this.Controls.Add(this.panelCommand); 
            this.Controls.Add(this.dgv_CalendarPreview);
            this.Controls.Add(this.tabControl1);
        }
        private void BuildDGVActivity()
        {
            if (dgv_activity == null)
            {
                this.dgv_activity = new System.Windows.Forms.DataGridView();

                this.Activity_Columndesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Activity_ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //			this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //			this.ColumnDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
                this.Activity_ColumnColor = new System.Windows.Forms.DataGridViewButtonColumn();
                this.Activity_ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
                // 
                // Columndesignation
                // 
                this.Activity_Columndesignation.HeaderText = "Trigramme";
                this.Activity_Columndesignation.Name = "Columndesignation";
                this.Activity_Columndesignation.Width = 67;
                this.Activity_Columndesignation.DefaultCellStyle.SelectionBackColor = this.Activity_Columndesignation.DefaultCellStyle.BackColor;
                // 
                // ColumnDescription
                // 
                this.Activity_ColumnDescription.HeaderText = "Description";
                this.Activity_ColumnDescription.Name = "ColumnDescription";
                this.Activity_ColumnDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Activity_ColumnDescription.DefaultCellStyle.SelectionBackColor = this.Activity_ColumnDescription.DefaultCellStyle.BackColor;
                // 
                // ColumnColor
                // 
                this.Activity_ColumnColor.HeaderText = "Color";
                this.Activity_ColumnColor.Name = "ColumnColor";
                this.Activity_ColumnColor.Width = 50;
                //			this.ColumnColor.FlatStyle = FlatStyle.Flat;
                //			this.ColumnColor.Text = "";
                this.Activity_ColumnColor.DefaultCellStyle.SelectionBackColor = this.Activity_ColumnColor.DefaultCellStyle.BackColor;
                this.Activity_ColumnColor.DefaultCellStyle.NullValue = "Color";
                // 
                // ColumnDelete
                // 
                this.Activity_ColumnDelete.HeaderText = "Del";
                this.Activity_ColumnDelete.Name = "ColumnDelete";
                this.Activity_ColumnDelete.Width = 50;
                //			this.ColumnDelete.FlatStyle = FlatStyle.Flat;
                //			this.ColumnDelete.Text = "";
                this.Activity_ColumnDelete.DefaultCellStyle.SelectionBackColor = this.Activity_ColumnDelete.DefaultCellStyle.BackColor;
                this.Activity_ColumnDelete.DefaultCellStyle.NullValue = "Delete";
                // 
                // dgv_activity
                // 
                this.dgv_activity.AllowUserToAddRows = false;
                this.dgv_activity.AllowUserToDeleteRows = false;
                this.dgv_activity.AllowUserToOrderColumns = true;
                this.dgv_activity.Name = "dgv_activity";
                this.dgv_activity.ReadOnly = true;
                this.dgv_activity.RowHeadersVisible = false;
                this.dgv_activity.Height = 300;
                this.dgv_activity.TabIndex = 2;
                this.dgv_activity.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.dgv_activity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			                                   	this.Activity_Columndesignation,
			                                   	this.Activity_ColumnDescription,
			                                   	this.Activity_ColumnColor,
			                                   	this.Activity_ColumnDelete});

                this.dgv_activity.AllowDrop = false;
                this.dgv_activity.AllowUserToAddRows = false;
                this.dgv_activity.AllowUserToDeleteRows = false;
                this.dgv_activity.AllowUserToResizeColumns = false;
                this.dgv_activity.AllowUserToResizeRows = false;
                this.dgv_activity.CellClick += new DataGridViewCellEventHandler(FormSetting_CellClick_Activity);
            }
		}
		private void BuildDGVExport()
        {
            if (dgv_exportListExportation == null)
            {
                this.Export_ColumnName = new DataGridViewTextBoxColumn();
			    this.Export_ColumnUp = new DataGridViewButtonColumn();
			    this.Export_ColumnDown = new DataGridViewButtonColumn();
			    this.Export_ColumnDelete = new DataGridViewButtonColumn();
			
			    this.Export_ColumnName.HeaderText = "Name";
			    this.Export_ColumnName.Name = "name";
			    this.Export_ColumnName.Width = 268;
                this.Export_ColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			
			    this.Export_ColumnUp.HeaderText = "Up";
			    this.Export_ColumnUp.Name = "up";
			    this.Export_ColumnUp.Width = 30;
			
			    this.Export_ColumnDown.HeaderText = "Down";
			    this.Export_ColumnDown.Name = "down";
			    this.Export_ColumnDown.Width = 30;
			
			    this.Export_ColumnDelete.HeaderText = "Del";
			    this.Export_ColumnDelete.Name = "delete";
			    this.Export_ColumnDelete.Width = 30;

                this.dgv_exportListExportation = new System.Windows.Forms.DataGridView();
                this.dgv_exportListExportation.ColumnHeadersVisible = false;
                this.dgv_exportListExportation.Name = "dgv_export";
                this.dgv_exportListExportation.RowHeadersVisible = false;
                this.dgv_exportListExportation.TabIndex = 3;
                this.dgv_exportListExportation.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dgv_exportListExportation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			                                 	this.Export_ColumnName,
			                                 	this.Export_ColumnUp,
			                                 	this.Export_ColumnDown,
			                                 	this.Export_ColumnDelete});

                this.dgv_exportListExportation.AllowDrop = false;
                this.dgv_exportListExportation.AllowUserToAddRows = false;
                this.dgv_exportListExportation.AllowUserToDeleteRows = false;
                this.dgv_exportListExportation.AllowUserToResizeColumns = false;
                this.dgv_exportListExportation.AllowUserToResizeRows = false;
                this.dgv_exportListExportation.CellClick += new DataGridViewCellEventHandler(FormSetting_CellClick_Export);
                this.textBoxFileName.Text = int_cal.ExportFileName;
            }
		}
        private void BuildDGVCalendar()
        {
            DateTime dt;

            this.ColumnWeekDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MrA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MrB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            // 
            // ColumnWeekDay
            // 
            this.ColumnWeekDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnWeekDay.HeaderText = "WeekDay";
            this.ColumnWeekDay.Name = "ColumnWeekDay";
            this.ColumnWeekDay.ReadOnly = true;
            this.ColumnWeekDay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnWeekDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColumnDay
            // 
            this.ColumnDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnDay.HeaderText = "Day";
            this.ColumnDay.MinimumWidth = 75;
            this.ColumnDay.Name = "ColumnDay";
            this.ColumnDay.ReadOnly = true;
            this.ColumnDay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnDay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnDay.Width = 75;
            // 
            // ColumnMonth
            // 
            this.ColumnMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnMonth.HeaderText = "Month";
            this.ColumnMonth.Name = "ColumnMonth";
            this.ColumnMonth.ReadOnly = true;
            this.ColumnMonth.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnMonth.Width = 130;
            // 
            // ColumnSep
            // 
            this.ColumnSep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnSep.HeaderText = "Sep";
            this.ColumnSep.Name = "ColumnSep";
            this.ColumnSep.ReadOnly = true;
            this.ColumnSep.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ColumnSep.Width = 5;
            // 
            // MrA
            // 
            this.MrA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MrA.HeaderText = "Member A On call";
            this.MrA.MinimumWidth = 170;
            this.MrA.Name = "MrA";
            this.MrA.ReadOnly = true;
            this.MrA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MrA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MrA.Width = 170;
            // 
            // MrB
            // 
            this.MrB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MrB.HeaderText = "Member B On call";
            this.MrB.MinimumWidth = 170;
            this.MrB.Name = "MrB";
            this.MrB.ReadOnly = true;
            this.MrB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MrB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MrB.Width = 170;

            if (dgv_CalendarPreview != null) dgv_CalendarPreview.Dispose();
            this.dgv_CalendarPreview = new System.Windows.Forms.DataGridView();
            this.dgv_CalendarPreview.AllowUserToAddRows = false;
            this.dgv_CalendarPreview.AllowUserToDeleteRows = false;
            this.dgv_CalendarPreview.AllowUserToResizeColumns = false;
            this.dgv_CalendarPreview.AllowUserToResizeRows = false;
            this.dgv_CalendarPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv_CalendarPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CalendarPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnWeekDay,
            this.ColumnDay,
            this.ColumnMonth,
            this.ColumnSep,
            this.MrA,
            this.MrB});
            this.dgv_CalendarPreview.Name = "dgv_CalendarPreview";
            this.dgv_CalendarPreview.ReadOnly = true;
            this.dgv_CalendarPreview.RowHeadersVisible = false;
            this.dgv_CalendarPreview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_CalendarPreview.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_CalendarPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_CalendarPreview.TabIndex = 12;
            this.dgv_CalendarPreview.Height = 200;
            this.dgv_CalendarPreview.Dock = System.Windows.Forms.DockStyle.Top;
            
            for (int i = 1; i < 9; i++)
            {
                dgv_CalendarPreview.Rows.Add();
                dt = new DateTime(DateTime.Today.Year, 12, 20 + i);
                dgv_CalendarPreview.Rows[i - 1].Cells[0].Value = dt.DayOfWeek;
                dgv_CalendarPreview.Rows[i - 1].Cells[1].Value = dt.Day;
                dgv_CalendarPreview.Rows[i - 1].Cells[2].Value = dt.ToString("MMMM");
                dgv_CalendarPreview.Rows[i - 1].Cells[3].Value = dt.Ticks.ToString();
                if (dt.DayOfWeek.ToString().Equals("Saturday") || dt.DayOfWeek.ToString().Equals("Sunday"))
                {
                    dgv_CalendarPreview.Rows[i - 1].Cells[0].Style.BackColor = Color.Gray;
                    dgv_CalendarPreview.Rows[i - 1].Cells[1].Style.BackColor = Color.Gray;
                    dgv_CalendarPreview.Rows[i - 1].Cells[2].Style.BackColor = Color.Gray;
                    dgv_CalendarPreview.Rows[i - 1].Cells[4].Style.BackColor = Color.Gray;
                    dgv_CalendarPreview.Rows[i - 1].Cells[5].Style.BackColor = Color.Gray;
                }
                dgv_CalendarPreview.Rows[i - 1].Cells[3].Style.BackColor = Color.Black;
                if (dt.Day.ToString().Equals("25"))
                {
                    dgv_CalendarPreview.Rows[i - 1].Cells[4].Value = "x";
                    dgv_CalendarPreview.Rows[i - 1].Cells[0].Style.BackColor = Color.Gray;
                    dgv_CalendarPreview.Rows[i - 1].Cells[1].Style.BackColor = Color.Gray;
                    dgv_CalendarPreview.Rows[i - 1].Cells[2].Style.BackColor = Color.Gray;
                    dgv_CalendarPreview.Rows[i - 1].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_CalendarPreview.Rows[i - 1].Cells[4].Style.BackColor = Color.LawnGreen;
                    dgv_CalendarPreview.Rows[i - 1].Cells[5].Style.BackColor = Color.Gray;
                }
                else
                {
                    dgv_CalendarPreview.Rows[i - 1].Cells[5].Value = "x";
                    dgv_CalendarPreview.Rows[i - 1].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_CalendarPreview.Rows[i - 1].Cells[5].Style.BackColor = Color.LawnGreen;
                }
            }
        }
        private void BuildDGVPreview()
        {
            this.dgv_ExportPreview = new System.Windows.Forms.DataGridView();
            this.dgv_ExportPreview.AllowUserToAddRows = false;
            this.dgv_ExportPreview.AllowUserToDeleteRows = false;
            this.dgv_ExportPreview.AllowUserToOrderColumns = true;
            this.dgv_ExportPreview.AllowUserToResizeColumns = false;
            this.dgv_ExportPreview.AllowUserToResizeRows = false;
            this.dgv_ExportPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExportPreview.Name = "dgv_ExportPreview";
            this.dgv_ExportPreview.RowHeadersVisible = false;
            this.dgv_ExportPreview.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgv_ExportPreview.TabIndex = 13;
            this.dgv_ExportPreview.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        private void BuildTabControl()
        {
            BuildDGVExport();
            BuildDGVActivity();

            BuildPanelCalendar();
            BuildPanelExport();

            BuildTabPageActivity();
            BuildTabPageExport();

            if (tabControl1 == null)
            {
                this.tabControl1 = new System.Windows.Forms.TabControl();
                this.tabControl1.Controls.Add(this.tabPageExport);
                this.tabControl1.Controls.Add(this.tabPageActivity);
                this.tabControl1.Location = new System.Drawing.Point(0, 10);
                this.tabControl1.Name = "tabControl1";
                this.tabControl1.SelectedIndex = 0;
                this.tabControl1.Size = new System.Drawing.Size(480, 478);
                this.tabControl1.TabIndex = 1;
                this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            }
        }
        private void BuildTabPageActivity()
        {
            if (tabPageActivity == null)
            {
                // 
                // labelKindOfActivity
                // 
                this.labelKindOfActivity = new System.Windows.Forms.Label();
                this.labelKindOfActivity.Location = new System.Drawing.Point(6, 6);
                this.labelKindOfActivity.Name = "labelKindOfActivity";
                this.labelKindOfActivity.Size = new System.Drawing.Size(180, 19);
                this.labelKindOfActivity.TabIndex = 3;
                this.labelKindOfActivity.Text = "List of the calendar activity :";
                // 
                // buttonAddActivity
                // 
                this.buttonAddActivity = new System.Windows.Forms.Button();
                this.buttonAddActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.buttonAddActivity.ForeColor = System.Drawing.SystemColors.Control;
                this.buttonAddActivity.Location = new System.Drawing.Point(911, 28);
                this.buttonAddActivity.Name = "buttonAddActivity";
                this.buttonAddActivity.Size = new System.Drawing.Size(35, 38);
                this.buttonAddActivity.TabIndex = 4;
                this.buttonAddActivity.Tag = "Add the activity";
                this.buttonAddActivity.Image = int_cal.Tsm.Gui.imageListToolStrip32.Images[int_cal.Tsm.Gui.imageListToolStrip32.Images.IndexOfKey("add")];
                this.buttonAddActivity.UseVisualStyleBackColor = true;
                this.buttonAddActivity.Click += new System.EventHandler(this.ButtonAddActivityClick);
                // 
                // textBoxTrigramme
                // 
                this.textBoxTrigramme = new System.Windows.Forms.TextBox();
                this.textBoxTrigramme.Location = new System.Drawing.Point(9, 28);
                this.textBoxTrigramme.Multiline = true;
                this.textBoxTrigramme.Name = "textBoxTrigramme";
                this.textBoxTrigramme.Size = new System.Drawing.Size(68, 38);
                this.textBoxTrigramme.TabIndex = 5;
                // 
                // textBoxDescription
                // 
                this.textBoxDescription = new System.Windows.Forms.TextBox();
                this.textBoxDescription.Location = new System.Drawing.Point(83, 28);
                this.textBoxDescription.Multiline = true;
                this.textBoxDescription.Name = "textBoxDescription";
                this.textBoxDescription.Size = new System.Drawing.Size(340, 38);
                this.textBoxDescription.TabIndex = 6;
                // 
                // buttonColor
                // 
                this.buttonColor = new System.Windows.Forms.Button();
                this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.buttonColor.ForeColor = System.Drawing.SystemColors.Control;
                this.buttonColor.Location = new System.Drawing.Point(430, 30);
                this.buttonColor.Name = "buttonColor";
                this.buttonColor.Size = new System.Drawing.Size(35, 35);
                this.buttonColor.TabIndex = 7;
                this.buttonColor.Tag = "Color";
                this.buttonColor.Image = int_cal.Tsm.Gui.imageListToolStrip32.Images[int_cal.Tsm.Gui.imageListToolStrip32.Images.IndexOfKey("color")];
                this.buttonColor.UseVisualStyleBackColor = true;
                this.buttonColor.Click += new System.EventHandler(this.ButtonColorClick);
            
                this.tabPageActivity = new System.Windows.Forms.TabPage();
                this.tabPageActivity.BackColor = System.Drawing.Color.WhiteSmoke;
                this.tabPageActivity.Controls.Add(this.dgv_activity);
                this.tabPageActivity.Controls.Add(this.labelKindOfActivity);
                this.tabPageActivity.Controls.Add(this.buttonAddActivity);
                this.tabPageActivity.Controls.Add(this.buttonColor);
                this.tabPageActivity.Controls.Add(this.textBoxTrigramme);
                this.tabPageActivity.Controls.Add(this.textBoxDescription);
                this.tabPageActivity.Location = new System.Drawing.Point(4, 22);
                this.tabPageActivity.Name = "tabPageActivity";
                this.tabPageActivity.Padding = new System.Windows.Forms.Padding(3);
                this.tabPageActivity.TabIndex = 0;
                this.tabPageActivity.Text = "Activity/Color";
            }
        }
        private void BuildTabPageExport()
        {
            if (tabPageExport == null)
            {
                this.tabPageExport = new System.Windows.Forms.TabPage();
                this.tabPageExport.BackColor = System.Drawing.Color.WhiteSmoke;
                this.tabPageExport.Controls.Add(this.dgv_exportListExportation);
                this.tabPageExport.Controls.Add(this.panelExportSettings);
                this.tabPageExport.Location = new System.Drawing.Point(4, 22);
                this.tabPageExport.Name = "tabPageExport";
                this.tabPageExport.Padding = new System.Windows.Forms.Padding(3);
                this.tabPageExport.TabIndex = 1;
                this.tabPageExport.Text = "Exports";

                this.checkBoxDisplayHeader = new System.Windows.Forms.CheckBox();
                this.checkBoxDisplayHeader.AutoSize = true;
                this.checkBoxDisplayHeader.Checked = true;
                this.checkBoxDisplayHeader.CheckState = System.Windows.Forms.CheckState.Checked;
                this.checkBoxDisplayHeader.Location = new System.Drawing.Point(8, 108);
                this.checkBoxDisplayHeader.Name = "checkBoxDisplayHeader";
                this.checkBoxDisplayHeader.Size = new System.Drawing.Size(173, 17);
                this.checkBoxDisplayHeader.TabIndex = 11;
                this.checkBoxDisplayHeader.Text = "Display header in the export file";
                this.checkBoxDisplayHeader.UseVisualStyleBackColor = true;
            }
        }
        private void BuildPanelCalendar()
        {
            if (panelCalendarSetting == null)
            {
                this.panelCalendarSetting = new System.Windows.Forms.Panel();
                this.panelCalendarSetting.Controls.Add(this.tabControl1);
                this.panelCalendarSetting.Dock = System.Windows.Forms.DockStyle.Left;
                this.panelCalendarSetting.Name = "panelCalendarSetting";
                this.panelCalendarSetting.TabIndex = 2;
            }
        }
        private void BuildPanelExport()
        {
            if (panelExportSettings == null)
            {
                this.panelExportSettings = new System.Windows.Forms.Panel();
                this.panelExportSettings.Controls.Add(this.checkBoxDisplayHeader);
                this.panelExportSettings.Controls.Add(this.textBoxFileName);
                this.panelExportSettings.Controls.Add(this.labelFileName);
                this.panelExportSettings.Controls.Add(this.comboBoxEndDate);
                this.panelExportSettings.Controls.Add(this.comboBoxStartDate);
                this.panelExportSettings.Controls.Add(this.label1);
                this.panelExportSettings.Controls.Add(this.labelDateStart);
                this.panelExportSettings.Controls.Add(this.comboBox);
                this.panelExportSettings.Controls.Add(this.buttonAdd);
                this.panelExportSettings.Height = 150;
                this.panelExportSettings.Dock = System.Windows.Forms.DockStyle.Top;
                this.panelExportSettings.Name = "panelExportSettings";
                this.panelExportSettings.TabIndex = 3;
            }
        }
        private void BuildPanelCommand()
        {
            if (this.panelCommand == null)
            {
                panelCommand = new Panel();
                panelCommand.Controls.Clear();
                panelCommand.Dock = DockStyle.Bottom;
                panelCommand.Height = 30;
                // 
                // buttonOK
                // 
                this.buttonOK = new System.Windows.Forms.Button();
                this.buttonOK.Location = new System.Drawing.Point(5, 3);
                this.buttonOK.Name = "buttonOK";
                this.buttonOK.Size = new System.Drawing.Size(75, 23);
                this.buttonOK.TabIndex = 0;
                this.buttonOK.Text = "Apply";
                this.buttonOK.UseVisualStyleBackColor = true;
                this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
                // 
                // buttonCancel
                // 
                this.buttonCancel = new System.Windows.Forms.Button();
                this.buttonCancel.Location = new System.Drawing.Point(95, 3);
                this.buttonCancel.Name = "buttonCancel";
                this.buttonCancel.Size = new System.Drawing.Size(75, 23);
                this.buttonCancel.TabIndex = 1;
                this.buttonCancel.Text = "Reset";
                this.buttonCancel.UseVisualStyleBackColor = true;
                this.buttonCancel.Click += new EventHandler(buttonCancel_Click);

                panelCommand.Controls.Add(this.buttonCancel);
                panelCommand.Controls.Add(this.buttonOK);
            }
        }

        private void LoadActivity()
        {
            dgv_activity.Rows.Clear();
            foreach (string s in int_cal.ListActivities)
            {
                if (s.Split('|').Length > 2)
                {
                    try
                    {
                        Color color = Color.White;
                        if (s.Split('|')[2].Contains("#"))
                        {
                            try
                            {
                                color = Color.FromArgb(int.Parse(s.Split('|')[2].ToString().Split('#')[1]));
                            }
                            catch (Exception exp3703)
                            {
                                Log.write("[ DEB : 3703 ] Cannot load activity color.\n" + exp3703.Message);
                            }
                        }
                        else
                        {
                            color = Color.FromName(s.Split('|')[2]);
                        }
                        LoadRowActivity(s.Split('|')[1], s.Split('|')[0], color);
                    }
                    catch (Exception exp3701)
                    {
                        Log.write("[ DEB : 3701 ] Cannot load activity.\n" + exp3701.Message);
                    }
                }
            }
        }
        private void LoadExport()
        {
            comboBoxStartDate.Items.Add("DD/MM/YY");
            comboBoxStartDate.Items.Add("DD/MM/YYYY");
            comboBoxStartDate.Items.Add("MM/DD/YY");
            comboBoxStartDate.Items.Add("DD/MM/YYYY");
            comboBoxStartDate.SelectedIndex = 0;
            comboBoxStartDate.Enabled = false;

            comboBoxEndDate.Items.Add("DD/MM/YY");
            comboBoxEndDate.Items.Add("DD/MM/YYYY");
            comboBoxEndDate.Items.Add("MM/DD/YY");
            comboBoxEndDate.Items.Add("DD/MM/YYYY");
            comboBoxEndDate.SelectedIndex = 0;
            comboBoxEndDate.Enabled = false;

            comboBox.Items.Add("start date");
            comboBox.Items.Add("start time");
            comboBox.Items.Add("end date");
            comboBox.Items.Add("end time");
            comboBox.Items.Add("User name");
            comboBox.Items.Add("User firstname");
            comboBox.Items.Add("User matricule");
            comboBox.Items.Add("User role");
            comboBox.Items.Add("Team name");
            comboBox.Items.Add("Team chief");
            comboBox.Items.Add("Team service");
            comboBox.Items.Add("Team localisation");

            checkBoxDisplayHeader.Checked = int_cal.ExportHeader;
            dgv_exportListExportation.Rows.Clear();
            foreach (string element in int_cal.ExportsList)
            {
                LoadRowExport(element);
            }
        }
		private void LoadRowActivity(string trigramme, string description, Color col)
		{
			try
			{
				DataGridViewRow row = new DataGridViewRow();
				dgv_activity.Rows.Add(row);
				
				dgv_activity.Rows[dgv_activity.Rows.Count-1].Cells[0].Value = trigramme;
				dgv_activity.Rows[dgv_activity.Rows.Count-1].Cells[0].Style.BackColor = col;
				
				dgv_activity.Rows[dgv_activity.Rows.Count-1].Cells[1].Value = description;
				
//				Button buttonColor = new Button();
//				buttonColor.Name = trigramme + "_Color";
//				buttonColor.Text = "";
//				buttonColor.FlatStyle = FlatStyle.Flat;
//				buttonColor.Click += new EventHandler(buttonColor_Click);
//				buttonColor.Image = imageList.Images[imageList.Images.IndexOfKey("color")];
//				buttonColor.BackgroundImage = imageList.Images[imageList.Images.IndexOfKey("color")];
				dgv_activity.Rows[dgv_activity.Rows.Count-1].Cells[2].Value = "Color";
				//dgv.Rows[dgv.Rows.Count-1].Cells[2].Value = buttonColor;
				
//				Button buttonDelete = new Button();
//				buttonDelete.Name = trigramme + "_Delete";
//				buttonDelete.Click += new EventHandler(buttonDelete_Click);
//				buttonDelete.Text = "";
//				buttonDelete.FlatStyle = FlatStyle.Flat;
//				buttonDelete.Image = imageList.Images[imageList.Images.IndexOfKey("delete")];
//				buttonDelete.BackgroundImage = imageList.Images[imageList.Images.IndexOfKey("delete")];
				dgv_activity.Rows[dgv_activity.Rows.Count-1].Cells[3].Value = "Delete";
				//dgv.Rows[dgv.Rows.Count-1].Cells[3].Value = buttonDelete;
			}
			catch (Exception exp3701)
			{
				Log.write("[ WRN : 3701 ] " + exp3701.Message);
			}
		}
		private void LoadRowExport(string name)
		{
			DataGridViewRow row = new DataGridViewRow();
			dgv_exportListExportation.Rows.Add(row);
			
			dgv_exportListExportation.Rows[dgv_exportListExportation.Rows.Count-1].Cells[0].Value = name;
			
			dgv_exportListExportation.Rows[dgv_exportListExportation.Rows.Count-1].Cells[1].Value = "/\\";
			dgv_exportListExportation.Rows[dgv_exportListExportation.Rows.Count-1].Cells[2].Value = "\\/";
			dgv_exportListExportation.Rows[dgv_exportListExportation.Rows.Count-1].Cells[3].Value = "X";
		}
        private void RefreshPreviewExport()
        {
            int index = 0;
            try
            {
                if (dgv_ExportPreview.Rows.Count > 0)
                {
                    dgv_ExportPreview.Rows.Clear();
                    dgv_ExportPreview.Columns.Clear();
                }
                foreach (DataGridViewRow row in dgv_exportListExportation.Rows)
                {
                    dgv_ExportPreview.Columns.Add("col_" + row.Cells[0].Value.ToString(), row.Cells[0].Value.ToString());
                    for (int i = 1; i < 9; i++)
                    {
                        if (index == 0) dgv_ExportPreview.Rows.Add();
                        switch (row.Cells[0].Value.ToString().ToLower())
                        {
                            case "start date":
                                DateTime dt_start = new DateTime(long.Parse(dgv_CalendarPreview.Rows[i - 1].Cells[3].Value.ToString()));
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = dt_start.Day + "/" + dt_start.Month + "/" + dt_start.Year;
                                break;
                            case "end date":
                                DateTime dt_end = new DateTime(long.Parse(dgv_CalendarPreview.Rows[i - 1].Cells[3].Value.ToString()));
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = (dt_end.Day + 1) + "/" + dt_end.Month + "/" + dt_end.Year;
                                break;
                            case "start time":
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = "19:00";
                                break;
                            case "end time":
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = "08:00";
                                break;
                            case "team service":
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = int_cal.CurrentTeam.Service;
                                break;
                            case "team localisation":
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = int_cal.CurrentTeam.Localisation;
                                break;
                            case "team chief":
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = int_cal.CurrentTeam.Chief;
                                break;
                            case "team compagny":
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = int_cal.CurrentTeam.Compagny;
                                break;
                            case "user name":
                                if (dgv_CalendarPreview.Rows[i - 1].Cells[4].Value != null && dgv_CalendarPreview.Rows[i - 1].Cells[4].Value.Equals("x")) dgv_ExportPreview.Rows[i - 1].Cells[index].Value = "Familly name Mr A";
                                else if (dgv_CalendarPreview.Rows[i - 1].Cells[5].Value != null && dgv_CalendarPreview.Rows[i - 1].Cells[5].Value.Equals("x")) dgv_ExportPreview.Rows[i - 1].Cells[index].Value = "Familly name Mr B";
                                break;
                            case "user firstname":
                                if (dgv_CalendarPreview.Rows[i - 1].Cells[4].Value != null && dgv_CalendarPreview.Rows[i - 1].Cells[4].Value.Equals("x")) dgv_ExportPreview.Rows[i - 1].Cells[index].Value = "First name Mr A";
                                else if (dgv_CalendarPreview.Rows[i - 1].Cells[5].Value != null && dgv_CalendarPreview.Rows[i - 1].Cells[5].Value.Equals("x")) dgv_ExportPreview.Rows[i - 1].Cells[index].Value = "First name Mr B";
                                break;
                            case "user matricule":
                                dgv_ExportPreview.Rows[i - 1].Cells[index].Value = "012345";
                                break;
                        }
                    }
                    index++;
                }
            }
            catch (Exception exp3705)
            {
                Log.write("[ WRN : 3705 ] " + exp3705.Message);
            }
        }

		private Color ChooseColor(Color defaultValue)
		{
			colorDialog  = new ColorDialog();
			if (colorDialog.ShowDialog()  == DialogResult.OK)
			{
				return colorDialog.Color;
			}
			return defaultValue;
		}
		private void ButtonAddActivity()
		{
			if (!string.IsNullOrEmpty(textBoxTrigramme.Text) && !string.IsNullOrEmpty(textBoxDescription.Text))
			{
				LoadRowActivity(textBoxTrigramme.Text, textBoxDescription.Text, textBoxTrigramme.BackColor);
				textBoxTrigramme.BackColor = Color.White;
				textBoxTrigramme.Text = "";
				textBoxDescription.Text = "";
                RefreshPreviewExport();
			}
		}
		private void ButtonAddExportLine()
		{
            if (comboBox.SelectedItem != null)
            {
                LoadRowExport(comboBox.SelectedItem.ToString());
                RefreshPreviewExport();
            }
		}
		#endregion
		
		#region Event
		private void FormSetting_CellClick_Export(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if(dgv_exportListExportation.Columns[dgv_exportListExportation.CurrentCellAddress.X].Name.ToLower().Contains("up"))
				{
					if (dgv_exportListExportation.Rows.Count > 2 && dgv_exportListExportation.CurrentCellAddress.Y > 0)
					{
						string row1 = dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y].Cells[0].Value.ToString();
						string row2 = dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y-1].Cells[0].Value.ToString();
						
						dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y-1].Cells[0].Value = row1;
						dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y].Cells[0].Value = row2;
					}
				}
				else if(dgv_exportListExportation.Columns[dgv_exportListExportation.CurrentCellAddress.X].Name.ToLower().Contains("down"))
				{
					if (dgv_exportListExportation.Rows.Count > 2 && dgv_exportListExportation.CurrentCellAddress.Y < dgv_exportListExportation.Rows.Count - 1)
					{
						string row1 = dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y].Cells[0].Value.ToString();
						string row2 = dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y+1].Cells[0].Value.ToString();
						
						dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y+1].Cells[0].Value = row1;
						dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y].Cells[0].Value = row2;
					}
				}
				else if(dgv_exportListExportation.Columns[dgv_exportListExportation.CurrentCellAddress.X].Name.ToLower().Contains("delete"))
				{
					dgv_exportListExportation.Rows.Remove(dgv_exportListExportation.Rows[dgv_exportListExportation.CurrentCellAddress.Y]);
				}
                RefreshPreviewExport();
			}
			catch (Exception exp3704)
			{
				Log.write("[ WRN : 3704 ] " + exp3704.Message);
			}
		}
		private void FormSetting_CellClick_Activity(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if(dgv_activity.Columns[dgv_activity.CurrentCellAddress.X].Name.ToLower().Contains("color"))
				{
					dgv_activity.Rows[dgv_activity.CurrentCellAddress.Y].Cells[0].Style.BackColor = ChooseColor(dgv_activity.Rows[dgv_activity.CurrentCellAddress.Y].Cells[0].Style.BackColor);
				}
				else if (dgv_activity.Columns[dgv_activity.CurrentCellAddress.X].Name.ToLower().Contains("delete"))
				{
					dgv_activity.Rows.RemoveAt(dgv_activity.CurrentCellAddress.Y);
				}
			}
			catch (Exception exp3700)
			{
				Log.write("[ WRN : 3700 ] " + exp3700.Message);
			}
		}
        private void ButtonOKClick(object sender, EventArgs e)
		{
			try
			{
				int_cal.ListActivities.Clear();
				foreach (DataGridViewRow row in dgv_activity.Rows)
				{
					string s;
					s = row.Cells[1].Value.ToString();
					s += "|";
					s += row.Cells[0].Value.ToString();
					s += "|#";
					s += row.Cells[0].Style.BackColor.ToArgb();
					int_cal.ListActivities.Add(s);
				}
                int_cal.ExportHeader = checkBoxDisplayHeader.Checked;
				int_cal.ExportsList.Clear();
				foreach (DataGridViewRow row in dgv_exportListExportation.Rows) 
				{
					int_cal.ExportsList.Add(row.Cells[0].Value.ToString());
				}
                if (int_cal.SaveTeam())
                {
                    if (int_cal.Pancal.PanelUserCalendar != null) int_cal.Pancal.PanelUserCalendar.BuildContextMenu();
                    if (int_cal.Pancal.PanelTeamCalendar != null) int_cal.Pancal.PanelTeamCalendar.BuildContextMenu();
                    int_cal.Refresh();
                }
                else
                {
                    MessageBox.Show("Oups, we cannot save your file.\nPlease modify some parameters (file path, ...) and try again.", "Error while saving your file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
			catch (Exception exp3702)
			{
				Log.write("[ ERR : 3702 ] " + exp3702.Message);
			}
		}
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void ButtonColorClick(object sender, EventArgs e)
		{
			textBoxTrigramme.BackColor = ChooseColor(buttonColor.BackColor);
		}
		private void ButtonAddActivityClick(object sender, EventArgs e)
		{
			ButtonAddActivity();
		}
		private void ButtonAddExportClick(object sender, EventArgs e)
		{
			ButtonAddExportLine();
		}

//		private void buttonColor_Click(object sender, EventArgs e)
//		{
//			Button button = sender as Button;
//			Button b;
//			foreach (DataGridViewRow row in dgv_activity.Rows)
//			{
//				b = row.Cells[3].Value as Button;
//				if (b.Name.Equals(button.Name))
//				{
//					row.Cells[0].Style.BackColor =  ChooseColor(button.BackColor);
//				}
//			}
//		}
		#endregion
	}
}
