// Log code 29 - 04

/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Tools4Libraries;

namespace Assistant
{
	/// <summary>
	/// Description of FormTeam.
	/// </summary>
	public partial class PanelTeam : Panel
	{
		#region Attributes
		private Interface_calendar int_cal;
		private List<User> listUsers;
        private string currentChief;
		private DataGridView dgv;
		
		private System.Windows.Forms.DataGridViewButtonColumn ColumnEdit;
		private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
		#endregion
		
		#region Properties
		public List<User> ListUsers
		{
			get { return listUsers;	}
			set { listUsers = value; }
		}
		#endregion
		
		#region Constructor
		public PanelTeam(Interface_calendar ic)
		{
            currentChief = string.Empty;
            int_cal = ic;
            LoadTeam(int_cal.CurrentTeam);
			listUsers = new List<User>();
			InitializeComponent();
			BuildDGV();
			radioButtonPath.CheckedChanged += new EventHandler(RadioButtonPathCheckedChanged);
			radioButtonFile.CheckedChanged += new EventHandler(RadioButtonFileCheckedChanged);
		}
		public PanelTeam(Interface_calendar ic, Team team)
        {
            currentChief = string.Empty;
            int_cal = ic;
			listUsers = new List<User>();
			InitializeComponent();
			BuildDGV();
			LoadTeam(team);
		}
		#endregion
		
		#region Methods public
		public void LoadTeam(Team t)
		{
			if (t != null)
			{
				this.textBoxName.Text = t.Name;
				this.textBoxLocalisation.Text = t.Localisation;
				this.textBoxService.Text = t.Service;
				this.comboBoxChief.Text = t.Chief;
				this.textBoxCompagny.Text = t.Compagny;
				this.textBoxCalendarFile.Text = t.FilePath;
                if (!string.IsNullOrEmpty(this.textBoxCalendarFile.Text)) this.radioButtonFile.Select();
                else this.radioButtonPath.Select();
                if (listUsers != null && listUsers.Count == 0 ) t.CopyUsersTo(this.listUsers);
				LoadUsers();
			}
		}
		public void LoadUsers()
		{
			bool modulo = false;
			comboBoxChief.Items.Clear();

			if (listUsers != null)
			{
                dgv.Rows.Clear();
				foreach (User u in listUsers)
				{
					modulo = !modulo;
					
					dgv.Rows.Add();
					dgv.Rows[dgv.Rows.Count-1].Cells[0].Value = u.Name;
					dgv.Rows[dgv.Rows.Count-1].Cells[1].Value = u.Firstname;
					dgv.Rows[dgv.Rows.Count-1].Cells[2].Value = u.Matricule;
					dgv.Rows[dgv.Rows.Count-1].Cells[3].Value = "edit";
					dgv.Rows[dgv.Rows.Count-1].Cells[4].Value = "del";
					dgv.BackColor = groupBoxUsers.BackColor;
					
					comboBoxChief.Items.Add(u.Name + "-" + u.Firstname);
					
					if(modulo)
					{
						dgv.Rows[dgv.Rows.Count-1].Cells[0].Style.BackColor = Color.LightBlue;
						dgv.Rows[dgv.Rows.Count-1].Cells[1].Style.BackColor = Color.LightBlue;
						dgv.Rows[dgv.Rows.Count-1].Cells[2].Style.BackColor = Color.LightBlue;
						dgv.Rows[dgv.Rows.Count-1].Cells[3].Style.BackColor = Color.LightBlue;
						dgv.Rows[dgv.Rows.Count-1].Cells[4].Style.BackColor = Color.LightBlue;
					}
					else
					{
						dgv.Rows[dgv.Rows.Count-1].Cells[0].Style.BackColor = Color.WhiteSmoke;
						dgv.Rows[dgv.Rows.Count-1].Cells[1].Style.BackColor = Color.WhiteSmoke;
						dgv.Rows[dgv.Rows.Count-1].Cells[2].Style.BackColor = Color.WhiteSmoke;
						dgv.Rows[dgv.Rows.Count-1].Cells[3].Style.BackColor = Color.WhiteSmoke;
						dgv.Rows[dgv.Rows.Count-1].Cells[4].Style.BackColor = Color.WhiteSmoke;
					}
				}
			}
			dgv.Update();
		}
        public void refresh()
        {
            this.Visible = false;
            LoadTeam(int_cal.CurrentTeam);
            this.Visible = true;
        }
		#endregion
		
