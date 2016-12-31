// Log code 79 12

/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Tools4Libraries;
using System.Text;

namespace Assistant
{
	public delegate void delegateInterfaceCalendar(object sender, EventArgs e);

    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural langage.
    /// </summary>            
    public class Interface_calendar : GPInterface
	{
		#region Attributes
		private List<String> listToolStrip;
		private Panel sheet;
		private ToolStripMenuICAL tsm;
		private PanelCalendar pancal;
		
		private Team currentTeam;
		private int currentUser;
		private string year;
		private List<string> activities;
		private List<string> exportsList;
        private bool exportHeader;
		private string exportFileName;
        private bool newTeamCreated;

		public event delegateInterfaceCalendar TicketClose;
		public event delegateInterfaceCalendar UserLoad;
		public event delegateInterfaceCalendar Disposed;
		public event delegateInterfaceCalendar YearChanged;
		#endregion
		
		#region Properties
		public string ExportFileName
		{
			get { return exportFileName; }
			set { exportFileName = value; }
		}
		public List<string> ExportsList
		{
			get { return exportsList; }
			set { exportsList = value; }			
		}
        public bool ExportHeader
        {
            get { return exportHeader; }
            set { exportHeader = value; }
        }
		public List<string> ListActivities
		{
			get { return activities; }
			set { activities = value; }
			
		}
		public string Year
		{
			get { return year; }
			set
			{
				year = value;
				OnYearChanged(year, null);
			}
		}
		public int YearTop
		{
			get { return Tsm.YearTop; }
		}
		public int YearLeft
		{
			get { return Tsm.YearLeft; }
		}
		public User CurrentUser
		{
			get
			{
                if (CurrentTeam == null) return new User(this);
                else return CurrentTeam.ListUsers[currentUser];
			}
			set
			{
                if (CurrentTeam == null) CurrentTeam = new Team(this);
                if (CurrentTeam.ListUsers.Count < 1) CurrentTeam.ListUsers.Add(value);
                int index = 0;
                foreach (User itemUser in CurrentTeam.ListUsers)
                {
                    if (itemUser != null && itemUser.Equals(value))
                    {
                        currentUser = index;
                        return;
                    }
                    index++;
                }
			}
		}
		public Team CurrentTeam
		{
			get { return currentTeam; }
			set 
            { 
                currentTeam = value;

                tsm.Rb_action_export_fast.ToolTip = BuildFilePath(currentTeam.FilePath);
                tsm.Rb_action_exportDirectory.ToolTip = BuildFilePath(currentTeam.FilePath);
            }
		}
		public PanelCalendar Pancal
		{
			get { return pancal; }
			set { pancal = value; }
		}
		public Panel SheetCalendar
		{
			get { return sheet; }
			set { sheet = value; }
		}
		public new ToolStripMenuICAL Tsm
		{
			get { return tsm; }
			set { tsm = value; }
		}
        public bool NewTeamCreated
        {
            get { return newTeamCreated; }
            set { newTeamCreated = value; }
        }
		#endregion
		
		#region Constructors
		public Interface_calendar(List<String> lts)
		{
            try
            {
                activities = new List<string>();
                exportsList = new List<string>();
                year = DateTime.Now.Year.ToString();
                listToolStrip = lts;
                BuildToolBar();
            }
            catch (Exception exp7911)
            {
                Log.write("[ ERR : 7911 ] Error when creating the calendar interface.\n" + exp7911.Message);
            }
		}
        #endregion

        #region Action
        public static string ACTION_130_affichier_calendrier()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><td>test</td></td>");
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        #endregion

