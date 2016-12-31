// Log code 30 - 11

/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Drawing;
using Tools4Libraries;

namespace Assistant
{
	/// <summary>
	/// Description of PanelCalendarTeam.
	/// </summary>
	public class PanelCalendarTeam : Panel
	{
		#region Attribute
		private Interface_calendar int_cal;
		
		private DataGridView dgvTop;
		private DataGridView dgv;
		private Panel panelTop;
		private Panel panelBottom;
		
		private DataGridViewCell cellTemplateClassic;
		private DataGridViewCell cellTemplateOnCall;
		private ContextMenu contextmenu;
		
		private int year;
		//private string cellupdated;
		//private string[] Days = {"Monday", "Thuesday", "Wednesday", "Friday", "Thursday", "Saturday", "Sunday"};
		//private string[] Month = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
		private string[] Days = {"Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"};
		private string[] Month = {"Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Decembre"};
		
		private int indexColumUser;
		
		//private bool key_ctrl;
		private bool buildmode;
		//private bool mousedown;
		private bool loaded;
		#endregion
		
		#region Constructor
		public PanelCalendarTeam(Interface_calendar ic)
		{
			loaded = false;
			int_cal = ic;
			int_cal.YearChanged += new delegateInterfaceCalendar(int_cal_YearChanged);
			this.BackColor = Color.Transparent;
			
			panelBottom = new Panel();
			panelBottom.Dock = DockStyle.Fill;
			panelBottom.AutoScroll = true;
			this.Controls.Add(panelBottom);
			
			panelTop = new Panel();
			panelTop.Height = 100;
			panelTop.Dock = DockStyle.Top;
			panelTop.BackColor = Color.Black;
			this.Controls.Add(panelTop);
		}
		#endregion
		
		#region Methods public
		public void BuildContextMenu()
		{
			contextmenu = new ContextMenu();
			
			MenuItem mi_CP = new MenuItem("Copier");
			mi_CP.Click += new EventHandler(ContectMenuClick);
			MenuItem mi_PS = new MenuItem("Coller");
			mi_PS.Click += new EventHandler(ContectMenuClick);
			
			contextmenu.MenuItems.Add(mi_CP);
			contextmenu.MenuItems.Add(mi_PS);
			contextmenu.MenuItems.Add("-");
			
			MenuItem mi;
			foreach (string element in int_cal.ListActivities)
			{
				mi = new MenuItem(element.Split('|')[1] + "-" + element.Split('|')[0]);
				mi.Click += new EventHandler(ContectMenuClick);
				contextmenu.MenuItems.Add(mi);
			}
			MenuItem mi_JF = new MenuItem("JF - Jour férié");
			mi_JF.Click += new EventHandler(ContectMenuClick);
			MenuItem mi_SAM = new MenuItem("SAM - Samedi");
			mi_SAM.Click += new EventHandler(ContectMenuClick);
			MenuItem mi_DIM = new MenuItem("DIM - Dimanche");
			mi_DIM.Click += new EventHandler(ContectMenuClick);
			
			contextmenu.MenuItems.Add("-");
			contextmenu.MenuItems.Add(mi_JF);
			contextmenu.MenuItems.Add(mi_SAM);
			contextmenu.MenuItems.Add(mi_DIM);
		}
		public void refresh()
		{
			if (!loaded)
			{
				LoadKalendar();
			}
			if (dgv != null && dgvTop != null)
            {
				if ((this.Width/2) - (dgv.Width/2) > 0) dgv.Left = (this.Width/2) - (dgv.Width/2);
				else dgv.Left = 0;
				if ((this.Width/2) - (dgvTop.Width/2) > 0) dgvTop.Left = (this.Width/2) - (dgvTop.Width/2);
				else dgvTop.Left = 0;
            }
            dgv.FirstDisplayedCell = dgv.Rows[100].Cells[0];
		}
        public void SelectCurrentRow()
        {
            dgv.FirstDisplayedScrollingRowIndex = 100;
            dgv.Refresh();
        }
        public void LoadKalendar()
		{
            this.Visible = false;
			buildmode = true;
            try
            {
                year = int.Parse(int_cal.Year);
            }
            catch (Exception exp3007)
            {
                Log.write("[ ERR : 3007 ] Cannot convert the year into int.\n" + exp3007.Message);
            }
			InitializeComponent();
			int_cal.OnLoad(10, null);
			BuildDGV();
			BuildDGVHeader();
			BuildContextMenu();
			int_cal.OnLoad(20, null);
			BuildYear_Main();
			int_cal.OnLoad(30, null);
				
			this.panelBottom.Controls.Add(dgv);
			dgv.Top = 0;
			int_cal.OnLoad(40, null);
				
			this.panelTop.Controls.Add(dgvTop);
			dgvTop.Top = 10;
			dgvTop.BackColor = Color.Black;
				
			buildmode = false;
			try
			{
				Cursor = Cursors.WaitCursor;
				buildmode = true;
				int_cal.OnLoad(50, null);
				Year_user();
                buildmode = false;
				Cursor = Cursors.Default;
				loaded = true;
				int_cal.OnLoad(110, null);
			}
			catch (Exception exp3000)
			{
				Cursor = Cursors.Default;
				buildmode = false;
				Log.write("[ ERR : 3000 ] Cannot load team calendar.\n" + exp3000.Message);
			}
            this.Visible = true;
		}
		#endregion
		
