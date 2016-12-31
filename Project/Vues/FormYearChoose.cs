/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assistant
{
	/// <summary>
	/// Description of FormYearChoose.
	/// </summary>
	public partial class FormYearChoose : Form
	{
		#region Attribute
		private Interface_calendar int_cal;
		private int Year;
		#endregion
		
		#region Constructor
		public FormYearChoose(Interface_calendar ic)
		{
			Year = DateTime.Now.Year;
			int_cal  = ic;
			InitializeComponent();
			this.KeyDown += new KeyEventHandler(FormYearChoose_KeyDown);
			this.textBoxYear.Focus();
			this.textBoxYear.TextChanged += new EventHandler(FormYearChoose_TextChanged);
			this.LostFocus += new EventHandler(FormYearChoose_LostFocus);
			this.Shown += new EventHandler(FormYearChoose_Shown);
		}
		#endregion
		
		#region Methods
		private void ChangeYear()
		{
			if (ValidateYear())
			{
				// change the year
				int_cal.Year = Year.ToString();
				this.Close();
			}
		}
		
		private bool ValidateYear()
		{
			if (!string.IsNullOrEmpty(textBoxYear.Text) && textBoxYear.Text.Length == 4)
			{
				try
				{
					if (!string.IsNullOrEmpty(textBoxYear.Text) && textBoxYear.Text.Length == 4)
					{
						Year = int.Parse(textBoxYear.Text);
						textBoxYear.BackColor = Color.GreenYellow;
						return true;
					}
					else
					{
						textBoxYear.BackColor = Color.DarkOrange;
						return false;
					}
				}
				catch (Exception)
				{
					textBoxYear.BackColor = Color.DarkOrange;
					return false;
				}
			}
			else
			{
				textBoxYear.BackColor = Color.DarkOrange;
				return false;
			}
		}
		#endregion
		
		#region event
		private void FormYearChoose_Shown(object sender, EventArgs e)
		{
			this.Top = int_cal.YearTop;
			this.Left = int_cal.YearLeft;
		}
		
		private void FormYearChoose_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				ChangeYear();
			}
			else if(e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}
		
		private void FormYearChoose_LostFocus(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FormYearChoose_TextChanged(object sender, EventArgs e)
		{
			ValidateYear();
		}
		#endregion
	}
}