		#region Methods private
		private void BuildDGV()
		{
			DataGridViewCell cellTemplateClassic = new DataGridViewTextBoxCell();
			cellTemplateClassic.Style.Font = new Font("Calibri", 8, FontStyle.Regular);
			DataGridViewColumn column;

            if (dgv != null) dgv.Rows.Clear();
			dgv = new DataGridView();
			dgv.Height = 200;
			dgv.Top = 50;
			dgv.Left = 7;
			dgv.Width = 444;
			dgv.AllowDrop = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeColumns = false;
			dgv.AllowUserToResizeRows = false;
            dgv.Dock = DockStyle.Fill;
            dgv.BackgroundColor = Color.Gray;
			
			column = new DataGridViewColumn(cellTemplateClassic);
			column.Name = "name";
			column.HeaderText = "Name";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns.Add(column);
			
			column = new DataGridViewColumn(cellTemplateClassic);
			column.Width = 130;
			column.Name = "firstname";
			column.HeaderText = "Firstname";
			dgv.Columns.Add(column);
			
			column = new DataGridViewColumn(cellTemplateClassic);
			column.Width = 90;
			column.Name = "matricule";
			column.HeaderText = "Matricule";
			dgv.Columns.Add(column);
			
			ColumnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
			ColumnEdit.Width = 34;
			ColumnEdit.Name = "edit";
			ColumnEdit.HeaderText = "Edit";
            //ColumnEdit.FlatStyle = FlatStyle.Flat;
            dgv.Columns.Add(ColumnEdit);
			
			ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
			ColumnDelete.Width = 34;
			ColumnDelete.Name = "del";
			ColumnDelete.HeaderText = "Del";
            //ColumnDelete.FlatStyle = FlatStyle.Flat;
            dgv.Columns.Add(ColumnDelete);
			
			dgv.RowHeadersVisible = false;
			dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
			
			groupBoxUsers.Controls.Add(dgv);
		}
		private bool Validation()
		{
			bool ret = true;
			
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				textBoxName.BackColor = Color.DarkOrange;
				ret = false;
			}
			else textBoxName.BackColor = Color.GreenYellow;
			if (string.IsNullOrEmpty(comboBoxChief.Text))
			{
				comboBoxChief.BackColor = Color.LightGray;
				//ret = false;
			}
			else comboBoxChief.BackColor = Color.GreenYellow;
			if (string.IsNullOrEmpty(textBoxCompagny.Text))
			{
				textBoxCompagny.BackColor = Color.DarkOrange;
				ret = false;
			}
			else textBoxCompagny.BackColor = Color.GreenYellow;
			if (string.IsNullOrEmpty(textBoxLocalisation.Text))
			{
				textBoxLocalisation.BackColor = Color.DarkOrange;
				ret = false;
			}
			else textBoxLocalisation.BackColor = Color.GreenYellow;
			if (string.IsNullOrEmpty(textBoxService.Text))
			{
				textBoxService.BackColor = Color.DarkOrange;
				ret = false;
			}
			else textBoxService.BackColor = Color.GreenYellow;
			if (listUsers.Count < 1)
			{
				dgv.BackgroundColor = Color.LightGray;
				//ret = false;
			}
			else dgv.BackgroundColor = Color.GreenYellow;
			
			if (radioButtonPath.Checked)
			{
				textBoxCalendarFile.BackColor = Color.LightGray;
				if (string.IsNullOrEmpty(textBoxCalendarPath.Text))
				{
					textBoxCalendarPath.BackColor = Color.DarkOrange;
					ret = false;
				}
				else textBoxCalendarPath.BackColor = Color.GreenYellow;
			}
			else
			{
				textBoxCalendarPath.BackColor = Color.LightGray;
				if (string.IsNullOrEmpty(textBoxCalendarFile.Text))
				{
					textBoxCalendarFile.BackColor = Color.DarkOrange;
					ret = false;
				}
				else textBoxCalendarFile.BackColor = Color.GreenYellow;
			}
			
			return ret;
		}
		#endregion
		