		#region Methods private
		private void InitializeComponent()
		{
//			mousedown = false;
//			cellupdated = "";
			this.AutoScroll = true;
			this.BackColor = Color.Gray;
		}
		private void BuildDGVHeader()
		{
			if (dgvTop != null)
			{
				dgvTop.Columns.Clear();
				dgvTop.Dispose();
				dgvTop = null;
			}
			dgvTop = new DataGridView();
			dgvTop.Dock = DockStyle.None;
			dgvTop.Top = 10;
			dgvTop.Left = 10;
			dgvTop.Width = 0;
			dgvTop.Height = 0;
			dgvTop.GridColor = Color.Black;
			dgvTop.BackgroundColor = Color.Black;
			dgvTop.BorderStyle = BorderStyle.None;
			
			dgvTop.RowHeadersVisible = false;
			dgvTop.ColumnHeadersVisible = false;
			
			dgvTop.AllowDrop = false;
			dgvTop.AllowUserToAddRows = false;
			dgvTop.AllowUserToDeleteRows = false;
			dgvTop.AllowUserToResizeColumns = false;
			dgvTop.AllowUserToResizeRows = false;
			
			dgvTop.CellPainting += new DataGridViewCellPaintingEventHandler(dgvTop_CellPainting);
		}
		private void BuildDGV()
		{
			// main dgv
			if (dgv != null)
			{
				dgv.Columns.Clear();
				dgv.Dispose();
				dgv = null;
			}
			dgv = new DataGridView();
			dgv.Dock = DockStyle.None;
			dgv.Top = 10;
			dgv.Left = 10;
			dgv.Width = 0;
			dgv.Height = 0;
			dgv.GridColor = Color.Black;
			dgv.BackgroundColor = Color.Gray;
			dgv.BorderStyle = BorderStyle.None;
			
			dgv.RowHeadersVisible = false;
			dgv.ColumnHeadersVisible = false;
			
			dgv.AllowDrop = false;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToResizeColumns = false;
			dgv.AllowUserToResizeRows = false;
			
			dgv.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_MouseDown);
		}
		private void BuildYear_Main()
		{
			try
			{
				Year_init();
				Year_head();
				
				for (int month=1 ; month<13 ; month++)
				{
					Year_days(month);
				}
			}
			catch (Exception exp3001)
			{
				Log.write("[ ERR : 3001 ] Cannot build team year calendar.\n" + exp3001.Message);
			}
		}

