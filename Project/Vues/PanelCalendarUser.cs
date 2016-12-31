// Log code 77 - 97

// mergin cell http://forums.codeguru.com/showthread.php?415930-DataGridView-Merging-Cells

/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools4Libraries;

namespace Assistant
{
	/// <summary>
	/// Description of PanelCalendarUser.
	/// </summary>
	public class PanelCalendarUser : Panel
	{
		#region Attribute
		private DataGridView dgv;
		private DataGridViewCell cellTemplateClassic;
		private DataGridViewCell cellTemplateOnCall;
        private DataGridViewSelectedCellCollection curentSelectedCells;
		private string year;
		private string cellupdated;
		private ContextMenu contextmenu;
		private Interface_calendar int_cal;
		
//		private string[] Days = {"Monday", "Thuesday", "Wednesday", "Friday", "Thursday", "Saturday", "Sunday"};
//		private string[] Month = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
		private string[] Days = {"Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"};
		private string[] Month = {"Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Decembre"};
		
		private bool key_ctrl;
		private bool buildmode;
		private bool mousedown;
		#endregion
		
		#region Properties
		#endregion
		
		#region Constructor
		public PanelCalendarUser(Interface_calendar ic)
		{
			int_cal = ic;
			int_cal.YearChanged += new delegateInterfaceCalendar(int_cal_YearChanged);
			this.BackColor = Color.Transparent;
		}
		#endregion
		
		#region Mehtods public
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
			if(dgv!=null)
			{
				if ((this.Width/2) - (dgv.Width/2) > 0) dgv.Left = (this.Width/2) - (dgv.Width/2);
				else dgv.Left = 0;
			}
		}
		public void LoadKalendar()
		{
			buildmode = true;
			year = int_cal.Year;
			
			if (year != null)
			{
				InitializeComponent();
				BuildDGV();
				BuildContextMenu();
				BuildYear_Main();
				
				this.Controls.Add(dgv);
				buildmode = false;
				
                try
				{
					buildmode = true;

                    int month_index = 0;
                    int day_index = 0;
                    string val = "";
                    for (int month=1; month <= 12; month++ )
                    {
                        for (int day = 1; day < 32; day++)
                        {
                            for (int act_index=0 ; act_index<int_cal.CurrentUser.Kalendar.Activities.Count; act_index++)
                            {
                                month_index = act_index + (month * int_cal.CurrentUser.Kalendar.Activities.Count) - 2;
                                day_index = day + 1;
                                val = int_cal.CurrentUser.Kalendar.Get(month, day, "2014", int_cal.CurrentUser.Kalendar.Activities[act_index]);

                                if (!string.IsNullOrEmpty(val))
                                {
                                    SetVal(day_index, month_index, val);
                                    ResetBg(day_index, month_index);
                                }
                            }
                        }
                    }
                    buildmode = false;
				}
				catch (Exception exp7791)
				{
					buildmode = false;
					Log.write("[ ERR : 7791 ] Cannot load calendar;\n" + exp7791.Message);
				}
			}
		}
		#endregion
		