		#region Event
		private void ButtonCancelClick(object sender, EventArgs e)
        {
            int_cal.Pancal.DisplayLasView();
        }
		private void ButtonOKClick(object sender, EventArgs e)
		{
			if (Validation())
			{
				Team t = new Team(int_cal);
				t.Name = this.textBoxName.Text;
				t.Service = this.textBoxService.Text;
				t.Localisation = this.textBoxLocalisation.Text;
				t.Compagny = this.textBoxCompagny.Text;
				t.Chief = this.comboBoxChief.Text.ToString();
				
				if (radioButtonPath.Checked)
				{
					t.FilePath = this.textBoxCalendarPath.Text + "\\Team_" + textBoxName.Text + ".team";
				}
				else
				{
					t.FilePath = this.textBoxCalendarFile.Text;
				}
				
				t.ListUsers = listUsers;
				
                //radioButtonPath.Checked = false;
                //radioButtonFile.Checked = true;
                textBoxCalendarPath.Enabled = false;
                textBoxCalendarFile.Enabled = true;
                buttonBrowseCalendarPath.Enabled = false;
                buttonBrowseCalendarFile.Enabled = true; 
                
				int_cal.CurrentTeam = t;
                int_cal.NewTeamCreated = true;
                if (t.SaveTeam(t))
                {
                    int_cal.Pancal.SelectedPanel = "team";
                    int_cal.Refresh();
                }
                else
                {
                    MessageBox.Show("Oups, we cannot save your file.\nPlease modify some parameters (file path, ...) and try again.", "Error while saving your file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
		}
		private void ButtonAddUserClick(object sender, EventArgs e)
		{
			PanelUser fu = new PanelUser(int_cal, this);
            LoadUsers();
		}
		private void ButtonBrowseCalendarPathClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			textBoxCalendarPath.Text = dialog.SelectedPath;
		}
		private void ButtonBrowseCalendarFileClick(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "All team files (*.team)|*.team|team files (*.team)|*.team" ;
			
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				this.textBoxCalendarFile.Text = ofd.FileName;
			}
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
		private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flagFail = true;
			try
			{
				if(dgv.Columns[dgv.CurrentCellAddress.X].Name.ToLower().Contains("del"))
				{
					foreach (User user in listUsers)
					{
                        if (user.Firstname == null && user.Name == null)
                        {
                            listUsers.Remove(user);
                            if (int_cal.CurrentTeam.Chief.Equals(user.Name + "-" + user.Firstname))
                            {
                                this.comboBoxChief.Items.Remove(int_cal.CurrentTeam.Chief);
                                this.comboBoxChief.Text = "";
                            }
                            flagFail = false;
                            break;
                        }
                        else if (user.Name.Equals(dgv.Rows[dgv.CurrentCellAddress.Y].Cells[0].Value.ToString()) && user.Firstname.Equals(dgv.Rows[dgv.CurrentCellAddress.Y].Cells[1].Value.ToString()))
                        {
                            listUsers.Remove(user);
                            if (int_cal.CurrentTeam.Chief.Equals(user.Name + "-" + user.Firstname))
                            {
                                this.comboBoxChief.Items.Remove(int_cal.CurrentTeam.Chief);
                                this.comboBoxChief.Text = "";
                            } 
                            flagFail = false;
                            break;
                        }
					}
					dgv.Rows.Remove(dgv.Rows[dgv.CurrentCellAddress.Y]);
				}
				else if(dgv.Columns[dgv.CurrentCellAddress.X].Name.ToLower().Contains("edit"))
				{
					string s = dgv.Rows[dgv.CurrentCellAddress.Y].Cells[0].Value.ToString() + "-" + dgv.Rows[dgv.CurrentCellAddress.Y].Cells[0].Value.ToString();
					int_cal.CurrentUser = int_cal.CurrentTeam.GetUser(s);
					if (int_cal.CurrentUser != null)
					{
						PanelUser fu = new PanelUser(int_cal, int_cal.CurrentUser);
						flagFail = false;
					}
					else
					{
						foreach (User user in listUsers)
						{
							if ((user != null) && user.Name.Equals(dgv.Rows[dgv.CurrentCellAddress.Y].Cells[0].Value.ToString()) && user.Firstname.Equals(dgv.Rows[dgv.CurrentCellAddress.Y].Cells[1].Value.ToString()))
							{
								PanelUser fu = new PanelUser(int_cal, user);
								flagFail = false;
								break;
							}
						}
					}
				}
				if (flagFail) MessageBox.Show("[ ERR : 2904 ] Sorry, we got an issue and cannot open the user description.");
			}
			catch (Exception exp2903)
			{
				Log.write("[ WRN : 2903 ] " + exp2903.Message);
			}
		}
		#endregion
	}
}