		#region Year
		private void Year_init()
		{
			cellTemplateClassic = new DataGridViewTextBoxCell();
			cellTemplateClassic.Style.Font = new Font("Calibri", 8, FontStyle.Regular);
			
			cellTemplateOnCall = new DataGridViewTextBoxCell();
			cellTemplateOnCall.Style.Font = new Font("Calibri", 8, FontStyle.Regular);
			cellTemplateOnCall.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		private void Year_head()
		{
			DataGridViewColumn columnDay = new DataGridViewColumn(cellTemplateClassic);
			columnDay.Width = 30;
			columnDay.Name = "Day";
			dgv.Columns.Add(columnDay);
			dgv.Width += 32;
			columnDay = new DataGridViewColumn(cellTemplateClassic);
			columnDay.Width = 30;
			columnDay.Name = "Day";
			dgvTop.Columns.Add(columnDay);
			dgvTop.Width += 32;
			
			DataGridViewColumn columnWDay = new DataGridViewColumn(cellTemplateClassic);
			columnWDay.Width = 20;
			columnWDay.Name = "WeekDay";
			dgv.Columns.Add(columnWDay);
			dgv.Width += 22;
			columnWDay = new DataGridViewColumn(cellTemplateClassic);
			columnWDay.Width = 20;
			columnWDay.Name = "WeekDay";
			dgvTop.Columns.Add(columnWDay);
			dgvTop.Width += 22;
			
			DataGridViewColumn columnValidation = new DataGridViewColumn(cellTemplateClassic);
			columnValidation.Width = 20;
			columnValidation.Name = "Validation";
			dgv.Columns.Add(columnValidation);
			dgv.Width += 22;
			columnValidation = new DataGridViewColumn(cellTemplateClassic);
			columnValidation.Width = 20;
			columnValidation.Name = "Validation";
			dgvTop.Columns.Add(columnValidation);
			dgvTop.Width += 22;
			
			// for month display
			dgv.Rows.Add();
			dgv.Height += 47;
			
			// for year display
			dgvTop.Rows.Add();
			dgvTop.Height += 47;
			
			// for users names row
			dgvTop.Rows.Add();
			dgvTop.Height += 47;
			
			dgvTop.Rows.Add();
			dgvTop.Height += 47;
			
			dgvTop.Rows.Add();
			dgvTop.Height += 47;
			// frozen the header
			//dgv.Rows[1].Frozen = true;
			
			for ( int i=0 ; i<4 ; i++)
			{
				dgvTop.Rows[i].Cells[0].Style.BackColor = Color.Black;
				dgvTop.Rows[i].Cells[1].Style.BackColor = Color.Black;
				dgvTop.Rows[i].Cells[2].Style.BackColor = Color.Black;
			}
		}
		private void Year_days(int month)
		{
			// add the 31 row for the date
			DataGridViewRow row;
			string weekday;
			
			try
			{
				row = new DataGridViewRow();
				row.Height = 14;
				dgv.Rows.Add(row);
				dgv.Height += 14;
				
				dgv.Rows[dgv.Rows.Count-2].Cells[0].Value = Month[month-1] + " [" + month + "-" + year + "]";
				dgv.Rows[dgv.Rows.Count-2].Cells[0].Style.ForeColor = Color.FromArgb(20, 20, 20);
			}
			catch (Exception exp3002)
			{
				Log.write("[ ERR : 3002 ] Cannot add the month row.\n" + exp3002.Message);
			}
			
			for (int i=1 ; i<DateTime.DaysInMonth(year, month); i++)
			{
                try
                {
                    weekday = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-" + i.ToString()).DayOfWeek.ToString().Substring(0, 3);
                    row = new DataGridViewRow();
                    row.Height = 14;
                    dgv.Rows.Add(row);
                    dgv.Height += 14;
                    
                    dgv.Rows[dgv.Rows.Count - 2].Cells[0].Value = weekday;
                    dgv.Rows[dgv.Rows.Count - 2].Cells[1].Value = i;
                    dgv.Rows[dgv.Rows.Count - 2].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (!LibraryKalendar.IsFranceWorkingDay(DateTime.Parse(year.ToString() + "-" + month.ToString() + "-" + i.ToString())))
                    {
                        dgv.Rows[dgv.Rows.Count - 2].Cells[0].Style.BackColor = Color.Gray;
                        dgv.Rows[dgv.Rows.Count - 2].Cells[1].Style.BackColor = Color.Gray;
                        dgv.Rows[dgv.Rows.Count - 2].Cells[2].Style.BackColor = Color.Gray;
                        if (dgv.Rows[dgv.Rows.Count - 2].Cells.Count>3) dgv.Rows[dgv.Rows.Count - 2].Cells[3].Style.BackColor = Color.FromArgb(170, 170, 170);
                    }
                    else
                    {
                        dgv.Rows[dgv.Rows.Count - 2].Cells[0].Style.BackColor = Color.WhiteSmoke;
                        dgv.Rows[dgv.Rows.Count - 2].Cells[1].Style.BackColor = Color.LightGray;
                        dgv.Rows[dgv.Rows.Count - 2].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        if (dgv.Rows[dgv.Rows.Count - 2].Cells.Count > 3) dgv.Rows[dgv.Rows.Count - 2].Cells[3].Style.BackColor = Color.FromArgb(20, 20, 20);
                    }
                }
                catch (Exception exp3008)
                {
                    Log.write("[ ERR : 3008 ] Cannot create month day rows in datagrid view.\n" + exp3008.Message);
                }
			}
		}
		private void Year_user()
		{
            try
            {
                if (int_cal.CurrentTeam != null)
                {
                    buildmode = true;

                    int month_index = 0;
                    int day_index = 0;
                    int ofsetUser = 0;
                    int offsetMonth = 0;
                    int nbColums = 5;
                    string val = "";
                    int index = 1;
                    foreach (User cur_user in int_cal.CurrentTeam.ListUsers)
                    {
                        int i = 50 + ((index * 40) / int_cal.CurrentTeam.ListUsers.Count);
                        int_cal.OnLoad(i, null);
                        index++;

                        if (cur_user != null && cur_user.Name != null)
                        {
                            bool flaglast = cur_user.Name.Equals(int_cal.CurrentTeam.ListUsers[int_cal.CurrentTeam.ListUsers.Count - 1].Name);

                            Year_buildUserColumns(cur_user);
                            Year_buildUserColumnsHeader(cur_user);
                            if (cur_user.Kalendar == null)
                            {
                                if (cur_user.IntCal == null) cur_user.IntCal = int_cal;
                                cur_user.LoadKalendar();
                            }
                        }

                        offsetMonth = 0;
                        ofsetUser++;
                        for (int month = 1; month <= 12; month++)
                        {
                            for (int day = 1; day < DateTime.DaysInMonth(2014, month); day++)
                            {
                                for (int act_index = 0; act_index < cur_user.Kalendar.Activities.Count; act_index++)
                                {
                                    month_index = act_index + (ofsetUser * nbColums);

                                    day_index = day + offsetMonth;
                                    val = cur_user.Kalendar.Get(month, day, "2014", cur_user.Kalendar.Activities[act_index]);

                                    if (!string.IsNullOrEmpty(val))
                                    {
                                        SetVal(day_index, month_index, val);
                                        ResetBg(day_index, month_index);
                                    }
                                }
                            }
                            offsetMonth += DateTime.DaysInMonth(2014, month);
                        }
                        Year_loadUserColumns((int_cal.CurrentTeam.ListUsers.Count - 1).Equals(int_cal.CurrentTeam.ListUsers.IndexOf(cur_user)));
                    }
                    buildmode = false;
                }
            }
            catch (Exception exp3009)
            {
                Cursor = Cursors.Default;
                Log.write("[ ERR : 3009 ] Cannot load calendar for one user.\n" + exp3009.Message);
            }
		}
		private void Year_buildUserColumnsHeader(User u)
		{
			indexColumUser = dgvTop.Columns.Count;
			
			DataGridViewColumn columnSeparation = new DataGridViewColumn(cellTemplateClassic);
			columnSeparation.Width = 4;
			columnSeparation.Name = "separation";
			dgvTop.Columns.Add(columnSeparation);
			dgvTop.Width += 6;
			
			DataGridViewColumn columnHotline = new DataGridViewColumn(cellTemplateOnCall);
			columnHotline.Width = 20;
			columnHotline.Name = "Hotline_" + u.Name + u.Firstname;
			dgvTop.Columns.Add(columnHotline);
			dgvTop.Width += 22;
			
			DataGridViewColumn columnOncall = new DataGridViewColumn(cellTemplateOnCall);
			columnOncall.Width = 20;
			columnOncall.Name = "Oncall_" + u.Name + u.Firstname;
			dgvTop.Columns.Add(columnOncall);
			dgvTop.Width += 22;
			
			DataGridViewColumn columnAM = new DataGridViewColumn(cellTemplateClassic);
			columnAM.Width = 30;
			columnAM.Name = "AM_" + u.Name + u.Firstname;
			dgvTop.Columns.Add(columnAM);
			dgvTop.Width += 32;
			
			DataGridViewColumn columnPM = new DataGridViewColumn(cellTemplateClassic);
			columnPM.Width = 30;
			columnPM.Name = "PM_" + u.Name + u.Firstname;
			dgvTop.Columns.Add(columnPM);
			dgvTop.Width += 32;
			
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			sf.Trimming = StringTrimming.EllipsisCharacter;
			MergeCell(dgvTop, 1, indexColumUser + 1, indexColumUser + 5, Color.FromArgb(100, 100, 100), Color.WhiteSmoke, u.Name, sf);
			MergeCell(dgvTop, 2, indexColumUser + 1, indexColumUser + 5, Color.FromArgb(70, 70, 70), Color.WhiteSmoke, u.Firstname, sf);
			MergeCell(dgvTop, 3, indexColumUser + 1, indexColumUser + 5, Color.FromArgb(40, 40, 40), Color.WhiteSmoke, u.Matricule, sf);
			
			for (int i=0 ; i<4 ; i++)
			{
				dgvTop.Rows[i].Cells[indexColumUser].Style.BackColor = Color.Black;
				dgvTop.Rows[i].Cells[indexColumUser+1].Style.BackColor = Color.Black;
				dgvTop.Rows[i].Cells[indexColumUser+2].Style.BackColor = Color.Black;
				dgvTop.Rows[i].Cells[indexColumUser+3].Style.BackColor = Color.Black;
				dgvTop.Rows[i].Cells[indexColumUser+4].Style.BackColor = Color.Black;
			}
		}
		private void Year_buildUserColumns(User u)
		{
			indexColumUser = dgv.Columns.Count;
			
			DataGridViewColumn columnSeparation = new DataGridViewColumn(cellTemplateClassic);
			columnSeparation.Width = 4;
			columnSeparation.Name = "separation";
			dgv.Columns.Add(columnSeparation);
			dgv.Width += 6;
			
			DataGridViewColumn columnHotline = new DataGridViewColumn(cellTemplateOnCall);
			columnHotline.Width = 20;
			columnHotline.Name = "Hotline_" + u.Name + u.Firstname;
			dgv.Columns.Add(columnHotline);
			dgv.Width += 22;
			
			DataGridViewColumn columnOncall = new DataGridViewColumn(cellTemplateOnCall);
			columnOncall.Width = 20;
			columnOncall.Name = "Oncall_" + u.Name + u.Firstname;
			dgv.Columns.Add(columnOncall);
			dgv.Width += 22;
			
			DataGridViewColumn columnAM = new DataGridViewColumn(cellTemplateClassic);
			columnAM.Width = 30;
			columnAM.Name = "AM_" + u.Name + u.Firstname;
			dgv.Columns.Add(columnAM);
			dgv.Width += 32;
			
			DataGridViewColumn columnPM = new DataGridViewColumn(cellTemplateClassic);
			columnPM.Width = 30;
			columnPM.Name = "PM_" + u.Name + u.Firstname;
			dgv.Columns.Add(columnPM);
			dgv.Width += 32;
		}
        private void Year_loadUserColumns(bool last)
		{
			bool workingday;
            int monthIndex = 0;
			
			foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[1].Value == null)
                {
                    monthIndex++;
                    if (monthIndex == 13) monthIndex = 1;
                }

                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Length < 3)
				{
					workingday = true;
					try
					{
                        if (!LibraryKalendar.IsFranceWorkingDay(DateTime.Parse(row.Cells[1].Value.ToString() + "-" + monthIndex + "-2014"))) workingday = false;
					}
					catch (Exception exp3003)
					{
						workingday = true;
						Log.write("[ ERR : 3003 ] Cannot continue.\n" + exp3003.Message);
					}
				}
				else workingday = true;
				
