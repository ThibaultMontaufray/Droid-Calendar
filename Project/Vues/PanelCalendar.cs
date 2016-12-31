// LOG CODE 62 00
/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Tools4Libraries;

namespace Assistant
{
	/// <summary>
	/// Description of PanelCalendar.
	/// </summary>
	public class PanelCalendar : Panel
	{
		#region Attribute
		private Interface_calendar interface_cal;
        private PanelCalendarUser pan_userCal;
        private PanelCalendarTeam pan_teamCal;
        private PanelSetting pan_calSetting;
        private PanelTeam pan_teamSetting;
        private PanelUser pan_userSetting;
		private string selectedButton;
        private string lastView;
		#endregion
		
		#region Properties
        public string SelectedPanel
        {
            get { return selectedButton; }
            set { selectedButton = value; }
        }
		public PanelCalendarUser PanelUserCalendar
		{
			get { return pan_userCal; }
			set { pan_userCal = value; }
		}
		public PanelCalendarTeam PanelTeamCalendar
		{
			get { return pan_teamCal; }
			set { pan_teamCal = value; }
		}
        public PanelSetting PanelCalendarSetting
        {
            get { return pan_calSetting; }
            set { pan_calSetting = value; }
        }
        public PanelTeam PanelTeamSetting
        {
            get { return pan_teamSetting; }
            set { pan_teamSetting = value; }
        }
        public PanelUser PanelUserSetting
        {
            get { return pan_userSetting; }
            set { pan_userSetting = value; }
        }
		private string SelectedMenu
		{
			get { return selectedButton; }
			set { selectedButton = value; }
		}
		private ToolStripMenuICAL tsm
		{
			get { return interface_cal.Tsm as ToolStripMenuICAL; }
		}
		#endregion
		
		#region Constructor
		public PanelCalendar(Interface_calendar ic)
		{
            try
            {
                interface_cal = ic;
                InitializeComponent();
                selectedButton = "team";
            }
            catch (Exception exp6200)
            {
                Log.write("[ ERR : 6200 ] Error occured during the construction of the calendar panel.\n" + exp6200.Message);
            }
		}
		#endregion
		
		#region Methods Public
		public new void Resize()
		{
			this.Width = tsm.CurrentTabPage.Width;
			this.Height = tsm.CurrentTabPage.Height;
			
			pan_userCal.refresh();
		}
		public void DisplayTeamPlanning()
        {
            lastView = selectedButton;
			selectedButton = "team";
			ActivationPanel();
		}
		public void DisplayUserPlanning()
		{
			selectedButton = "user";
			ActivationPanel();
		}
        public void DisplayCalendarSetting()
        {
            lastView = selectedButton;
            selectedButton = "calSetting";
            ActivationPanel();
        }
        public void DisplayTeamSetting()
        {
            lastView = selectedButton;
            selectedButton = "teamSetting";
            ActivationPanel();
        }
        public void DisplayUserSetting()
        {
            lastView = selectedButton;
            selectedButton = "userSetting";
            ActivationPanel();
        }
        public void DisplayLasView()
        {
            if (string.IsNullOrEmpty(lastView) || lastView == selectedButton)
            {
                lastView = "team";
            }
            selectedButton = lastView;
            ActivationPanel();
        }
        public void LoadUserPlanning()
		{
			if (interface_cal.CurrentUser != null) pan_userCal.LoadKalendar();
			DisplayUserPlanning();
		}
		public void LoadTeamPlanning()
		{
			if (interface_cal.CurrentTeam != null) pan_teamCal.LoadKalendar();
			DisplayTeamPlanning();
            pan_teamCal.SelectCurrentRow();
		}
		public bool SaveAll()
		{
			bool b = false;
			SaveTeam(interface_cal.CurrentTeam);
			if (interface_cal.CurrentTeam != null)
			{
                b = true;
				foreach (User u in interface_cal.CurrentTeam.ListUsers)
				{
                    // TODO : PERFORMANCE IMPROVMENT
					//if (u.Modified) 
                    b = SaveUserPlanning(u);
				}
			}
			else if (interface_cal.CurrentUser != null)
			{
				if (interface_cal.CurrentUser.Modified) b = SaveUserPlanning(interface_cal.CurrentUser);
			}
			return b;
		}
		public void ActivationPanel()
		{
			this.Controls.Clear();
			switch (selectedButton)
            {
                case "user":
                    this.Controls.Add(pan_userCal);
                    pan_userCal.refresh();
                    break;
				case "team" :
					this.Controls.Add(pan_teamCal);
					pan_teamCal.refresh();
                    break;
                case "calSetting":
                    this.Controls.Add(pan_calSetting);
                    pan_calSetting.refresh();
                    break;
                case "userSetting":
                    this.Controls.Add(pan_userSetting);
                    pan_userSetting.refresh();
                    break;
                case "teamSetting":
                    this.Controls.Add(pan_teamSetting);
                    pan_teamSetting.refresh();
                    break;
			}
		}
		public void BuildPanelUserCalendar()
		{
			pan_userCal = new PanelCalendarUser(interface_cal);
			pan_userCal.Dock = DockStyle.Fill;
		}
		public void BuildPanelTeamCalendar()
		{
			pan_teamCal = new PanelCalendarTeam(interface_cal);
			pan_teamCal.Dock = DockStyle.Fill;
		}
        public void BuildPanelCalendarSetting()
        {
            pan_calSetting = new PanelSetting(interface_cal);
            pan_calSetting.Dock = DockStyle.Fill;
        }
        public void BuildPanelTeamSetting()
        {
            pan_teamSetting = new PanelTeam(interface_cal);
            pan_teamSetting.Dock = DockStyle.Fill;
        }
        public void BuildPanelUserSetting()
        {
            pan_userSetting = new PanelUser(interface_cal);
            pan_userSetting.Dock = DockStyle.Fill;
        }
        #endregion
		
		#region Methods Private
		private bool SaveUserPlanning(User u)
		{
			return u.SaveKalendar();
		}
		private bool SaveTeam(Team t)
		{
			if (string.IsNullOrEmpty(t.FilePath))
			{
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.RestoreDirectory = true ;

				if(saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					t.FilePath = saveFileDialog1.FileName;
				}
				else
				{
					return false;
				}
			}
			t.SaveTeam(t);
			return true;
		}
		private void InitializeComponent()
		{
			this.Width = tsm.CurrentTabPage.Width;
			this.Height = tsm.CurrentTabPage.Height;
			this.Dock = DockStyle.Fill;
			
			BuildPanelUserCalendar();
			BuildPanelTeamCalendar();
            BuildPanelCalendarSetting();
            BuildPanelTeamSetting();
            BuildPanelUserSetting();
		}
		#endregion
		
		#region Event
		#endregion
	}
}