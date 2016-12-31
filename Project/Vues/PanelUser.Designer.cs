/*
 * User: Thibault MONTAUFRAY
 */
namespace Assistant
{
	partial class PanelUser
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
            int offsetLeft = 250;

			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelFirstname = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.labelRole = new System.Windows.Forms.Label();
			this.labelArrival = new System.Windows.Forms.Label();
			this.textBoxFirstname = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxRole = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.labelMatricule = new System.Windows.Forms.Label();
			this.textBoxMatricule = new System.Windows.Forms.TextBox();
			this.ribbonUpDown1 = new System.Windows.Forms.RibbonUpDown();
			this.groupBoxKalendar = new System.Windows.Forms.GroupBox();
			this.radioButtonPath = new System.Windows.Forms.RadioButton();
			this.radioButtonFile = new System.Windows.Forms.RadioButton();
			this.buttonBrowseCalendarPath = new System.Windows.Forms.Button();
			this.buttonBrowseCalendarFile = new System.Windows.Forms.Button();
			this.textBoxCalendarPath = new System.Windows.Forms.TextBox();
			this.textBoxCalendarFile = new System.Windows.Forms.TextBox();
            this.groupBoxKalendar.SuspendLayout();
            this.pictureLevel = new System.Windows.Forms.PictureBox();
            this.pictureManager = new System.Windows.Forms.PictureBox();
            this.pictureUser = new System.Windows.Forms.PictureBox();
            this.checkBoxManager = new System.Windows.Forms.CheckBox();
            this.pictureNation = new System.Windows.Forms.PictureBox();
            this.cbNation = new System.Windows.Forms.ComboBox();
            this.labelNation = new System.Windows.Forms.Label();
            this.pictureAvatar = new System.Windows.Forms.PictureBox();
            this.cbAvatar = new System.Windows.Forms.ComboBox();
            this.labelAvatar = new System.Windows.Forms.Label();
            this.pictureCalendar = new System.Windows.Forms.PictureBox();
            this.cbCalendar = new System.Windows.Forms.ComboBox();
            this.labelCalendar = new System.Windows.Forms.Label();
            this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(5, 240);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(112, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "Apply";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(123, 240);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(112, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// labelFirstname
			// 
            this.labelFirstname.Location = new System.Drawing.Point(offsetLeft, 9);
			this.labelFirstname.Name = "labelFirstname";
			this.labelFirstname.Size = new System.Drawing.Size(100, 23);
			this.labelFirstname.TabIndex = 2;
			this.labelFirstname.Text = "Firstname";
			// 
			// labelName
			// 
            this.labelName.Location = new System.Drawing.Point(offsetLeft, 32);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(100, 23);
			this.labelName.TabIndex = 3;
			this.labelName.Text = "Name";
			// 
			// labelRole
			// 
            this.labelRole.Location = new System.Drawing.Point(offsetLeft, 55);
			this.labelRole.Name = "labelRole";
			this.labelRole.Size = new System.Drawing.Size(100, 23);
			this.labelRole.TabIndex = 4;
			this.labelRole.Text = "Role";
			// 
			// labelArrival
			// 
            this.labelArrival.Location = new System.Drawing.Point(offsetLeft, 103);
			this.labelArrival.Name = "labelArrival";
			this.labelArrival.Size = new System.Drawing.Size(100, 23);
			this.labelArrival.TabIndex = 5;
			this.labelArrival.Text = "Date of arrival";
			// 
			// textBoxFirstname
			// 
            this.textBoxFirstname.Location = new System.Drawing.Point(offsetLeft + labelFirstname.Width + 5, 6);
			this.textBoxFirstname.Name = "textBoxFirstname";
			this.textBoxFirstname.Size = new System.Drawing.Size(322, 20);
			this.textBoxFirstname.TabIndex = 6;
			// 
			// textBoxName
			// 
            this.textBoxName.Location = new System.Drawing.Point(offsetLeft + labelName.Width + 5, 29);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(322, 20);
			this.textBoxName.TabIndex = 7;
			// 
			// textBoxRole
			// 
            this.textBoxRole.Location = new System.Drawing.Point(offsetLeft + labelRole.Width + 5, 52);
			this.textBoxRole.Name = "textBoxRole";
			this.textBoxRole.Size = new System.Drawing.Size(322, 20);
			this.textBoxRole.TabIndex = 8;
			// 
			// dateTimePicker1
			// 
            this.dateTimePicker1.Location = new System.Drawing.Point(offsetLeft + labelArrival.Width + 5, 99);
			this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(322, 20);
			this.dateTimePicker1.TabIndex = 11;
			// 
			// labelMatricule
			// 
            this.labelMatricule.Location = new System.Drawing.Point(offsetLeft, 78);
			this.labelMatricule.Name = "labelMatricule";
			this.labelMatricule.Size = new System.Drawing.Size(100, 23);
			this.labelMatricule.TabIndex = 9;
			this.labelMatricule.Text = "Matricule";
			// 
			// textBoxMatricule
			// 
            this.textBoxMatricule.Location = new System.Drawing.Point(offsetLeft + labelMatricule.Width + 5, 75);
			this.textBoxMatricule.Name = "textBoxMatricule";
			this.textBoxMatricule.Size = new System.Drawing.Size(322, 20);
			this.textBoxMatricule.TabIndex = 10;
			// 
			// ribbonUpDown1
			// 
			this.ribbonUpDown1.TextBoxText = "";
			this.ribbonUpDown1.TextBoxWidth = 50;
			// 
			// radioButtonFile
			// 
            this.radioButtonFile.Checked = false;
            this.radioButtonFile.Location = new System.Drawing.Point(5, 48);
			this.radioButtonFile.Name = "radioButtonFile";
			this.radioButtonFile.Size = new System.Drawing.Size(107, 24);
			this.radioButtonFile.TabIndex = 18;
			this.radioButtonFile.Text = "Calendar file";
			this.radioButtonFile.UseVisualStyleBackColor = true;
			this.radioButtonFile.CheckedChanged += new System.EventHandler(this.RadioButtonFileCheckedChanged);
            // 
            // radioButtonPath
            // 
            this.radioButtonPath.Checked = true;
            this.radioButtonPath.Location = new System.Drawing.Point(5, 18);
            this.radioButtonPath.Name = "radioButtonPath";
            this.radioButtonPath.Size = new System.Drawing.Size(107, 24);
            this.radioButtonPath.TabIndex = 19;
            this.radioButtonPath.TabStop = true;
            this.radioButtonPath.Text = "Calendar path";
            this.radioButtonPath.UseVisualStyleBackColor = true;
            this.radioButtonPath.CheckedChanged += new System.EventHandler(this.RadioButtonPathCheckedChanged);
            // 
			// buttonBrowseCalendarPath
			// 
            this.buttonBrowseCalendarPath.Location = new System.Drawing.Point(360, 15);
			this.buttonBrowseCalendarPath.Name = "buttonBrowseCalendarPath";
			this.buttonBrowseCalendarPath.Size = new System.Drawing.Size(70, 23);
			this.buttonBrowseCalendarPath.TabIndex = 17;
			this.buttonBrowseCalendarPath.Text = "Browse";
			this.buttonBrowseCalendarPath.UseVisualStyleBackColor = true;
			this.buttonBrowseCalendarPath.Click += new System.EventHandler(this.ButtonBrowseCalendarPathClick);
			// 
			// buttonBrowseCalendarFile
			// 
			this.buttonBrowseCalendarFile.Enabled = false;
            this.buttonBrowseCalendarFile.Location = new System.Drawing.Point(360, 45);
			this.buttonBrowseCalendarFile.Name = "buttonBrowseCalendarFile";
			this.buttonBrowseCalendarFile.Size = new System.Drawing.Size(70, 23);
			this.buttonBrowseCalendarFile.TabIndex = 14;
			this.buttonBrowseCalendarFile.Text = "Browse";
			this.buttonBrowseCalendarFile.UseVisualStyleBackColor = true;
			this.buttonBrowseCalendarFile.Click += new System.EventHandler(this.ButtonBrowseCalendarFileClick);
			// 
			// textBoxCalendarPath
			// 
            this.textBoxCalendarPath.Location = new System.Drawing.Point(radioButtonPath.Width + 5, 16);
			this.textBoxCalendarPath.Name = "textBoxCalendarPath";
			this.textBoxCalendarPath.Size = new System.Drawing.Size(242, 20);
			this.textBoxCalendarPath.TabIndex = 16;
			// 
			// textBoxCalendarFile
			// 
			this.textBoxCalendarFile.Enabled = false;
            this.textBoxCalendarFile.Location = new System.Drawing.Point(radioButtonFile.Width + 5, 46);
			this.textBoxCalendarFile.Name = "textBoxCalendarFile";
			this.textBoxCalendarFile.Size = new System.Drawing.Size(242, 20);
            this.textBoxCalendarFile.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBoxKalendar.Location = new System.Drawing.Point(offsetLeft, 140);
            this.groupBoxKalendar.Name = "groupBoxKalendar";
            this.groupBoxKalendar.Size = new System.Drawing.Size(444, 81);
            this.groupBoxKalendar.TabIndex = 20;
            this.groupBoxKalendar.TabStop = false;
            this.groupBoxKalendar.Text = "Select your user calendar";
            this.groupBoxKalendar.Controls.Add(this.radioButtonFile);
            this.groupBoxKalendar.Controls.Add(this.radioButtonPath);
            this.groupBoxKalendar.Controls.Add(this.buttonBrowseCalendarFile);
            this.groupBoxKalendar.Controls.Add(this.buttonBrowseCalendarPath);
            this.groupBoxKalendar.Controls.Add(this.textBoxCalendarFile);
            this.groupBoxKalendar.Controls.Add(this.textBoxCalendarPath);
            //
            // pictureLevel
            //
            this.pictureLevel.Location = new System.Drawing.Point(50, 5);
            this.pictureLevel.Size = new System.Drawing.Size(32, 32);
            //this.pictureLevel.Image = int_cal.Tsm.Gui.imageListToolStrip32.Images[int_cal.Tsm.Gui.imageListToolStrip32.Images.IndexOfKey("none"
            //
            // pictureManager
            //
            this.pictureManager.Location = new System.Drawing.Point(30, 5);
            this.pictureManager.Size = new System.Drawing.Size(32, 32);
            //this.pictureManager.Image = int_cal.Tsm.Gui.imageListToolStrip32.Images[int_cal.Tsm.Gui.imageListToolStrip32.Images.IndexOfKey("none"
            //
            // pictureUser
            //
            this.pictureUser.Location = new System.Drawing.Point(5, 5);
            this.pictureUser.Size = new System.Drawing.Size(230, 230);
            this.pictureUser.Image = int_cal.Tsm.Gui.imageList.Images[int_cal.Tsm.Gui.imageList.Images.IndexOfKey("nopicture")];
            this.pictureUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUser.BackColor = System.Drawing.Color.Black;
            this.pictureUser.Click += new System.EventHandler(pictureUser_Click);
            //
            // checkBoxManager
            //
            this.checkBoxManager.Location = new System.Drawing.Point(offsetLeft, 212);
            this.checkBoxManager.Size = new System.Drawing.Size(200, 26);
            this.checkBoxManager.Text = "Manager";
            this.checkBoxManager.CheckedChanged += new System.EventHandler(checkBoxDroid_CheckedChanged);
            // 
            // LabelNation
            // 
            this.labelNation.Text = "Country : ";
            this.labelNation.AutoSize = true;
            this.labelNation.Location = new System.Drawing.Point(offsetLeft + 10, 247);
            // 
            // PictureNation
            // 
            this.pictureNation.Size = new System.Drawing.Size(32, 32);
            this.pictureNation.Location = new System.Drawing.Point(offsetLeft + 70, 240);
            // 
            // cbNation
            // 
            this.cbNation.Size = new System.Drawing.Size(170, 24);
            this.cbNation.Location = new System.Drawing.Point(offsetLeft + 120, 245);
            this.cbNation.SelectedIndexChanged += new System.EventHandler(cbNation_TextChanged);
            this.cbNation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // LabelAvatar
            // 
            this.labelAvatar.Text = "Avatar : ";
            this.labelAvatar.AutoSize = true;
            this.labelAvatar.Location = new System.Drawing.Point(offsetLeft + 10, 347);
            // 
            // PictureAvatar
            // 
            this.pictureAvatar.Size = new System.Drawing.Size(32, 32);
            this.pictureAvatar.Location = new System.Drawing.Point(offsetLeft + 70, 340);
            // 
            // cbAvartar
            // 
            this.cbAvatar.Size = new System.Drawing.Size(170, 24);
            this.cbAvatar.Location = new System.Drawing.Point(offsetLeft + 120, 345);
            this.cbAvatar.SelectedIndexChanged += new System.EventHandler(cbAvatar_TextChanged);
            this.cbAvatar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAvatar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // LabelCalendar
            // 
            this.labelCalendar.Text = "Calendar : ";
            this.labelCalendar.AutoSize = true;
            this.labelCalendar.Location = new System.Drawing.Point(offsetLeft + 10, 297);
            // 
            // PictureCalendar
            // 
            this.pictureCalendar.Size = new System.Drawing.Size(32, 32);
            this.pictureCalendar.Location = new System.Drawing.Point(offsetLeft + 70, 290);
            // 
            // cbCalendar
            // 
            this.cbCalendar.Size = new System.Drawing.Size(170, 24);
            this.cbCalendar.Location = new System.Drawing.Point(offsetLeft + 120, 295);
            this.cbCalendar.SelectedIndexChanged += new System.EventHandler(cbCalendar_TextChanged);
            this.cbCalendar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCalendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // FormUser
            // 
			this.ClientSize = new System.Drawing.Size(454, 247);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK); 
            this.Controls.Add(this.groupBoxKalendar);
			this.Controls.Add(this.labelMatricule);
			this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBoxMatricule);
            this.Controls.Add(this.textBoxRole);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.textBoxFirstname);
			this.Controls.Add(this.labelArrival);
			this.Controls.Add(this.labelRole);
			this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelFirstname);
            //this.Controls.Add(this.pictureLevel);
            //this.Controls.Add(this.pictureManager);
            this.Controls.Add(this.pictureUser);
            this.Controls.Add(this.labelNation);
            this.Controls.Add(this.pictureNation);
            this.Controls.Add(this.cbNation);
            this.Controls.Add(this.labelCalendar);
            this.Controls.Add(this.pictureCalendar);
            this.Controls.Add(this.cbCalendar);
            this.Controls.Add(this.labelAvatar);
            this.Controls.Add(this.pictureAvatar);
            this.Controls.Add(this.cbAvatar);
            //this.Controls.Add(this.checkBoxManager);
            this.Name = "FormUser";
		    this.Text = "User";
			this.groupBoxKalendar.ResumeLayout(false);
			this.groupBoxKalendar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
		}
		private System.Windows.Forms.TextBox textBoxCalendarFile;
		private System.Windows.Forms.Button buttonBrowseCalendarFile;
		private System.Windows.Forms.Button buttonBrowseCalendarPath;
		private System.Windows.Forms.RadioButton radioButtonFile;
		private System.Windows.Forms.RadioButton radioButtonPath;
		private System.Windows.Forms.GroupBox groupBoxKalendar;
		private System.Windows.Forms.RibbonUpDown ribbonUpDown1;
		private System.Windows.Forms.TextBox textBoxCalendarPath;
		private System.Windows.Forms.TextBox textBoxMatricule;
		private System.Windows.Forms.Label labelMatricule;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox textBoxRole;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxFirstname;
		private System.Windows.Forms.Label labelArrival;
		private System.Windows.Forms.Label labelRole;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelFirstname;
		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.PictureBox pictureUser;
        private System.Windows.Forms.PictureBox pictureLevel;
        private System.Windows.Forms.PictureBox pictureManager;
        private System.Windows.Forms.CheckBox checkBoxManager;
        private System.Windows.Forms.PictureBox pictureNation;
        private System.Windows.Forms.ComboBox cbNation;
        private System.Windows.Forms.Label labelNation;
        private System.Windows.Forms.PictureBox pictureAvatar;
        private System.Windows.Forms.ComboBox cbAvatar;
        private System.Windows.Forms.Label labelAvatar;
        private System.Windows.Forms.PictureBox pictureCalendar;
        private System.Windows.Forms.ComboBox cbCalendar;
        private System.Windows.Forms.Label labelCalendar;
    }
}
