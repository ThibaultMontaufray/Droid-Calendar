// LOG CODE 60 00
/*
 * Created by SharpDevelop.
 * User: C357555
 * Date: 15/11/2011
 * Time: 14:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Tools4Libraries;

namespace Assistant
{
	/// <summary>
	/// Description of ToolStripMenuICAL.
	/// </summary>
	public class ToolStripMenuICAL : ToolStripMenuManager
	{
        #region Attributes
        public event EventHandlerAction ActionAppened;
		private GUI gui;
		private string lastUser;

        private RibbonButton rb_team_new;
        private RibbonButton rb_team_open;
        private RibbonButton rb_team_add_user;
        private RibbonButton rb_team_new_user;
        private RibbonButton rb_team_close;
		
		private RibbonButton rb_view_kalUser;
        private RibbonButton rb_view_kalTeam;
        private RibbonButton rb_view_calendarSettings;
        private RibbonButton rb_view_UserSetting;
        private RibbonButton rb_view_TeamSetting;

        public RibbonComboBox rb_action_year;
		private RibbonButton rb_action_oncall;
		private RibbonButton rb_action_hotline;
		private RibbonButton rb_action_export_fast;
		private RibbonButton rb_action_export;
        private RibbonButton rb_action_exportDirectory;
		
		private RibbonButton rb_team_name;
		private RibbonButton rb_team_service;
		private RibbonButton rb_team_location;
		private RibbonButton rb_team_compagny;
		private RibbonButton rb_team_chief;
		private RibbonButton rb_team_user;
		private RibbonComboBox rb_team_listusers;

        private RibbonPanel panelViews;
        private RibbonPanel panelSettings;
        private RibbonPanel panelTeam;
        private RibbonPanel panelExports;
		private RibbonPanel panelTeamInformations;

        private List<string> LastListComponents;
		#endregion
		
		#region Properties
		public GUI Gui
		{
			get { return gui; }
			set { gui = value; }
		}
		public int YearTop
		{
			get { return 100; }
		}
		public int YearLeft
		{
			get { return 300; }
		}
		public string currentUserText
		{
			get { return rb_team_listusers.SelectedItem.Text; }
			set { rb_team_listusers.SelectedItem.Text = value; }
		}

        public RibbonButton Rb_action_exportDirectory
        {
            get { return rb_action_exportDirectory; }
            set { rb_action_exportDirectory = value; }
        }
        public RibbonButton Rb_action_export_fast
        {
            get { return rb_action_export_fast; }
            set { rb_action_export_fast = value; }
        }
        public RibbonButton Rb_team_add_user
        {
            get { return rb_team_add_user; }
            set { rb_team_add_user = value; }
        }
        public RibbonButton Rb_team_new_user
        {
            get { return rb_team_new_user; }
            set { rb_team_new_user = value; }
        }
        public RibbonButton Rb_team_close
        {
            get { return rb_team_close; }
            set { rb_team_close = value; }
        }
        public RibbonComboBox Rb_team_listusers
        {
            get { return rb_team_listusers; }
        }
		#endregion
		
		#region Constructor
		public ToolStripMenuICAL(List<string> theList)
		{
            try
            {
                gui = new GUI();
                lastUser = "";

                rb_team_new = new RibbonButton("New");
                rb_team_new.Click += new EventHandler(ts_team_new_Click);
                rb_team_new.Image = gui.imageListToolStrip32.Images[gui.imageListToolStrip32.Images.IndexOfKey("team_new")];

                rb_team_open = new RibbonButton("Open");
                rb_team_open.Click += new EventHandler(ts_team_open_Click);
                rb_team_open.Image = gui.imageListToolStrip32.Images[gui.imageListToolStrip32.Images.IndexOfKey("team_open")];

                rb_team_add_user = new RibbonButton("Add user");
                rb_team_add_user.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_add_user.Click += new EventHandler(ts_team_add_user_Click);
                rb_team_add_user.Enabled = false;
                rb_team_add_user.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("team_add_user")];

                rb_team_new_user = new RibbonButton("New user");
                rb_team_new_user.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_new_user.Click += new EventHandler(ts_team_new_user_Click);
                rb_team_new_user.Enabled = false;
                rb_team_new_user.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("team_new_user")];

                rb_team_close = new RibbonButton("Remove user");
                rb_team_close.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_close.Click += new EventHandler(ts_team_close_Click);
                rb_team_close.Enabled = false;
                rb_team_close.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("team_del_user")];

                rb_action_year = new RibbonComboBox();
                rb_action_year.TextBoxWidth = 50;
                RibbonLabel rl;

                rl = new RibbonLabel();
                rl.Text = (DateTime.Now.Year - 3).ToString();
                rb_action_year.DropDownItems.Add(rl);
                rl = new RibbonLabel();
                rl.Text = (DateTime.Now.Year - 2).ToString();
                rb_action_year.DropDownItems.Add(rl);
                rl = new RibbonLabel();
                rl.Text = (DateTime.Now.Year - 1).ToString();
                rb_action_year.DropDownItems.Add(rl);
                rl = new RibbonLabel();
                rl.Text = (DateTime.Now.Year).ToString();
                rb_action_year.DropDownItems.Add(rl);
                rb_action_year.SelectedItem = rl;
                rl = new RibbonLabel();
                rl.Text = (DateTime.Now.Year + 1).ToString();
                rb_action_year.DropDownItems.Add(rl);
                rl = new RibbonLabel();
                rl.Text = (DateTime.Now.Year + 2).ToString();
                rb_action_year.DropDownItems.Add(rl);
                rl = new RibbonLabel();
                rl.Text = (DateTime.Now.Year + 3).ToString();
                rb_action_year.DropDownItems.Add(rl);

                rb_view_kalUser = new RibbonButton("User calendar");
                rb_view_kalUser.Click += new EventHandler(rb_view_kalUser_Click);
                rb_view_kalUser.Image = gui.imageListToolStrip32.Images[gui.imageListToolStrip32.Images.IndexOfKey("planningSingle")];

                rb_view_kalTeam = new RibbonButton("Team calendar");
                rb_view_kalTeam.Click += new EventHandler(rb_view_kalTeam_Click);
                rb_view_kalTeam.Image = gui.imageListToolStrip32.Images[gui.imageListToolStrip32.Images.IndexOfKey("planningMulti")];

                rb_view_calendarSettings = new RibbonButton("Calendar");
                rb_view_calendarSettings.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_view_calendarSettings.Click += new EventHandler(rb_view_settings_Click);
                rb_view_calendarSettings.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("calendarSetting")];

                rb_view_UserSetting = new RibbonButton("User");
                rb_view_UserSetting.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_view_UserSetting.Click += new EventHandler(rb_view_userSetting_Click);
                rb_view_UserSetting.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("userSetting")];

                rb_view_TeamSetting = new RibbonButton("Team");
                rb_view_TeamSetting.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_view_TeamSetting.Click += new EventHandler(rb_view_teamSetting_Click);
                rb_view_TeamSetting.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("teamSetting")];

                rb_action_year.TextBoxTextChanged += new EventHandler(rb_action_year_Click);
                rb_action_year.Image = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("year")];
                rb_action_year.AllowTextEdit = false;
                rb_action_year.Enabled = false;

                rb_action_export_fast = new RibbonButton("Fast export");
                rb_action_export_fast.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_action_export_fast.Click += new EventHandler(rb_action_fast_export_Click);
                rb_action_export_fast.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("exportFast")];

                rb_action_export = new RibbonButton("Export");
                rb_action_export.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_action_export.Click += new EventHandler(rb_action_export_Click);
                rb_action_export.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("export")];

                rb_action_exportDirectory = new RibbonButton("Go to export directory");
                rb_action_exportDirectory.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_action_exportDirectory.Click += new EventHandler(rb_action_exportDirectory_Click);
                rb_action_exportDirectory.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("exportFolder")];
                
                rb_action_hotline = new RibbonButton("Hotline");
                rb_action_hotline.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_action_hotline.Click += new EventHandler(rb_action_hotline_Click);
                rb_action_hotline.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("hotline")];

                rb_action_oncall = new RibbonButton("OnCall");
                rb_action_oncall.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_action_oncall.Click += new EventHandler(rb_action_oncall_Click);
                rb_action_oncall.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("oncall")];

                rb_team_name = new RibbonButton("Name       : ________");
                rb_team_name.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_name.Click += new EventHandler(rb_action_teamEdit_Click);
                rb_team_name.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("name")];

                rb_team_service = new RibbonButton("Service    : ________");
                rb_team_service.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_service.Click += new EventHandler(rb_action_teamEdit_Click);
                rb_team_service.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("service")];

                rb_team_location = new RibbonButton("Location  : ________");
                rb_team_location.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_location.Click += new EventHandler(rb_action_teamEdit_Click);
                rb_team_location.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("location")];

                rb_team_user = new RibbonButton("No team loaded for now");
                rb_team_user.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_user.Click += new EventHandler(rb_action_teamEdit_Click);
                rb_team_user.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("user")];

                rb_team_compagny = new RibbonButton("Compagny  : ________");
                rb_team_compagny.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_compagny.Click += new EventHandler(rb_action_teamEdit_Click);
                rb_team_compagny.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("compagny")];

                rb_team_chief = new RibbonButton("Chief            : ________");
                rb_team_chief.MinSizeMode = RibbonElementSizeMode.DropDown;
                rb_team_chief.Click += new EventHandler(rb_action_teamEdit_Click);
                rb_team_chief.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("chief")];

                rb_team_listusers = new RibbonComboBox();
                rb_team_listusers.TextBoxWidth = 200;
                rb_team_listusers.TextBoxTextChanged += new EventHandler(rb_team_listusers_TextBoxTextChanged);
                rb_team_listusers.Image = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("user")];
                rb_team_listusers.DropDownItems.Add(rb_team_user);

                panelTeam = new System.Windows.Forms.RibbonPanel();
                panelTeam.Text = "Team";
                panelTeam.Items.Add(rb_team_new);
                panelTeam.Items.Add(rb_team_open);
                panelTeam.Items.Add(rb_team_new_user);
                panelTeam.Items.Add(rb_team_add_user);
                panelTeam.Items.Add(rb_team_close);
                this.Panels.Add(panelTeam);

                panelViews = new System.Windows.Forms.RibbonPanel();
                panelViews.Text = "Views";
                panelViews.Items.Add(rb_view_kalUser);
                panelViews.Items.Add(rb_view_kalTeam);
                panelViews.Enabled = false;
                this.Panels.Add(panelViews);

                panelSettings = new System.Windows.Forms.RibbonPanel();
                panelSettings.Text = "Settings";
                panelSettings.Items.Add(rb_view_calendarSettings);
                panelSettings.Items.Add(rb_view_UserSetting);
                panelSettings.Items.Add(rb_view_TeamSetting);
                panelSettings.Enabled = false;
                this.Panels.Add(panelSettings);

                panelExports = new System.Windows.Forms.RibbonPanel();
                panelExports.Text = "Extracts";
                panelExports.Items.Add(rb_action_export_fast);
                panelExports.Items.Add(rb_action_export);
                panelExports.Items.Add(rb_action_exportDirectory);
                // waiting a fix ...
                //panelActions.Items.Add(rb_action_oncall);
                //panelActions.Items.Add(rb_action_hotline);
                //panelActions.Items.Add(rb_action_year);
                panelExports.Enabled = false;
                this.Panels.Add(panelExports);

                panelTeamInformations = new System.Windows.Forms.RibbonPanel();
                panelTeamInformations.Text = "Team informations";
                panelTeamInformations.Items.Add(rb_team_name);
                panelTeamInformations.Items.Add(rb_team_service);
                panelTeamInformations.Items.Add(rb_team_location);
                panelTeamInformations.Items.Add(rb_team_compagny);
                panelTeamInformations.Items.Add(rb_team_chief);
                panelTeamInformations.Items.Add(rb_team_listusers);
                panelTeamInformations.Enabled = false;
                this.Panels.Add(panelTeamInformations);

                this.Text = "Calendar";
            }
            catch (Exception exp6000)
            {
                Log.write("[ ERR : 6000 ] Error when creating the calendar menu.\n" + exp6000.Message);
            }
		}
		#endregion
		
		#region Methods public
		public void RefreshComponent(List<string> ListComponents)
		{
            if (ListComponents != null) LastListComponents = ListComponents;
            else ListComponents = LastListComponents;

			panelExports.Enabled = false;
			panelTeamInformations.Enabled = false;
			rb_action_year.Enabled = false; // there is an issue I try to fix it...
			
			rb_team_name.Text = "Name       : ________";
			rb_team_service.Text = "Service    : ________";
			rb_team_location.Text = "Location  : ________";
			rb_team_compagny.Text = "Compagny  : ________";
			rb_team_chief.Text = "Chief            : ________";

            if (ListComponents != null && ListComponents.Count > 5)
            {
                rb_team_name.Text = "Name       : " + ListComponents[1];
                rb_team_service.Text = "Service    : " + ListComponents[2];
                rb_team_location.Text = "Location  : " + ListComponents[3];
                rb_team_compagny.Text = "Compagny  : " + ListComponents[4];
                rb_team_chief.Text = "Chief            : " + ListComponents[5];

                rb_team_listusers.DropDownItems.Clear();
                for (int i = 6; i < ListComponents.Count; i++)
                {
                    RibbonButton rbUser = new RibbonButton(ListComponents[i].Split('|')[0]);
                    rbUser.SmallImage = gui.imageListToolStrip.Images[gui.imageListToolStrip.Images.IndexOfKey("user")];
                    rb_team_listusers.DropDownItems.Add(rbUser);

                    rb_team_listusers.SelectedItem = rbUser;
                    lastUser = rb_team_listusers.SelectedItem.ToString();
                }

                panelViews.Enabled = true;
                panelSettings.Enabled = true;
                panelExports.Enabled = true;
                panelTeamInformations.Enabled = true;
                rb_team_close.Enabled = true;
                rb_team_new_user.Enabled = true;
                rb_team_add_user.Enabled = true;
                rb_action_oncall.Enabled = false;
                rb_action_hotline.Enabled = false;
            }
		}		
		public void Dispose(List<string> theList)
		{
			RibbonTabMenu.Dispose();
			theList.Remove("manager_ical_" + CurrentTabPage.Text);
		}
        public void DisableMenu()
        {
            panelExports.Enabled = false;
            panelTeamInformations.Enabled = false;
        }
        public void OnAction(EventArgs e)
        {
            if (ActionAppened != null) ActionAppened(this, e);
        }
        #endregion

        #region Events
		private void rb_action_year_Click(object sender, EventArgs e)
		{
			// pending a fix for the issue
//			ToolBarEventArgs action = new ToolBarEventArgs("action_change_year");
//			OnAction(action);
		}
		private void rb_team_listusers_TextBoxTextChanged(object sender, EventArgs e)
		{
			if(rb_team_listusers.SelectedItem != null && !rb_team_listusers.SelectedItem.Text.Equals(lastUser))
			{
				lastUser = rb_team_listusers.SelectedItem.Text;
				ToolBarEventArgs action = new ToolBarEventArgs("user_change");
				OnAction(action);
			}
		}
		private void rb_view_kalUser_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("user_calendar");
			OnAction(action);
		}
		private void rb_view_kalTeam_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("team_calendar");
			OnAction(action);
		}
        private void rb_view_settings_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("action_settings");
            OnAction(action);
        }
        private void rb_view_userSetting_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("user_edit");
            OnAction(action);
        }
        private void rb_view_teamSetting_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("team_edit");
            OnAction(action);
        }
        private void rb_action_teamEdit_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("team_edit");
            OnAction(action);
        }
		private void rb_action_hotline_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("action_hotline");
			OnAction(action);
		}
		private void rb_action_oncall_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("action_oncall");
			OnAction(action);
		}
		private void rb_action_fast_export_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("action_export_fast");
			OnAction(action);
		}
		private void rb_action_export_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("action_export");
			OnAction(action);
		}
        private void rb_action_exportDirectory_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("action_export_directory");
            OnAction(action);
        }
        private void ts_team_open_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("team_open");
            OnAction(action);
        }
        private void ts_team_new_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("team_new");
            OnAction(action);
        }
        private void ts_team_new_user_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("team_new_user");
            OnAction(action);
        }
        private void ts_team_add_user_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("team_add_user");
            OnAction(action);
        }
        private void ts_team_close_Click(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("team_del_user");
            OnAction(action);
        }
		private void ts_team_add_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("team_add");
			OnAction(action);
		}
		private void ts_team_delete_Click(object sender, EventArgs e)
		{
			ToolBarEventArgs action = new ToolBarEventArgs("team_delete");
			OnAction(action);
		}
		#endregion
	}
}