        #region Methods public
        #region Methods Public override
        public bool Open(string type, string my_path)
		{
			if (type.Equals("team"))
			{
                if (CurrentTeam == null || my_path != this.PathFile) CurrentTeam = new Team(this, my_path);
                CurrentTeam.LoadKalendars();
                pancal.LoadTeamPlanning();
                this.Openned = true;
                tsm.RefreshComponent(buildListComponent());
				return true;
			}
			else if (type.Equals("user"))
            {
                try
                {
                    User u = new User(this, my_path);
                    u.LoadKalendar();
                    if (CurrentTeam != null)
                    {
                        User utmp = CurrentTeam.GetUser(u.Firstname + u.Name);
                        if (utmp == null)
                        {
                            CurrentTeam.AddUser(u);
                            u.My_Team = CurrentTeam;
                        }
                        else if (utmp.Equals(u))
                        {
                            MessageBox.Show("The user already is in your team sheet.", "User not added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                    else
                    {
                        User utmp = CurrentTeam.GetUser(u);
                        if (utmp != null)
                        {
                            MessageBox.Show("The user already is in your team sheet.", "User not added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        else
                        {
                            u.My_Team = CurrentTeam;
                            CurrentTeam.AddUser(u);
                        }
                    }
				
                    pancal.LoadUserPlanning();
                    pancal.LoadTeamPlanning();
                    pancal.DisplayTeamPlanning();
                    pancal.BuildPanelTeamCalendar();
                    tsm.RefreshComponent(null);
				    this.Openned = true;
                    tsm.RefreshComponent(buildListComponent());
				
				    return true;
                }
                catch (Exception exp7908)
                {
                    Log.write("[ ERR : 7908 ] The user calendar cannot be load.\n" + exp7908.Message);
                    return false;
                }
			}
			else return false;
		}
		public override void Print()
		{
			
		}
		public override void Close()
		{
			OnDispose(this, null);
		}
		public override bool Save()
		{
			return pancal.SaveAll();
		}
		public override void ZoomIn()
		{
			
		}
		public override void ZoomOut()
		{
			
		}
		public override void Copy()
		{
			
		}
		public override void Cut()
		{
			
		}
		public override void Paste()
		{
			
		}
		public override void Resize()
		{
			pancal.Resize();
		}
		public override void Refresh()
        {
            try
            {
                if (CurrentTeam != null)
                {
                    List<string> list = new List<string>();

                    if (CurrentTeam.ListUsers.Count != 0 && CurrentTeam.ListUsers[currentUser] != null && !string.IsNullOrEmpty(CurrentTeam.ListUsers[currentUser].Kalendar.KalendarPath)) list.Add(CurrentTeam.ListUsers[currentUser].Kalendar.KalendarPath);
                    else list.Add("");

                    list.Add(CurrentTeam.Name);
                    list.Add(CurrentTeam.Service);
                    list.Add(CurrentTeam.Localisation);
                    list.Add(CurrentTeam.Compagny);
                    list.Add(CurrentTeam.Chief);
                    foreach (User u in CurrentTeam.ListUsers)
                    {
                        User utmp = CurrentTeam.GetUser(u.Name + u.Firstname);
                        if (utmp == null)
                        {
                            list.Add(u.Name + "-" + u.Firstname + "|" + u.Kalendar.KalendarPath);
                        }
                        else
                        {
                            // merge of the 2 partial profiles
                            if (utmp.Name == null) utmp.Name = u.Name;
                            if (utmp.Firstname == null) utmp.Firstname = u.Firstname;
                            if (utmp.ArrivalDate == null) utmp.ArrivalDate = u.ArrivalDate;
                            if (utmp.Kalendar == null) utmp.Kalendar = u.Kalendar;
                            if (utmp.Matricule == null) utmp.Matricule = u.Matricule;
                            if (utmp.Role == null) utmp.Role = u.Role;
                            list.Add(utmp.Name + "-" + utmp.Firstname + "|" + utmp.Kalendar.KalendarPath);
                        }
                    }

                    tsm.RefreshComponent(list);
                    if (pancal.SelectedPanel.Equals("team")) pancal.LoadTeamPlanning();
                    else if (pancal.SelectedPanel.Equals("user")) pancal.LoadUserPlanning();
                }
            }
            catch (Exception exp7909)
            {
                Log.write("[ ERR : 7909 ] Error during the refresh of the calendar.\n" + exp7909.Message);
            }
		}
		public override void GlobalAction(object sender, EventArgs e)
		{
			ToolBarEventArgs tbea = e as ToolBarEventArgs;
			string action = tbea.EventText;
			GoAction(action);
		}
		//public override System.Windows.Forms.RibbonTab BuildToolBar()
		//{
		//	tsm = new Assistant.ToolStripMenuICAL(listToolStrip);
		//	return tsm;
		//}
		#endregion
		
		public void GoAction(string act)
		{
			switch (act.ToLower())
			{
                case "action_export_directory":
                    LaunchActionExportDirectory();
                    break;
				case "action_export" :
					LaunchActionExport();
					break;
				case "action_export_fast" :
					LaunchActionExportFast();
					break;
				case "action_settings" :
					LaunchActionSettings();
					break;
				case "action_change_year" :
					LaunchActionChangeYear();
					break;
				case "user_delete":
					LaunchTeamUserDelete();
					break;
                case "user_change":
                    if (pancal.SelectedPanel.Equals("userSetting")) LaunchUserEdit();
                    else LaunchUserCalendar();
					break;
				case "team_calendar":
					LaunchTeamCalendar();
                    break;
                case "team_new":
                    LaunchTeamEdit();
                    break;
                case "team_open":
                    LaunchTeamOpen();
                    break;
                case "team_edit":
                    LaunchTeamEdit();
                    break;
                case "user_edit":
                    LaunchUserEdit();
                    break;
                case "team_new_user":
                    LaunchTeamNewUser();
                    break;
                case "team_add_user":
                    LaunchTeamAddUser();
                    break;
                case "team_del_user":
                    LaunchTeamUserDelete();
					break;
                case "user_calendar":
                    LaunchUserCalendar();
                    break;
			}
		}
		public void BuildPanel()
		{
			pancal = new PanelCalendar(this);
			tsm.CurrentTabPage.Controls.Add(pancal);
		}
		public void LoadTeam()
		{
			pancal.LoadTeamPlanning();
        }
		public bool SaveTeam()
		{
			return CurrentTeam.SaveTeam(CurrentTeam);
		}
		public bool GoExport(DateTime start, DateTime end, string path)
		{
            try
            {
                if (CurrentTeam.ListUsers.Count > 0)
                {
                    int month_num = start.Month;
                    int year = start.Year;
                    string output = "";
                    string act = "";
                    Kalendar kal;
                    foreach (string s in ExportsList)
                    {
                        output += s + ";";
                    }
                    output += "\n";
                    foreach (User current_user in CurrentTeam.ListUsers)
                    {
                        kal = current_user.Kalendar;
                        for (int day = start.Day; (day < DateTime.DaysInMonth(year, month_num) && day < end.Day); day++)
                        {
                            act = kal.Get(month_num, day, year.ToString(), "oncall");
                            if (!string.IsNullOrEmpty(act) && act.ToLower().Equals("x"))
                            {
                                foreach (string s in ExportsList)
                                {
                                    switch (s.ToLower())
                                    {
                                        case "team service":
                                            output += current_user.My_Team.Service + ";";
                                            break;
                                        case "team localisation":
                                            output += current_user.My_Team.Localisation + ";";
                                            break;
                                        case "team chief":
                                            output += current_user.My_Team.Chief + ";";
                                            break;
                                        case "team compagny":
                                            output += current_user.My_Team.Compagny + ";";
                                            break;
                                        case "user name":
                                            output += current_user.Name + ";";
                                            break;
                                        case "user firstname":
                                            output += current_user.Firstname + ";";
                                            break;
                                        case "user matricule":
                                            output += current_user.Matricule + ";";
                                            break;
                                        case "start date":
                                            output += day + "/" + month_num + "/" + year + ";";
                                            break;
                                        case "start time":
                                            output += "19:00" + ";";
                                            break;
                                        case "end date":
                                            if (day.Equals(DateTime.DaysInMonth(year, month_num)))
                                            {
                                                if (month_num == 12) output += "1/1/" + (year+1) + ";";
                                                else output += 1 + "/" + month_num + 1 + "/" + year + ";";
                                            }
                                            else
                                            {
                                                output += (day+1) + "/" + month_num + "/" + year + ";";
                                            }
                                            break;
                                        case "end time":
                                            output += "08:00" + ";";
                                            break;
                                    }
                                }
                                output += "\n";
                            }
                        }
                    }

                    string finalFile = BuildFilePath(path) + ExportFileName;
                    using (StreamWriter outfile = new StreamWriter(finalFile))
                    {
                        outfile.Write(output);
                    }
                    Dialog.Push("Export done.\nYou can find it here :\n\n" + finalFile);
                    return true;
                }
                else
                {
                    MessageBox.Show("You should have member in your team first !", "Not enough members", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception exp7910)
            {
                Log.write("[ ERR : 7910 ] Error occured during the export file creation.\n" + exp7910.Message);
                return false;
            }
		}
        public string BuildFilePath(string path)
        {
            try
            {
                string s = "";
                for (int i = 0; i < (path.Split('\\').Length - 1); i++)
                {
                    s += path.Split('\\')[i] + '\\';
                }
                return s;
            }
            catch (Exception exp7912)
            {
                Log.write("[ ERR : 7912 ] Cannot create the export path.\n" + exp7912.Message);
                return "";
            }
        }
		#endregion
		
		#region Methods private
		#region Launch
        private void LaunchActionExportDirectory()
        {
            string myDocspath = BuildFilePath(CurrentTeam.FilePath);
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = windir + @"\explorer.exe";
            prc.StartInfo.Arguments = myDocspath;
            prc.Start();
        }
		private void LaunchActionExport()
		{
			FormExport fe = new FormExport(this);
			fe.ShowDialog();
		}
		private void LaunchActionExportFast()
		{
			DateTime first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			DateTime last = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
			GoExport(first, last, this.CurrentTeam.FilePath);
		}
		private void LaunchActionSettings()
		{
            CurrentUser = CurrentTeam.GetUser(Tsm.currentUserText);
            pancal.LoadUserPlanning();
            pancal.DisplayCalendarSetting();
		}
		private void LaunchActionChangeYear()
		{
			Year = tsm.rb_action_year.SelectedItem.Text;
		}
		private void LaunchTeamUserDelete()
		{
            LaunchTeamEdit();
		}
		private void LaunchTeamCalendar()
		{
			if (CurrentTeam != null)
			{
				CurrentTeam.LoadKalendars();
				pancal.DisplayTeamPlanning();
				
				this.Openned = true;
				Refresh();
			}
		}
		private void LaunchTeamAddUser()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.FileName = "";
            ofd.RestoreDirectory = true;
            ofd.Filter = "calendar files (*.pln)|*.pln|All files (*.*)|*.*"; ;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.Open("user", ofd.FileName))
                    {
                        this.Refresh();
                    }
                }
                catch (Exception exp7905)
                {
                    Log.write("[ ERR : 7905 ] The file cannot be read.\n" + exp7905.Message);
                }
            }

            if (CurrentTeam != null && CurrentTeam.ListUsers.Count > 0 && !string.IsNullOrEmpty(CurrentTeam.Name) && CurrentTeam.ListUsers[currentUser] != null)
            {
                if(CurrentTeam.LoadKalendars())
                {
                    pancal.DisplayTeamPlanning();
                    this.Openned = true;
                }
            }
		}
		private void LaunchTeamOpen()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Multiselect = false;
			ofd.FileName = "";
			ofd.RestoreDirectory = true;
			ofd.Filter = "calendar files (*.team)|*.team|All files (*.*)|*.*" ;
			
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.PathFile = ofd.FileName;
					this.Open("team", this.PathFile);
                }
				catch (Exception exp7901)
				{
					Log.write("[ ERR : 7901 ] The file cannot be read.\n" + exp7901.Message);
				}
			}
		}
        private void LaunchTeamNewUser()
        {
            User u = new User(this);
            CurrentTeam.AddUser(u);
            currentUser = CurrentTeam.ListUsers.Count - 1;
            pancal.DisplayUserSetting();
        }
        private void LaunchUserEdit()
        {
            CurrentUser = CurrentTeam.GetUser(Tsm.currentUserText);
            pancal.DisplayUserSetting();
        }
        private void LaunchTeamEdit()
        {
            pancal.LoadTeamPlanning();
            pancal.DisplayTeamSetting();
        }
		private void LaunchTeamClosure()
        {
            DialogResult answer = MessageBox.Show("Do you want to close the calendar sheet ?", "Calendar closure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (answer.Equals(DialogResult.Yes))
            {
                //this.tsm.Rb_team_add_user.Enabled = false;
                //this.tsm.Rb_team_new_user.Enabled = false;
                //this.tsm.Rb_team_close.Enabled = false;
            }
		}
        private void LaunchUserCalendar()
        {
            CurrentUser = CurrentTeam.GetUser(Tsm.currentUserText);
            pancal.LoadUserPlanning();
            pancal.DisplayUserPlanning();
        }
		#endregion
		
		private string reportDay(List<string> exports, User current_user, int day_num, int month_num, bool flag)
		{
			string ret = "";
			foreach (string element in exports)
			{
				switch (element.ToLower())
				{
					case "start date" :
						{
							ret += day_num + "/" + month_num + "/" + year + ";";
							break;
						}
					case "start hour" :
						{
							if (flag) ret += "08:00;";
							else ret += "19:00;";
							break;
						}
					case "end date" :
						{
							if (flag) ret += day_num + "/" + month_num + "/" + year + ";";
							else ret += day_num+1 + "/" + month_num + "/" + year + ";";
							break;
						}
					case "end hour" :
						{
							if (flag) ret += "19:00;";
							else ret += "08:00;";
							break;
						}
					case "user matricule" :
						{
							ret += current_user.Matricule + ";";
							break;
						}
					case "user name" :
						{
							ret += current_user.Name + ";";
							break;
						}
					case "user firstname" :
						{
							ret += current_user.Firstname + ";";
							
                            break;
						}
					case "user role" :
						{
							ret += current_user.Role + ";";
							break;
						}
					case "team chief" :
						{
							ret += current_user.My_Team.Chief + ";";
							break;
						}
					case "team service" :
						{
							ret += current_user.My_Team.Service + ";";
							break;
						}
					case "team localisation" :
						{
							ret += current_user.My_Team.Localisation + ";";
							break;
						}
					case "team name" :
						{
							ret += current_user.My_Team.Name + ";";
							break;
						}
				}
			}
			ret += "\n";
			return ret;
		}
        private List<string> buildListComponent()
        {
            List<string> ls = new List<string>();
            ls.Add(CurrentTeam.FilePath);
            ls.Add(CurrentTeam.Name);
            ls.Add(CurrentTeam.Service);
            ls.Add(CurrentTeam.Localisation);
            ls.Add(CurrentTeam.Compagny);
            ls.Add(CurrentTeam.Chief);
            foreach (User u in CurrentTeam.ListUsers)
            {
                ls.Add(u.Name + "-" + u.Firstname + "|" + u.Kalendar.KalendarPath);
            }
            return ls;
        }
		#endregion
		
		#region Methods protected
		protected virtual void OnTicketClose(object sender, EventArgs e)
		{
			if (TicketClose != null)
				TicketClose(sender, e);
		}
		protected virtual void OnDispose(object sender, EventArgs e)
		{
			if (Disposed != null)
				Disposed(sender, e);
		}
		protected virtual void OnYearChanged(object sender, EventArgs e)
		{
			if (YearChanged != null)
				YearChanged(sender, e);
		}
		public virtual void OnLoad(object sender, EventArgs e)
		{
			if (UserLoad != null)
				UserLoad(sender, e);
		}
		#endregion
	}
}