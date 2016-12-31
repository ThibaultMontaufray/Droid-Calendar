/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assistant
{
	public partial class FormExport : Form
	{
		#region Attribute
		private Interface_calendar int_cal;
        private bool manualModifFileName;
		#endregion
		
		#region Properties
		#endregion
		
		#region Constructor
		public FormExport(Interface_calendar ic)
		{
            manualModifFileName = false;
			int_cal = ic;
			InitializeComponent();
			DateTime firstDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			DateTime lastDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
			
			dateTimePickerStart.Value = firstDayOfCurrentMonth;
			dateTimePickerEnd.Value = lastDayOfCurrentMonth;

            string slast = "";
            textBoxExportPath.Text = "";
            foreach (string s in ic.CurrentTeam.FilePath.Split('\\'))
            {
                textBoxExportPath.Text += slast;
                if (!string.IsNullOrEmpty(slast)) textBoxExportPath.Text += '\\';
                slast = s;
            }
            if (!string.IsNullOrEmpty(int_cal.ExportFileName)) textBoxFileName.Text = int_cal.ExportFileName;
            else
            {
                string month = DateTime.Today.Month.ToString();
                if (month.Length < 2) month = "0" + month;
                textBoxFileName.Text = "Export_" + ic.CurrentTeam.Service + "_" + DateTime.Today.Year + month + ".csv";
            }
            textBoxFileName.TextChanged += new EventHandler(textBoxExportFileName_TextChanged);
            dateTimePickerStart.TextChanged += new EventHandler(dateTimePickerStart_TextChanged);
		}
		#endregion
		
		#region Methods
		#endregion
		
		#region Event
		private void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		private void ButtonExportClick(object sender, EventArgs e)
		{
			int_cal.ExportFileName = textBoxFileName.Text;
            if (int_cal.GoExport(dateTimePickerStart.Value, dateTimePickerEnd.Value, textBoxExportPath.Text))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Sorry, an error occure during the file export.\nChange the path, or other setting and try again...", "Woups, we're confuse !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
		}
		private void ButtonPathBrowseClick(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.ShowDialog();
			textBoxExportPath.Text = dialog.SelectedPath;
		}
        private void textBoxExportFileName_TextChanged(object sender, EventArgs e)
        {
            manualModifFileName = true;
        }
        private void dateTimePickerStart_TextChanged(object sender, EventArgs e)
        {
            if (!manualModifFileName)
            {
                textBoxFileName.Text = "Export_" + int_cal.CurrentTeam.Service + "_" + dateTimePickerStart.Value.Year + dateTimePickerStart.Value.Month + ".csv"; ;
                manualModifFileName = false;
            }
            if (dateTimePickerStart.Value.CompareTo(dateTimePickerEnd.Value) > 0)
            {
                dateTimePickerEnd.Value = new DateTime(dateTimePickerStart.Value.Year, dateTimePickerStart.Value.Month, dateTimePickerEnd.Value.Day);
                if (dateTimePickerStart.Value.CompareTo(dateTimePickerEnd.Value) > 0)
                {
                    if (dateTimePickerStart.Value.Month == 12)
                    {
                        dateTimePickerEnd.Value = new DateTime(dateTimePickerStart.Value.Year+1, 1, dateTimePickerEnd.Value.Day);
                    }
                    else
                    {
                        dateTimePickerEnd.Value = new DateTime(dateTimePickerStart.Value.Year, dateTimePickerStart.Value.Month+1, dateTimePickerEnd.Value.Day);
                    }
                }
            }
        }
		#endregion
	}
}
