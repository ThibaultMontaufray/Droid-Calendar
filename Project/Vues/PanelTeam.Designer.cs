/*
 * User: Thibault MONTAUFRAY
 */
namespace Assistant
{
	partial class PanelTeam
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.labelService = new System.Windows.Forms.Label();
			this.labelLocalisation = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxService = new System.Windows.Forms.TextBox();
			this.textBoxLocalisation = new System.Windows.Forms.TextBox();
			this.groupBoxTeamSettings = new System.Windows.Forms.GroupBox();
			this.comboBoxChief = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButtonPath = new System.Windows.Forms.RadioButton();
			this.radioButtonFile = new System.Windows.Forms.RadioButton();
			this.buttonBrowseCalendarPath = new System.Windows.Forms.Button();
			this.buttonBrowseCalendarFile = new System.Windows.Forms.Button();
			this.textBoxCalendarPath = new System.Windows.Forms.TextBox();
			this.textBoxCalendarFile = new System.Windows.Forms.TextBox();
			this.textBoxCompagny = new System.Windows.Forms.TextBox();
			this.labelCompagny = new System.Windows.Forms.Label();
			this.labelChief = new System.Windows.Forms.Label();
			this.groupBoxUsers = new System.Windows.Forms.GroupBox();
			this.buttonAddUser = new System.Windows.Forms.Button();
			this.groupBoxTeamSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBoxUsers.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(600, 250);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(114, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
            this.buttonCancel.Location = new System.Drawing.Point(480, 250);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(110, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// labelName
			// 
			this.labelName.Location = new System.Drawing.Point(6, 25);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(100, 23);
			this.labelName.TabIndex = 2;
			this.labelName.Text = "Name";
			// 
			// labelService
			// 
			this.labelService.Location = new System.Drawing.Point(6, 48);
			this.labelService.Name = "labelService";
			this.labelService.Size = new System.Drawing.Size(100, 23);
			this.labelService.TabIndex = 3;
			this.labelService.Text = "Service";
			// 
			// labelLocalisation
			// 
			this.labelLocalisation.Location = new System.Drawing.Point(6, 71);
			this.labelLocalisation.Name = "labelLocalisation";
			this.labelLocalisation.Size = new System.Drawing.Size(100, 23);
			this.labelLocalisation.TabIndex = 4;
			this.labelLocalisation.Text = "Localisation";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(110, 22);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(342, 20);
			this.textBoxName.TabIndex = 8;
			// 
			// textBoxService
			// 
			this.textBoxService.Location = new System.Drawing.Point(110, 45);
			this.textBoxService.Name = "textBoxService";
			this.textBoxService.Size = new System.Drawing.Size(342, 20);
			this.textBoxService.TabIndex = 9;
			// 
			// textBoxLocalisation
			// 
			this.textBoxLocalisation.Location = new System.Drawing.Point(110, 68);
			this.textBoxLocalisation.Name = "textBoxLocalisation";
			this.textBoxLocalisation.Size = new System.Drawing.Size(342, 20);
			this.textBoxLocalisation.TabIndex = 10;
			// 
			// groupBoxTeamSettings
			// 
			this.groupBoxTeamSettings.Controls.Add(this.comboBoxChief);
			this.groupBoxTeamSettings.Controls.Add(this.groupBox1);
			this.groupBoxTeamSettings.Controls.Add(this.textBoxCompagny);
			this.groupBoxTeamSettings.Controls.Add(this.labelCompagny);
			this.groupBoxTeamSettings.Controls.Add(this.labelChief);
			this.groupBoxTeamSettings.Controls.Add(this.textBoxLocalisation);
			this.groupBoxTeamSettings.Controls.Add(this.labelLocalisation);
			this.groupBoxTeamSettings.Controls.Add(this.textBoxService);
			this.groupBoxTeamSettings.Controls.Add(this.labelName);
			this.groupBoxTeamSettings.Controls.Add(this.textBoxName);
			this.groupBoxTeamSettings.Controls.Add(this.labelService);
			this.groupBoxTeamSettings.Location = new System.Drawing.Point(480, 2);
			this.groupBoxTeamSettings.Name = "groupBoxTeamSettings";
			this.groupBoxTeamSettings.Size = new System.Drawing.Size(457, 231);
			this.groupBoxTeamSettings.TabIndex = 13;
			this.groupBoxTeamSettings.TabStop = false;
			this.groupBoxTeamSettings.Text = "Informations";
			// 
			// comboBoxChief
			// 
			this.comboBoxChief.FormattingEnabled = true;
			this.comboBoxChief.Location = new System.Drawing.Point(110, 114);
			this.comboBoxChief.Name = "comboBoxChief";
			this.comboBoxChief.Size = new System.Drawing.Size(342, 21);
			this.comboBoxChief.TabIndex = 20;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonPath);
			this.groupBox1.Controls.Add(this.radioButtonFile);
			this.groupBox1.Controls.Add(this.buttonBrowseCalendarPath);
			this.groupBox1.Controls.Add(this.buttonBrowseCalendarFile);
			this.groupBox1.Controls.Add(this.textBoxCalendarPath);
			this.groupBox1.Controls.Add(this.textBoxCalendarFile);
			this.groupBox1.Location = new System.Drawing.Point(7, 143);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(444, 81);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select your user calendar";
			// 
			// radioButtonPath
			// 
			this.radioButtonPath.Checked = true;
			this.radioButtonPath.Location = new System.Drawing.Point(6, 18);
			this.radioButtonPath.Name = "radioButtonPath";
			this.radioButtonPath.Size = new System.Drawing.Size(107, 24);
			this.radioButtonPath.TabIndex = 19;
			this.radioButtonPath.TabStop = true;
			this.radioButtonPath.Text = "Calendar path";
			this.radioButtonPath.UseVisualStyleBackColor = true;
			this.radioButtonPath.CheckedChanged += new System.EventHandler(this.RadioButtonPathCheckedChanged);
			// 
			// radioButtonFile
			// 
			this.radioButtonFile.Location = new System.Drawing.Point(6, 48);
			this.radioButtonFile.Name = "radioButtonFile";
			this.radioButtonFile.Size = new System.Drawing.Size(107, 24);
			this.radioButtonFile.TabIndex = 18;
			this.radioButtonFile.Text = "Calendar file";
			this.radioButtonFile.UseVisualStyleBackColor = true;
			this.radioButtonFile.CheckedChanged += new System.EventHandler(this.RadioButtonFileCheckedChanged);
			// 
			// buttonBrowseCalendarPath
			// 
			this.buttonBrowseCalendarPath.Location = new System.Drawing.Point(368, 19);
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
			this.buttonBrowseCalendarFile.Location = new System.Drawing.Point(368, 49);
			this.buttonBrowseCalendarFile.Name = "buttonBrowseCalendarFile";
			this.buttonBrowseCalendarFile.Size = new System.Drawing.Size(70, 23);
			this.buttonBrowseCalendarFile.TabIndex = 14;
			this.buttonBrowseCalendarFile.Text = "Browse";
			this.buttonBrowseCalendarFile.UseVisualStyleBackColor = true;
			this.buttonBrowseCalendarFile.Click += new System.EventHandler(this.ButtonBrowseCalendarFileClick);
			// 
			// textBoxCalendarPath
			// 
			this.textBoxCalendarPath.Location = new System.Drawing.Point(119, 21);
			this.textBoxCalendarPath.Name = "textBoxCalendarPath";
			this.textBoxCalendarPath.Size = new System.Drawing.Size(242, 20);
			this.textBoxCalendarPath.TabIndex = 16;
			// 
			// textBoxCalendarFile
			// 
			this.textBoxCalendarFile.Enabled = false;
			this.textBoxCalendarFile.Location = new System.Drawing.Point(119, 51);
			this.textBoxCalendarFile.Name = "textBoxCalendarFile";
			this.textBoxCalendarFile.Size = new System.Drawing.Size(242, 20);
			this.textBoxCalendarFile.TabIndex = 13;
			// 
			// textBoxCompagny
			// 
			this.textBoxCompagny.Location = new System.Drawing.Point(110, 91);
			this.textBoxCompagny.Name = "textBoxCompagny";
			this.textBoxCompagny.Size = new System.Drawing.Size(342, 20);
			this.textBoxCompagny.TabIndex = 14;
			// 
			// labelCompagny
			// 
			this.labelCompagny.Location = new System.Drawing.Point(6, 94);
			this.labelCompagny.Name = "labelCompagny";
			this.labelCompagny.Size = new System.Drawing.Size(100, 23);
			this.labelCompagny.TabIndex = 13;
			this.labelCompagny.Text = "Compagny";
			// 
			// labelChief
			// 
			this.labelChief.Location = new System.Drawing.Point(6, 117);
			this.labelChief.Name = "labelChief";
			this.labelChief.Size = new System.Drawing.Size(100, 23);
			this.labelChief.TabIndex = 11;
			this.labelChief.Text = "Chief";
			// 
			// groupBoxUsers
            // 
            this.groupBoxUsers.Controls.Add(this.buttonAddUser);
            this.groupBoxUsers.Location = new System.Drawing.Point(12, 12);
			this.groupBoxUsers.Name = "groupBoxUsers";
			this.groupBoxUsers.Size = new System.Drawing.Size(470, 256);
			this.groupBoxUsers.TabIndex = 14;
			this.groupBoxUsers.TabStop = false;
            this.groupBoxUsers.Text = "Users";
            this.groupBoxUsers.Dock = System.Windows.Forms.DockStyle.Left;
			// 
			// buttonAddUser
			// 
			this.buttonAddUser.Location = new System.Drawing.Point(7, 20);
			this.buttonAddUser.Name = "buttonAddUser";
			this.buttonAddUser.Size = new System.Drawing.Size(444, 23);
			this.buttonAddUser.TabIndex = 0;
			this.buttonAddUser.Text = "Add users";
			this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonAddUser.Click += new System.EventHandler(this.ButtonAddUserClick);
			// 
			// FormTeam
			// 
			this.ClientSize = new System.Drawing.Size(482, 550);
			this.Controls.Add(this.groupBoxUsers);
			this.Controls.Add(this.groupBoxTeamSettings);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Name = "FormTeam";
			this.Text = "Team";
			this.groupBoxTeamSettings.ResumeLayout(false);
			this.groupBoxTeamSettings.PerformLayout();
			this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupBoxUsers.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox comboBoxChief;
		private System.Windows.Forms.TextBox textBoxCalendarFile;
		private System.Windows.Forms.TextBox textBoxCalendarPath;
		private System.Windows.Forms.Button buttonBrowseCalendarFile;
		private System.Windows.Forms.Button buttonBrowseCalendarPath;
		private System.Windows.Forms.RadioButton radioButtonFile;
		private System.Windows.Forms.RadioButton radioButtonPath;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxCompagny;
		private System.Windows.Forms.Label labelCompagny;
		private System.Windows.Forms.Label labelChief;
		private System.Windows.Forms.Button buttonAddUser;
		private System.Windows.Forms.GroupBox groupBoxUsers;
		private System.Windows.Forms.GroupBox groupBoxTeamSettings;
		private System.Windows.Forms.TextBox textBoxLocalisation;
		private System.Windows.Forms.TextBox textBoxService;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelLocalisation;
		private System.Windows.Forms.Label labelService;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
	}
}