				if(!workingday)
				{
					if (row.Cells[indexColumUser + 1].Style.BackColor.Equals(Color.Empty)) row.Cells[indexColumUser + 1].Style.BackColor = Color.FromArgb(170, 170, 170);
					if (row.Cells[indexColumUser + 2].Style.BackColor.Equals(Color.Empty)) row.Cells[indexColumUser + 2].Style.BackColor = Color.FromArgb(170, 170, 170);
					if (row.Cells[indexColumUser + 3].Style.BackColor.Equals(Color.Empty)) row.Cells[indexColumUser + 3].Style.BackColor = Color.FromArgb(170, 170, 170);
					if (row.Cells[indexColumUser + 4].Style.BackColor.Equals(Color.Empty)) row.Cells[indexColumUser + 4].Style.BackColor = Color.FromArgb(170, 170, 170);
				}
				if (row.Cells[indexColumUser].Style.BackColor.Equals(Color.Empty)) row.Cells[indexColumUser].Style.BackColor = Color.Black;

                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != null && row.Cells[0].Value.ToString().Contains("["))
                {
                    if (last)
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Near;
                        sf.Trimming = StringTrimming.EllipsisCharacter;
                        MergeCell(dgv, row.Index, 0, dgv.Columns.Count, Color.FromArgb(20, 20, 20), Color.Black, row.Cells[0].Value.ToString(), sf);
                    }
                }
			}
		}
		#endregion
		
		private void Copy()
		{
			DataObject d = dgv.GetClipboardContent();
			Clipboard.SetDataObject(d);
		}
		private void Paste()
		{
			try
			{
				string s = Clipboard.GetText();
				string[] lines = s.Split('\n');
				int row = dgv.CurrentCell.RowIndex;
				int refcol = dgv.CurrentCell.ColumnIndex;
				int col = dgv.CurrentCell.ColumnIndex;
				for (int j=0 ; j<lines.Length ; j++ )
				{
					string[] cells = lines[j].Split('\t');
					int cellsSelected = cells.Length;
					for (int i = 0; i < cellsSelected; i++)
					{
						SetVal(row+j, col, cells[i].Substring(0, 3));
						ResetBg(row+j, col);
						col++;
					}
					col = refcol;
				}
			}
			catch (Exception exp7706)
			{
				Log.write("[ WRN : 7706 ] error when trying copy cell.\n" + exp7706.Message);
			}
		}
		private void SetBg(int y, int x, Color col)
		{
			dgv.Rows[y].Cells[x].Style.BackColor = col;
		}
		private Color ResetBg(int y, int x)
		{
            try
            {
			    if(y == dgv.Rows.Count-1)
			    {
				    dgv.Rows[y].Cells[x].Style.BackColor = Color.Black;
			    }
			    else if (dgv.Rows[y].Cells[x].Value != null)
			    {
                    foreach (string elementActivity in int_cal.ListActivities)
                    {
                        if (elementActivity.Split('|').Length > 2)
                        {
                            if (dgv.Rows[y].Cells[x].Value.ToString().ToLower().Equals(elementActivity.Split('|')[1].ToLower()))
                            {
                                string colVal = "";
                                if (elementActivity.Split('|')[2].Split('#').Length > 1)
                                {
                                    colVal = elementActivity.Split('|')[2].Split('#')[1];
                                    int col;
                                    int.TryParse(colVal, out col); 
                                    dgv.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(col);
                                }
                                else
                                {
                                    colVal = elementActivity.Split('|')[2];
                                    dgv.Rows[y].Cells[x].Style.BackColor = Color.FromName(colVal);
                                }
                                dgv.Rows[y].Cells[x].ToolTipText = elementActivity.Split('|')[0];
                            }
                            else if (dgv.Rows[y].Cells[x].Value.ToString().ToLower().Equals("x") && dgv.Columns[x].Name.ToLower().Contains(elementActivity.Split('|')[1].ToLower()))
                            {
                                string colVal = "";
                                if (elementActivity.Split('|')[2].Split('#').Length > 1)
                                {
                                    colVal = elementActivity.Split('|')[2].Split('#')[1];
                                    int col;
                                    int.TryParse(colVal, out col);
                                    dgv.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(col);
                                }
                                else
                                {
                                    colVal = elementActivity.Split('|')[2];
                                    dgv.Rows[y].Cells[x].Style.BackColor = Color.FromName(colVal);
                                } 
                                dgv.Rows[y].Cells[x].ToolTipText = elementActivity.Split('|')[0];
                            }
                        }
                    }
			    }
			    return dgv.Rows[y].Cells[x].Style.BackColor;
            }
            catch (Exception exp3011)
            {
                Log.write("[ WRN : 3011 ] error when color call in the team calendar.\n" + exp3011.Message);
                return Color.Empty;
            }
		}
		private void SetVal(int y, int x, string s)
		{
            try
            {
                dgv.Rows[y].Cells[x].Value = s;
                if (!buildmode)
                {
                    int_cal.CurrentUser.AddKal(y, x, s);
                }
            }
            catch (Exception exp3010)
            {
                Log.write("[ WRN : 3010 ] error when setting value in the team calendar.\n" + exp3010.Message);
            }
		}
		private void SetVal(string column, string day, string val, string kindOfColumn)
		{
			try
			{
				for(int i=0 ; i<dgv.Columns.Count ; i++)
				{
					if(dgv.Columns[i].Name.ToLower().Contains(column.Substring(0, 4).ToLower()) && (dgv.Columns[i].Name.ToLower().Contains(kindOfColumn.ToLower())))
					{
						foreach (DataGridViewRow row in dgv.Rows)
						{
							if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(day))
							{
								SetVal(row.Index, i, val);
								ResetBg(row.Index, i);
							}
						}
					}
				}
			}
			catch (Exception exp7790)
			{
				Log.write("[ ERR : 7790 ] Cannot set the value.\n" + exp7790.Message);
			}
		}
		private void MergeCell(DataGridView my_dgv, int Cell_Y, int Cell1_X, int Cell2_X, Color bg_col, Color f_col, string text, StringFormat sf)
		{
			int tmp = Cell2_X - Cell1_X + 1;
			HMergedCell pCell;
			
			for (int j = 0; j < (Cell2_X - Cell1_X + 1); j++)
			{
				for (int k = Cell1_X; k < Cell1_X + tmp - 1; k++)
				{
					my_dgv.Rows[Cell_Y].Cells[k] = new HMergedCell();
					pCell = (HMergedCell)my_dgv.Rows[Cell_Y].Cells[k];
					pCell.SF = sf;
					pCell.LeftColumn = Cell1_X;
					pCell.RightColumn = Cell2_X-1;
					pCell.Background_color = bg_col;
					pCell.Fore_color = f_col;
					pCell.Text = text;
				}
			}
		}
		private void UpdateCell()
		{
			if (dgv.CurrentCellAddress.Y < dgv.Rows.Count - 1)
			{
				Color col;
				string val = "";
				
				if (dgv.Columns[dgv.CurrentCellAddress.X].Name.Contains("OnCall") || dgv.Columns[dgv.CurrentCellAddress.X].Name.Equals("Hotline"))
				{
					if (dgv.CurrentCell.Value == null || dgv.CurrentCell.Value.Equals(""))
					{
						col = Color.GreenYellow;
						val = "x";
					}
					else
					{
						col = Color.LightGray;
					}
					
					SetBg(dgv.CurrentCellAddress.Y, dgv.CurrentCellAddress.X, col);
					SetVal(dgv.CurrentCellAddress.Y, dgv.CurrentCellAddress.X, val);
				}

			}
		}
		#endregion
		
		#region Event
		private void dgvTop_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex == this.dgvTop.CurrentCell.RowIndex && e.ColumnIndex == this.dgvTop.CurrentCell.ColumnIndex)
            {
                e.CellStyle.SelectionBackColor = Color.Black;
            }
        }
		
		private void dgv_MouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			// hide to allow livraison. TODO : add for the next version
