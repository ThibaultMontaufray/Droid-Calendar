// Log code : 47 00
/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Tools4Libraries;

namespace Assistant
{
	/// <summary>
	/// Description of FormUser.
	/// </summary>
	public partial class PanelUser : Panel
	{
		#region Attribute
        private User currentUser;
		private Interface_calendar int_cal;
		private PanelTeam formTeam;
		#endregion
		
		#region Properties
		#endregion
		
		#region Constructor
		public PanelUser(Interface_calendar ic)
		{
			int_cal = ic;
			InitializeComponent();
            initDefaultValues();
		}
		public PanelUser(Interface_calendar ic, PanelTeam ft)
		{
			formTeam = ft;
			int_cal = ic;
            InitializeComponent();
            initDefaultValues();
		}
		public PanelUser(Interface_calendar ic, User user)
		{
			int_cal = ic;
            InitializeComponent();
            initDefaultValues();
			LoadUser(user);
		}
		#endregion
		
		#region Methods public
		public void LoadUser(User user)
		{
            this.currentUser = user;
            try
            {
                radioButtonPath.Checked = true;
                radioButtonFile.Checked = false;
                textBoxCalendarPath.Enabled = true;
                textBoxCalendarFile.Enabled = false;
                buttonBrowseCalendarPath.Enabled = true;
                buttonBrowseCalendarFile.Enabled = false;
                loadNation();
                loadAvatar();
                loadCalendar();
                if (user != null)
                {
                    this.currentUser = user;
                    this.textBoxName.Text = user.Name;
                    this.textBoxFirstname.Text = user.Firstname;
                    this.textBoxMatricule.Text = user.Matricule;
                    this.textBoxRole.Text = user.Role;
                    this.textBoxCalendarPath.Text = int_cal.BuildFilePath(int_cal.CurrentTeam.FilePath);
                    this.checkBoxManager.Checked = user.Manager > 0 ? true : false;
                    this.dateTimePicker1.Text = buildUserArrivalDate(user);
                    if (!string.IsNullOrEmpty(user.PicturePath)) this.pictureUser.ImageLocation = user.PicturePath;
                    else this.pictureUser.Image = int_cal.Tsm.Gui.imageList.Images[int_cal.Tsm.Gui.imageList.Images.IndexOfKey("nopicture")];

                    BuildAvatarSelection();
                    SetManager();
                    SetLevel();
                    SetAvatar();
                    ValidateManager();
                }
            }
            catch (Exception exp4700)
            {
                Log.write("[ ERR : 4700 ] Cannot load user settings.\n" + exp4700.Message);
            }
        }
        public void refresh()
        {
            this.Visible = false;
            LoadUser(int_cal.CurrentUser);
            this.Visible = true;
        }
		#endregion

        #region Methods private
        private void initDefaultValues()
        {
            if (int_cal.CurrentTeam != null)
            {
                textBoxCalendarPath.Text = int_cal.BuildFilePath(int_cal.CurrentTeam.FilePath);
                radioButtonPath.Checked = true;
                SetManager();
                SetLevel();
                SetAvatar();
            }
        }
        private void loadNation()
        {
            string strans;
            pictureNation.Image = int_cal.Tsm.Gui.imageListNation.Images[int_cal.Tsm.Gui.imageListNation.Images.IndexOfKey("default")];
            cbNation.Items.Clear();
            foreach (string s in int_cal.Tsm.Gui.imageListNation.Images.Keys)
            {
                strans = s.Replace('_', ' ');
                strans = strans.Substring(0, 1).ToUpper() + strans.Substring(1, strans.Length - 1);
                cbNation.Items.Add(strans);
            }
            
            if (currentUser == null || string.IsNullOrEmpty(currentUser.Country)) cbNation.SelectedItem = cbNation.Items[0];
            else cbNation.Text = currentUser.Country;
        }
        private void loadAvatar()
        {
            string strans;
            pictureAvatar.Image = int_cal.Tsm.Gui.imageListAvatar.Images[int_cal.Tsm.Gui.imageListAvatar.Images.IndexOfKey("default")];
            cbAvatar.Items.Clear();
            foreach (string s in int_cal.Tsm.Gui.imageListAvatar.Images.Keys)
            {
                strans = s.Replace('_', ' ');
                strans = strans.Substring(0, 1).ToUpper() + strans.Substring(1, strans.Length - 1);
                cbAvatar.Items.Add(strans);
            }
            
            if (currentUser == null || string.IsNullOrEmpty(currentUser.Avatar)) cbAvatar.SelectedItem = cbAvatar.Items[0];
            else cbAvatar.Text = currentUser.Avatar;
        }
        private void loadCalendar()
        {
            string strans;
            pictureCalendar.Image = int_cal.Tsm.Gui.imageListCalendar.Images[int_cal.Tsm.Gui.imageListCalendar.Images.IndexOfKey("default")];
            cbCalendar.Items.Clear();
            foreach (string s in int_cal.Tsm.Gui.imageListCalendar.Images.Keys)
            {
                strans = s.Replace('_', ' ');
                strans = strans.Substring(0, 1).ToUpper() + strans.Substring(1, strans.Length - 1);
                cbCalendar.Items.Add(strans);
            }
            
            if (currentUser == null || string.IsNullOrEmpty(currentUser.CalendarFamilly)) cbCalendar.SelectedItem = cbCalendar.Items[0];
            else cbCalendar.Text = currentUser.CalendarFamilly;//.Substring(0, 1).ToUpper() + currentUser.CalendarFamilly.Substring(1, currentUser.CalendarFamilly.Length -1);
        }