		#region Methods private
        private void UpdateCellsBg()
        {
            foreach (DataGridViewCell cell in curentSelectedCells)
            {
                if (((cell.ColumnIndex % 3) + 1 == 1) || ((cell.ColumnIndex % 3) + 1 == 3))
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = ResetBg(cell.RowIndex, cell.ColumnIndex),
                        Font = new Font("Calibri", 8F),
                        ForeColor = SystemColors.WindowText,
                        SelectionBackColor = Color.DarkOrange,//ResetBg(cell.RowIndex, cell.ColumnIndex),
                        SelectionForeColor = SystemColors.HighlightText
                    };
                }
                else
                {
                    cell.Style = new DataGridViewCellStyle()
                    {
                        BackColor = ResetBg(cell.RowIndex, cell.ColumnIndex),
                        Font = new Font("Calibri", 8F),
                        ForeColor = SystemColors.WindowText,
                    };
                }
            }
        }
		private void InitializeComponent()
		{
			mousedown = false;
			cellupdated = "";
			this.BackColor = Color.Gray;
		}
		private void InitializeKey()
		{
			key_ctrl = false;
		}
		private void BuildDGV()
		{
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
			dgv.AllowDrop = true;
			dgv.BorderStyle = BorderStyle.None;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
			
			dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
			dgv.MouseMove += new MouseEventHandler(dgv_MouseMove);
			dgv.CellMouseDown += new DataGridViewCellMouseEventHandler(dgv_MouseDown);
			dgv.MouseUp += new MouseEventHandler(dgv_MouseUp);
			dgv.MouseClick += new MouseEventHandler(dgv_MouseClick);
			dgv.CellValueChanged += new DataGridViewCellEventHandler(dgv_CellValueChanged);
			dgv.KeyDown += new KeyEventHandler(dgv_KeyDown);
			dgv.KeyUp += new KeyEventHandler(dgv_KeyUp);
            dgv.ReadOnly = true;
			
			dgv.RowHeadersVisible = false;
			dgv.ColumnHeadersVisible = false;
			
			dgv.AllowUserToResizeColumns = false;
			dgv.AllowUserToResizeRows = false;
		}
		#region Year
		private void BuildYear_Main()
		{
			try
			{
				BuildYear_Initvalue();
				
				// add the 31 row for the date
				DataGridViewRow row;
				for (int i=1 ; i<32 ; i++)
				{
					row = new DataGridViewRow();
					row.Height = 14;
					dgv.Rows.Add(row);
					dgv.Height += 14;
					
					dgv.Rows[i+1].Cells[0].Value = i;
				}
				
				// add the month params
				for (int i=0 ; i<12 ; i++)
				{
					BuildYear_ColumOnCall(i);
					BuildYear_ColumMonth(i);
					
					LoadYear_WeekOfDay(i);
				}
				
				BuildYear_Border();
			}
			catch (Exception exp7794)
			{
				Log.write("[ ERR : 7794 ] Error when building the individual year planning.\n" + exp7794.Message);
			}
		}
		private void BuildYear_ColumOnCall(int month)
		{
			DataGridViewColumn columnMonth_OnCall = new DataGridViewColumn(cellTemplateOnCall);
			columnMonth_OnCall.Width = 14;
			columnMonth_OnCall.Name = Month[month] + "_OnCall";
			dgv.Columns.Add(columnMonth_OnCall);
			dgv.Width += 15;
			dgv.Rows[1].Cells[dgv.Columns.Count -1 ].Value = "A";
			
			for (int j=0 ; j<dgv.RowCount ; j++)
			{
				dgv.Rows[j].Cells[dgv.Columns.Count - 1].Style.BackColor = Color.LightGray;
			}
		}
		private void BuildYear_ColumHotline(int month)
		{
			DataGridViewColumn columnMonth_Hotline = new DataGridViewColumn(cellTemplateOnCall);
			columnMonth_Hotline.Width = 14;
			columnMonth_Hotline.Name = Month[month] + "_Hotline";
			dgv.Columns.Add(columnMonth_Hotline);
			dgv.Width += 15;
			dgv.Rows[1].Cells[dgv.Columns.Count -1 ].Value = "H";
			
			for (int j=0 ; j<dgv.RowCount ; j++)
			{
				dgv.Rows[j].Cells[dgv.Columns.Count - 1].Style.BackColor = Color.LightGray;
			}
		}
		private void BuildYear_ColumMonth(int i)
		{
			DataGridViewColumn columnMonth_AM = new DataGridViewColumn(cellTemplateClassic);
			columnMonth_AM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			columnMonth_AM.Width = 30;
			columnMonth_AM.Name = Month[i] + "_AM";
			dgv.Columns.Add(columnMonth_AM);
			dgv.Width += columnMonth_AM.Width + 1;
			
			DataGridViewColumn columnMonth_PM = new DataGridViewColumn(cellTemplateClassic);
			columnMonth_PM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			columnMonth_PM.Width = 30;
			columnMonth_PM.Name = Month[i] + "_PM";
			dgv.Columns.Add(columnMonth_PM);
			dgv.Width += columnMonth_PM.Width + 1;
			
			MergeCell(1, dgv.Columns.Count - 2, dgv.Columns.Count, Color.FromArgb(70, 70, 70), Color.WhiteSmoke, Month[i]);
		}
		private void BuildYear_Initvalue()
		{
			cellTemplateClassic = new DataGridViewTextBoxCell();
			cellTemplateClassic.Style.Font = new Font("Calibri", 8, FontStyle.Regular);
			
			cellTemplateOnCall = new DataGridViewTextBoxCell();
			cellTemplateOnCall.Style.Font = new Font("Calibri", 8, FontStyle.Regular);
			cellTemplateOnCall.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			
			DataGridViewColumn columnDay = new DataGridViewColumn(cellTemplateClassic);
			columnDay.Width = 20;
			columnDay.Name = "Day";
			dgv.Columns.Add(columnDay);
			dgv.Width += 20;
			
			// for year display
			dgv.Rows.Add();
			dgv.Height += 47;
			
			dgv.Rows.Add();
			dgv.Height += 47;
			dgv.Rows[1].Cells[0].Value = "N/A";
			dgv.Rows[1].Cells[0].Style.BackColor = Color.Black;
		}
		private void BuildYear_Border()
		{
			// display year
            MergeCell(0, 0, dgv.Columns.Count, Color.FromArgb(30, 30, 30), Color.WhiteSmoke, "Calendar " + year + "-" + int_cal.CurrentUser.Firstname + " " + int_cal.CurrentUser.Name);
			
			for (int i=0 ; i<dgv.Columns.Count ; i++) dgv.Rows[dgv.RowCount - 1].Cells[i].Style.BackColor = Color.Black;
			dgv.Rows[1].Cells[0].Style.BackColor = Color.FromArgb(70, 70, 70);
		}
		private void LoadYear_WeekOfDay(int month)
		{
			try
			{
				int index_month = 0;
				
				for (int i=0 ; i<dgv.Columns.Count ; i++)
				{
					if (dgv.Columns[i].Name.Equals(Month[month] + "_AM"))
					{
						index_month = i;
						break;
					}
				}
				DateTime dt;
				bool succeed;
				int current_m = month + 1;
				for(int i=1 ; i<32 ; i++)
				{
					succeed = DateTime.TryParse(i + "/" + current_m + "/" + year, out dt);
					if (succeed)
					{
						if (dt.DayOfWeek.ToString().Equals("Saturday") || dt.DayOfWeek.ToString().Equals("Samedi"))
						{
							SetBg(i+1, index_month, Color.FromArgb(200, 200, 200));
							SetBg(i+1, index_month + 1, Color.FromArgb(200, 200, 200));
							SetVal(i+1, index_month, "SAM");
							SetVal(i+1, index_month + 1, "SAM");
							
							dgv.Rows[i+1].Cells[index_month].ToolTipText = "Samedi";
							dgv.Rows[i+1].Cells[index_month + 1].ToolTipText = "Samedi";
						}
						else if (dt.DayOfWeek.ToString().Equals("Sunday") || dt.DayOfWeek.ToString().Equals("Dimanche"))
						{
							SetBg(i+1, index_month, Color.FromArgb(140, 140, 140));
							SetBg(i+1, index_month + 1, Color.FromArgb(140, 140, 140));
							SetVal(i+1, index_month, "DIM");
							SetVal(i+1, index_month + 1, "DIM");
							
							dgv.Rows[i+1].Cells[index_month].ToolTipText = "Dimanche";
							dgv.Rows[i+1].Cells[index_month + 1].ToolTipText = "Dimanche";
						}
						else if (!LibraryKalendar.IsFranceWorkingDay(dt))
						{
							SetBg(i+1, index_month, Color.FromArgb(90, 90, 90));
							SetBg(i+1, index_month + 1, Color.FromArgb(90, 90, 90));
							SetVal(i+1, index_month, "JF ");
							SetVal(i+1, index_month + 1, "JF ");
							
							dgv.Rows[i+1].Cells[index_month].ToolTipText = "Jour férié";
							dgv.Rows[i+1].Cells[index_month + 1].ToolTipText = "Jour férié";
						}
					}
					else
					{
						dgv.Rows[i+1].Cells[index_month].Value = "N/A";
						dgv.Rows[i+1].Cells[index_month + 1].Value = "N/A";
						dgv.Rows[i+1].Cells[index_month - 1].Value = "N/A";
						
						dgv.Rows[i+1].Cells[index_month].Style.BackColor = Color.Black;
						dgv.Rows[i+1].Cells[index_month + 1].Style.BackColor = Color.Black;
						if(dgv.Columns[index_month - 1].Name.Contains("OnCall")) dgv.Rows[i+1].Cells[index_month - 1].Style.BackColor = Color.Black;
					}
				}
			}
			catch (Exception exp7700)
			{
				Log.write("[ ERR : 7700 ] cannot detect day of week.\n" + exp7700.Message);
			}
		}
		#endregion
		#region Month
		private void BuildTableMonth()
		{
			
		}
		#endregion
		#region Day
		private void BuildTableDay()
		{
			
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
                            int col;
                            string colVal = elementActivity.Split('|')[2].Split('#')[1];
                            int.TryParse(colVal, out col);
                            dgv.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(col);
                            dgv.Rows[y].Cells[x].ToolTipText = elementActivity.Split('|')[0];
                        }
                        else if (dgv.Rows[y].Cells[x].Value.ToString().ToLower().Equals("x") && dgv.Columns[x].Name.ToLower().Contains(elementActivity.Split('|')[1].ToLower()))
                        {
                            int col;
                            string colVal = elementActivity.Split('|')[2].Split('#')[1];
                            int.TryParse(colVal, out col);
                            dgv.Rows[y].Cells[x].Style.BackColor = Color.FromArgb(col);
                            dgv.Rows[y].Cells[x].ToolTipText = elementActivity.Split('|')[0];
                        }
                    }
                }
			}
			return dgv.Rows[y].Cells[x].Style.BackColor;
		}
		private void SetVal(int y, int x, string s)
		{
			dgv.Rows[y].Cells[x].Value = s;
			if (!buildmode)
			{
				int_cal.CurrentUser.AddKal(y, x, s);
			}
		}
        private void SetVal(string column, string day, string val, string kindOfColumn)
		{
			try
			{
				for(int i=0 ; i<dgv.Columns.Count ; i++)
				{
                    if (dgv.Columns[i].Name.Split('_')[0].Equals(column.Split('_')[0]))
                    {
                        if (val.Length == 3 && (dgv.Columns[i].Name.ToLower().Contains(kindOfColumn.ToLower())))
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
			}
			catch (Exception exp7797)
			{
				Log.write("[ ERR : 7797 ] Cannot set the value.\n" + exp7797.Message);
			}
		}
		private void MergeCell(int Cell_Y, int Cell1_X, int Cell2_X, Color bg_col, Color f_col, string text)
		{
			int tmp = Cell2_X - Cell1_X + 1;
			HMergedCell pCell;
			for (int j = 0; j < (Cell2_X - Cell1_X + 1); j++)
			{
				for (int k = Cell1_X; k < Cell1_X + tmp - 1; k++)
				{
					dgv.Rows[Cell_Y].Cells[k] = new HMergedCell();
					pCell = (HMergedCell)dgv.Rows[Cell_Y].Cells[k];
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
        private void UpdateRowColor()
        {
        }
		#endregion
		
		#region Event
		private void int_cal_YearChanged(object sender, EventArgs e)
		{
			try
			{
				LoadKalendar();
			}
			catch (Exception exp9506)
			{
				Log.write("[ WRN : 9506 ] " + exp9506.Message);
			}
		}
		private void dgv_MouseUp(object sender, MouseEventArgs e)
		{
			mousedown = false;
		}
		private void dgv_MouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Right)
				{
					//DataGridViewCell clickedCell = (sender as DataGridView).Rows[dgv.CurrentCellAddress.Y].Cells[dgv.CurrentCellAddress.X];
					DataGridViewCell clickedCell = dgv[e.ColumnIndex, e.RowIndex];
					// Here you can do whatever you want with the cell
					dgv.CurrentCell = clickedCell;  // Select the clicked cell, for instance
					// Get mouse position relative to the vehicles grid
					
					if (dgv.Columns[dgv.CurrentCell.ColumnIndex].Name.Contains("_AM") || dgv.Columns[dgv.CurrentCell.ColumnIndex].Name.Contains("_PM"))
					{
						var relativeMousePosition = dgv.PointToClient(Cursor.Position);
						// Show the context menu
						contextmenu.Show(dgv, relativeMousePosition);
					}
				}
				else
				{
                    //mousedown = true;
                    //string tmp = dgv.CurrentCellAddress.X + "_" + dgv.CurrentCellAddress.Y;
                    //if (!tmp.Equals(cellupdated))
                    //{
                    //    cellupdated = tmp;
                    //    UpdateCell();
                    //}
				}
			}
			catch (Exception exp7702)
			{
				Log.write("[ ERR : 7702 ] Cannot create context menu.\n" + exp7702.Message);
			}
		}
		private void dgv_MouseMove(object sender, MouseEventArgs e)
		{
			if (mousedown)
			{
				string tmp = dgv.CurrentCellAddress.X + "_" + dgv.CurrentCellAddress.Y;
				if (!tmp.Equals(cellupdated))
				{
					cellupdated = tmp;
					if (cellupdated == null)
						return;
					UpdateCell();
				}
			}
		}
		private void dgv_MouseClick(object sender, MouseEventArgs e)
		{
			string tmp = dgv.CurrentCellAddress.X + "_" + dgv.CurrentCellAddress.Y;
			if (!tmp.Equals(cellupdated))
			{
				cellupdated = tmp;
				UpdateCell();
			}
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
                foreach (DataGridViewCell c in dgv.SelectedCells)
                {
                    SetVal(c.RowIndex, c.ColumnIndex, mi.Text.Substring(0, 3));
                }
				//SetVal(dgv.CurrentCellAddress.Y, dgv.CurrentCellAddress.X, mi.Text.Substring(0, 3));
			}
		}
		private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
            foreach (DataGridViewCell cell in ((DataGridView)sender).SelectedCells)
            {
                cell.Style = new DataGridViewCellStyle()
                {
                    BackColor = ResetBg(cell.RowIndex, cell.ColumnIndex),
                    Font = new Font("Calibri", 8F),
                    ForeColor = SystemColors.WindowText,
                    SelectionBackColor = ResetBg(cell.RowIndex, cell.ColumnIndex),
                    SelectionForeColor = SystemColors.HighlightText
                };
            }
		}
		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
            curentSelectedCells = ((DataGridView)sender).SelectedCells;
            System.Threading.Thread t = new System.Threading.Thread(UpdateCellsBg);
            t.Start();
		}
		private void dgv_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
			{
				key_ctrl = true;
			}
			else if(e.KeyCode == Keys.Delete)
			{
				SetVal(dgv.CurrentCell.RowIndex, dgv.CurrentCell.ColumnIndex, "");
			}
			else if(e.KeyCode == Keys.S && key_ctrl)
			{
				bool b = int_cal.CurrentUser.SaveKalendar();
				if (b) int_cal.OnLoad(null, null);
				else int_cal.OnLoad(200, null);
			}
			else if(e.KeyCode == Keys.C && key_ctrl)
			{
				Copy();
			}
			else if(e.KeyCode == Keys.V && key_ctrl)
			{
				Paste();
			}
		}
		private void dgv_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
			{
				key_ctrl = false;
			}
		}
		#endregion
	}
}