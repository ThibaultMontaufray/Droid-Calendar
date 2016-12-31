using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Assistant
{
	public class HMergedCell : DataGridViewTextBoxCell
	{
		#region Attribute
		private int m_nLeftColumn = 0;
		private int m_nRightColumn = 0;
		private Color background_color;
		private Color fore_color;
		private string text;
		private StringFormat sf;
		#endregion
		
		#region Properties
		/// <summary>
		/// Column Index of the left-most cell to be merged.
		/// This cell controls the merged text.
		/// </summary>
		public int LeftColumn
		{
			get
			{
				return m_nLeftColumn;
			}
			set
			{
				m_nLeftColumn = value;
			}
		}

		/// <summary>
		/// Column Index of the right-most cell to be merged
		/// </summary>
		public int RightColumn
		{
			get
			{
				return m_nRightColumn;
			}
			set
			{
				m_nRightColumn = value;
			}
		}
		
		public StringFormat SF
		{
			get { return sf; }
			set { sf = value; }
		}
		
		public Color Background_color
		{
			get { return background_color; }
			set { background_color = value; }
		}
		
		public Color Fore_color
		{
			get { return fore_color; }
			set { fore_color = value; }
		}

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public new string Value
        {
            get { return text; }
            set { text = value; }
        }
		#endregion
		
		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			try
			{
				int mergeindex = ColumnIndex - m_nLeftColumn;
				int i;
				int nWidth;
				int nWidthLeft;

				Pen pen = new Pen(Brushes.Black);

				// Draw the background
				graphics.FillRectangle(new SolidBrush(background_color), cellBounds);

				// Draw the separator for rows
				graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);

				// Draw the right vertical line for the cell
				if (ColumnIndex == m_nRightColumn)
					graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);

				// Draw the text
				RectangleF rectDest = RectangleF.Empty;
				
				if (sf == null)
				{
					sf = new StringFormat();
					sf.Alignment = StringAlignment.Center;
					sf.LineAlignment = StringAlignment.Center;
					sf.Trimming = StringTrimming.EllipsisCharacter;
				}
				
				// Determine the total width of the merged cell
				nWidth = 0;
				for (i = m_nLeftColumn; i <= m_nRightColumn; i++)
					nWidth += this.OwningRow.Cells[i].Size.Width;

				// Determine the width before the current cell.
				nWidthLeft = 0;
				for (i = m_nLeftColumn; i < ColumnIndex; i++)
					nWidthLeft += this.OwningRow.Cells[i].Size.Width;

				// Retrieve the text to be displayed
				//string strText = this.OwningRow.Cells[m_nLeftColumn].Value.ToString();
				
				rectDest = new RectangleF(cellBounds.Left - nWidthLeft, cellBounds.Top, nWidth, cellBounds.Height);
				//graphics.DrawString(strText,new Font("Calibri", 10, FontStyle.Bold), Brushes.Black, rectDest, sf);
				graphics.DrawString(text,new Font("Calibri", 8, FontStyle.Regular), Brushes.WhiteSmoke, rectDest, sf);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.ToString());
			}
		}

	}// class
}