//			try
//			{
//				if (e.Button == MouseButtons.Right)
//				{
//					//DataGridViewCell clickedCell = (sender as DataGridView).Rows[dgv.CurrentCellAddress.Y].Cells[dgv.CurrentCellAddress.X];
//					DataGridViewCell clickedCell = dgv[e.ColumnIndex, e.RowIndex];
//					// Here you can do whatever you want with the cell
//					dgv.CurrentCell = clickedCell;  // Select the clicked cell, for instance
//					// Get mouse position relative to the vehicles grid
//
//					if (dgv.Columns[dgv.CurrentCell.ColumnIndex].Name.Contains("AM_") || dgv.Columns[dgv.CurrentCell.ColumnIndex].Name.Contains("PM_"))
//					{
//						var relativeMousePosition = dgv.PointToClient(Cursor.Position);
//						// Show the context menu
//						contextmenu.Show(dgv, relativeMousePosition);
//					}
//				}
//				else
//				{
//					mousedown = true;
//					string tmp = dgv.CurrentCellAddress.X + "_" + dgv.CurrentCellAddress.Y;
//					if (!tmp.Equals(cellupdated))
//					{
//						cellupdated = tmp;
//						UpdateCell();
//					}
//				}
//			}
//			catch (Exception exp3006)
//			{
//				Log.write("[ ERR : 3006 ] Cannot create context menu.\n" + exp3006.Message);
//			}
		}
		
		private void ContectMenuClick(object sender, EventArgs e)
		{
			MenuItem mi = sender as MenuItem;
			if(mi.Text.Equals("Copier"))
			{
				Copy();
			}
			else if(mi.Text.Equals("Coller"))
			{
				Paste();
			}
			else
			{
				SetVal(dgv.CurrentCellAddress.Y, dgv.CurrentCellAddress.X, mi.Text.Substring(0, 3));
			}
		}
		
		private void int_cal_YearChanged(object sender, EventArgs e)
		{
			try
			{
				LoadKalendar();
			}
			catch (Exception exp3005)
			{
				Log.write("[ WRN : 3005 ] " + exp3005.Message);
			}
		}
		#endregion
	}
}