        private bool Validation()
        {
            bool ret = true;
            if (string.IsNullOrEmpty(this.textBoxName.Text) || this.textBoxName.Text.Contains("-"))
            {
                this.textBoxName.BackColor = Color.DarkOrange;
                ret = false;
            }
            else this.textBoxName.BackColor = Color.GreenYellow;
            if (string.IsNullOrEmpty(this.textBoxFirstname.Text) || this.textBoxFirstname.Text.Contains("-"))
            {
                this.textBoxFirstname.BackColor = Color.DarkOrange;
                ret = false;
            }
            else this.textBoxFirstname.BackColor = Color.GreenYellow;
            if (string.IsNullOrEmpty(this.textBoxRole.Text) || this.textBoxRole.Text.Contains("-"))
            {
                this.textBoxRole.BackColor = Color.DarkOrange;
                ret = false;
            }
            else this.textBoxRole.BackColor = Color.GreenYellow;
            if (string.IsNullOrEmpty(this.textBoxMatricule.Text) || this.textBoxMatricule.Text.Contains("-"))
            {
                this.textBoxMatricule.BackColor = Color.DarkOrange;
                ret = false;
            }
            else this.textBoxMatricule.BackColor = Color.GreenYellow;

            if (radioButtonPath.Checked)
            {
                if (string.IsNullOrEmpty(this.textBoxCalendarPath.Text))
                {
                    this.textBoxCalendarPath.BackColor = Color.DarkOrange;
                    ret = false;
                }
                else this.textBoxCalendarPath.BackColor = Color.GreenYellow;
            }
            else
            {
                if (string.IsNullOrEmpty(this.textBoxCalendarFile.Text))
                {
                    this.textBoxCalendarFile.BackColor = Color.DarkOrange;
                    ret = false;
                }
                else this.textBoxCalendarFile.BackColor = Color.GreenYellow;
            }
            return ret;
        }
        private void SetManager()
        {
            if (currentUser.Manager > 0)
            {
                pictureManager.Image = int_cal.Tsm.Gui.imageListToolStrip32.Images[int_cal.Tsm.Gui.imageListToolStrip32.Images.IndexOfKey("manager")];
                pictureManager.Visible = true;
            }
            else pictureManager.Visible = false;
        }
        private void SetLevel()
        {
            pictureLevel.Image = int_cal.Tsm.Gui.imageListLevel.Images[int_cal.Tsm.Gui.imageListLevel.Images.IndexOfKey("lvl_" + currentUser.Level + ".png")];
        }
        private void SetAvatar()
        {
            pictureAvatar.Image = int_cal.Tsm.Gui.imageListAvatar.Images[currentUser.Avatar];
            pictureAvatar.Refresh();
        }
        private void ValidateManager()
        {
            if (checkBoxManager.Checked)
            {
                pictureManager.Visible = true;
            }
            else
            {
                pictureManager.Visible = false;
            }
        }
        private string buildUserArrivalDate(User user)
        {
            if (user.ArrivalDate != null)
            {
                if (user.ArrivalDate.Split(' ').Length > 2)
                {
                    int year, month, day;
                    int.TryParse(user.ArrivalDate.Split(' ')[3], out year);
                    int.TryParse(user.ArrivalDate.Split(' ')[1], out day);
                    switch (user.ArrivalDate.Split(' ')[2].ToLower())
                    {
                        case "janvier": month = 1; break;
                        case "fevrier": month = 2; break;
                        case "mars": month = 3; break;
                        case "avril": month = 4; break;
                        case "mai": month = 5; break;
                        case "juin": month = 6; break;
                        case "juillet": month = 7; break;
                        case "aout": month = 8; break;
                        case "septembre": month = 9; break;
                        case "octobre": month = 10; break;
                        case "novembre": month = 11; break;
                        case "decembre": month = 12; break;
                        default: month = 1; break;
                    }
                    DateTime dt = new DateTime(year, month, day);
                    return dt.ToString();
                }
            }
            return "";
        }
        private void BuildAvatarSelection()
        {
            //if (groupBoxAvatar != null) groupBoxAvatar.Dispose();

            //groupBoxAvatar = new GroupBox();
            ////this.groupBoxAvatar.Location = new System.Drawing.Point(5, 250);
            //this.groupBoxAvatar.Location = new System.Drawing.Point(5, 290);
            //this.groupBoxAvatar.Name = "groupBoxKalendar";
            //this.groupBoxAvatar.Size = new System.Drawing.Size(444, 80);
            //this.groupBoxAvatar.TabStop = false;
            //this.groupBoxAvatar.Text = "Change your avatar";

            //Button bt;
            //int indexTop = 24;
            //int indexLeft = 5;
            //int countX = 0;
            //int imgIndex = 0;
            //foreach (Image img in int_cal.Tsm.Gui.imageListAvatar.Images)
            //{
            //    bt = new Button();
            //    bt.FlatStyle = FlatStyle.Flat;
            //    bt.FlatAppearance.BorderSize = 0;
            //    bt.Size = new System.Drawing.Size(32, 32);
            //    bt.BackgroundImage = img;
            //    bt.Top = indexTop;
            //    bt.Left = indexLeft;
            //    bt.Click += new EventHandler(bt_Avatar_Click);
            //    bt.Name = imgIndex.ToString();
            //    imgIndex++;
            //    this.groupBoxAvatar.Controls.Add(bt);
            //    if (countX < 11)
            //    {
            //        countX ++;
            //        indexLeft += 36;
            //    }
            //    else
            //    {
            //        countX = 0;
            //        indexLeft = 5;
            //        indexTop += 35;
            //        this.groupBoxAvatar.Height += 35;
            //    }
            //}
            //this.Controls.Add(this.groupBoxAvatar);
        }
        private void ChangeAvatar(string name)
        {
            currentUser.Avatar = name;
            SetAvatar();
        }
        private void SearchUserPreview()
        {
            string pPath = "";
            switch (MessageBox.Show("do you want to launch camera to take the picture ? ", "Take your picture", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    OpenFileDialog ofd = new OpenFileDialog();
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pPath = ofd.FileName;
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(pPath))
            {
                pictureUser.ImageLocation = pPath;
                currentUser.PicturePath = pPath;
            }
        }
        #endregion

        #region Event
        void pictureUser_Click(object sender, System.EventArgs e)
        {
            SearchUserPreview();
        }
        private void cbNation_TextChanged(object sender, EventArgs e)
        {
            pictureNation.Image = int_cal.Tsm.Gui.imageListNation.Images[int_cal.Tsm.Gui.imageListNation.Images.IndexOfKey(cbNation.Text.Replace(' ', '_').ToLower())];
        }
        private void cbAvatar_TextChanged(object sender, EventArgs e)
        {
            pictureAvatar.Image = int_cal.Tsm.Gui.imageListAvatar.Images[int_cal.Tsm.Gui.imageListAvatar.Images.IndexOfKey(cbAvatar.Text.Replace(' ', '_').ToLower())];
        }
        private void cbCalendar_TextChanged(object sender, EventArgs e)
        {
            pictureCalendar.Image = int_cal.Tsm.Gui.imageListCalendar.Images[int_cal.Tsm.Gui.imageListCalendar.Images.IndexOfKey(cbCalendar.Text.Replace(' ', '_').ToLower())];
        }
        private void checkBoxDroid_CheckedChanged(object sender, System.EventArgs e)
        {
            ValidateManager();
        }
        private void ButtonCancelClick(object sender, EventArgs e)
		{
            int_cal.Pancal.DisplayLasView();
		}
		private void ButtonOKClick(object sender, EventArgs e)
		{
			if (Validation())
			{
				User u = new User(int_cal);
				u.Name = this.textBoxName.Text;
				u.Firstname = this.textBoxFirstname.Text;
				u.Role = this.textBoxRole.Text;
				u.Matricule = this.textBoxMatricule.Text;
                u.My_Team = this.int_cal.CurrentTeam;
                u.CalendarFamilly = this.cbCalendar.Text.Replace(' ', '_').ToLower();
                u.Avatar = cbAvatar.Text.Replace(' ', '_').ToLower();
                u.Country = cbNation.Text.Replace(' ', '_').ToLower();
                u.PicturePath = currentUser.PicturePath;
				
				if (radioButtonPath.Checked)
				{
					u.Kalendar.KalendarPath = this.textBoxCalendarPath.Text + "planning " + this.textBoxName.Text + "-" + this.textBoxFirstname.Text + ".pln";
				}
				else
				{
                    u.Kalendar.KalendarPath = this.textBoxCalendarFile.Text;
				}
				
				u.ArrivalDate = this.dateTimePicker1.Text;
                if (!int_cal.CurrentTeam.Contains(u)) int_cal.CurrentTeam.AddUser(u);
                else int_cal.CurrentTeam.Update(u);
                int_cal.CurrentTeam.CleanTeamDoublons();

                // delete the profile if already exist to insert the new one
                foreach (User utmp in int_cal.CurrentTeam.ListUsers)
                {
                    if (utmp.Equals(u))
                    {
                        int_cal.CurrentTeam.ListUsers.Remove(utmp);
                        break;
                    }
                }


                if (int_cal.CurrentTeam != null)
                {
                    if (!int_cal.CurrentTeam.ListUsers.Contains(u))
                    {
                        int_cal.CurrentTeam.ListUsers.Add(u);
                    }
                    else
                    {
                        // TODO : add an inteligent scan who take the modified element and base the check on fixed one to recognise the modified user
                        foreach (User user_item in int_cal.CurrentTeam.ListUsers)
                        {
                            if (user_item.Matricule.Equals(u.Matricule))
                            {
                                user_item.Copy(u);
                                break;
                            }
                        }
                    }
                }
                int_cal.Save();
                int_cal.Pancal.DisplayLasView();
			}
			else
			{
				this.Text = "You have to inform all the fields";
			}
		}
		private void ButtonBrowseCalendarFileClick(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All user planning files (*.pln)|*.pln|pln files (*.pln)|*.pln" ;
			
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				this.textBoxCalendarFile.Text = ofd.FileName;
			}
		}
		private void ButtonBrowseCalendarPathClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			textBoxCalendarPath.Text = dialog.SelectedPath;
		}
		private void RadioButtonFileCheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonFile.Checked)
			{
				textBoxCalendarFile.Enabled = true;
				buttonBrowseCalendarFile.Enabled = true;
			}
			else
			{
				textBoxCalendarFile.Enabled = false;
				buttonBrowseCalendarFile.Enabled = false;
			}
		}
		private void RadioButtonPathCheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonPath.Checked)
			{
				textBoxCalendarPath.Enabled = true;
				buttonBrowseCalendarPath.Enabled = true;
			}
			else
			{
				textBoxCalendarPath.Enabled = false;
				buttonBrowseCalendarPath.Enabled = false;
			}
		}
		private void bt_Avatar_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            ChangeAvatar(b.Name);
        }
        #endregion
	}
}
