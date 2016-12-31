// LOG CODE : 73 02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Tools4Libraries;

namespace Assistant
{
    public class Kalendar
    {
        #region Attribute
        private List<List<string>> tableCSVkalendar;
        private string[] Month = { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Decembre" };
        private string kalendarPath;
        private string calendarData;
        private User user;
        private int nbColumns; // determine the number of column per week (for example with oncall / hotline / ...)
        private int rowOffset; // to know how many row for header there is
        private List<string> activites;
        private FileInfo fi;
        #endregion

        #region Properties
        public string KalendarPath
        {
            get { return kalendarPath; }
            set
            {
                kalendarPath = value;
                if (!string.IsNullOrEmpty(kalendarPath)) fi = new FileInfo(kalendarPath);
            }
        }
        public List<string> Activities
        {
            get { return activites; }
            set { activites = value; }
        }
        #endregion

        #region Constructor
        public Kalendar(User u)
        {
            activites = new List<string>();
            
            nbColumns = 3;
            rowOffset = 1;
            user = u;

            if (u.Kalendar != null)
            {
                if (!string.IsNullOrEmpty(u.Kalendar.kalendarPath)) kalendarPath = u.Kalendar.kalendarPath;

                if (u.Kalendar.Activities != null && u.Kalendar.Activities.Count > 0)
                {
                    foreach (string act in u.Kalendar.Activities)
                    {
                        activites.Add(act);
                    }
                }
                else
                {
                    activites.Add("OnCall");
                    activites.Add("AM");
                    activites.Add("PM");
                }
                this.Load();
            }
            else
            {
                activites.Add("OnCall");
                activites.Add("AM");
                activites.Add("PM");
            }
        }
        public Kalendar(User u, string path)
        {
            nbColumns = 3;
            rowOffset = 1;
            user = u;

            activites = new List<string>();
            activites.Add("OnCall");
            activites.Add("AM");
            activites.Add("PM");
         
            kalendarPath = path;
            ///Load();
        }
        #endregion

        #region Methods public
        public void Set(int colMonthIndex, int rowDayIndex, string year, string valueBrut)
        {
            int dayIndex = rowDayIndex - rowOffset;

            string activityDay = activites[(colMonthIndex - 1) % nbColumns];
            int monthIndex = ((colMonthIndex-1) / (nbColumns)) + 1;

            Set(monthIndex, dayIndex, year, activityDay, valueBrut);
        }
        public void Set(int monthIndex, int dayIndex, string year, string activity, string value)
        {
            try
            {
                // save the old value
                string oldval = tableCSVkalendar[dayIndex][monthIndex];
                string newval = "";
                user.Modified = true;

                for (int i=0 ; i<activites.Count ; i++)
                {
                    // we replace the value
                    if (activites[i].Equals(activity))
                    {
                        newval += activity + "_" + value + "|";
                    }
                    // we keep the old value
                    else if (!string.IsNullOrEmpty(oldval) && oldval.Split('|').Length > (i))
                    {
                        newval += oldval.Split('|')[i] + "|";
                    }
                    // we create an empty area 
                    else
                    {
                        newval += "|";
                    }
                }
                tableCSVkalendar[dayIndex][monthIndex] = newval;
            }
            catch (Exception exp7300)
            {
                Log.write("[ ERR : 7300 ] " + exp7300.Message);
            }
        }
        public string Get(int month, int day, string year, string activity)
        {
            try
            {
                if (tableCSVkalendar != null)
                {
                    string tmp = tableCSVkalendar[day][month];
                    foreach (string s in tmp.Split('|'))
                    {
                        if (s.Split('_')[0].ToLower().Equals(activity.ToLower()) && s.Split('_')[0].Length > 0) return s.Split('_')[1];
                    }
                }
            }
            catch (Exception exp7301)
            {
                Log.write("[ ERR : 7301 ] " + exp7301.Message);
            }
            return "";
        }
        public bool Save()
        {
            if (string.IsNullOrEmpty(kalendarPath))
            {
                Log.write("[ ERR : 8001 ] There is no path to save your calendar.");
                return false;
            }
            else
            {
                string output = "";
                try
                {
                    if (tableCSVkalendar != null && tableCSVkalendar.Count - 1 > 0)
                    {
                        foreach (List<string> ls in tableCSVkalendar)
                        {
                            string val = "";
                            foreach (string s in ls)
                            {
                                val += s + ";";
                            }
                            output += val + '\r'.ToString();
                        }
                        return WriteFile(output, kalendarPath);
                    }
                    return true;
                }
                catch (Exception exp8000)
                {
                    Log.write("[ ERR : 8000 ] Cannot save the user calendar.\n" + exp8000.Message);
                    return false;
                }
            }
        }
        public bool Load()
        {
            try
            {
                if (!File.Exists(kalendarPath))
                {
                    BuildKalendar();
                    return true;
                }
                else
                {
                    string input = ReadFile();
                        
                    List<string> listmonth;
                    string[] tb;
                    tb = input.Split('\r');
                    if (tb.Length < 7) MessageBox.Show("I think there is a problem in calendar file.\n I detect a low number of rows!", "Error on calendar file");
                    string[] tb_m;

                    if (user.My_Team == null) user.My_Team = new Team(user.IntCal, tb[0].Split(';')[0]);

                    int index = 0;
                    foreach (string line in tb)
                    {
                        // TODO : BUG fix the encoding 2 times \r so the kalendar is loaded twice
                        if (index < 33)
                        {
                            index++;
                            tb_m = line.Split(';');
                            listmonth = new List<string>();
                            for (int i = 0; i < 14; i++)
                            {
                                listmonth.Add(tb_m[i]);
                            }
                            if (tableCSVkalendar == null) tableCSVkalendar = new List<List<string>>();
                            tableCSVkalendar.Add(listmonth);
                        }
                    }
                    user.IntCal.OnLoad(null, null);
                    return true;
                }
            }
            catch (Exception exp7302)
            {
                Log.write("[ ERR : 7302 ] Cannot load user calendar.\n" + exp7302.Message);
                return false;
            }
        }
        #endregion

        #region Methods private
        private void BuildKalendar()
        {
            calendarData = "";
            if (user != null && user.My_Team != null) calendarData += user.My_Team.FilePath;
            calendarData += ";";
            foreach (string m in Month)
            {
                calendarData += m + "_" + DateTime.Now.Year;
                calendarData += ";";
            }
            calendarData += '\r'.ToString();
            for (int i = 1; i < 33; i++)
            {
                calendarData += i;
                calendarData += ";;;;;;;;;;;;;";
                calendarData += '\r'.ToString();
            }

            if (!File.Exists(this.KalendarPath))
            {
                try
                {
                    using (FileStream fs = File.Create(this.KalendarPath, 1024))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(calendarData);
                        fs.Write(info, 0, info.Length);
                    }
                }
                catch (Exception exp2900)
                {
                    Log.write("[ WRN : 2900 ] Cannot create the calendar file.\n" + exp2900.Message);
                }
            }
        }
        private string ReadFile()
        {
            if (!string.IsNullOrEmpty(this.kalendarPath))
            {
                string[] tmp = this.kalendarPath.Split(' ');
                if (tmp.Length > 0)
                {
                    string[] tmp2 = tmp[tmp.Length - 1].Split('-');
                    if (tmp2.Length > 0)
                    {
                        user.Name = tmp2[0];
                        user.Firstname = tmp2[1].Split('.')[0];
                    }
                }
            }

            string result = "";
            StreamReader sr = new StreamReader(kalendarPath);
            result = sr.ReadToEnd();
            sr.Close();
            return result;
        }
        private bool WriteFile(string val, string my_file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(kalendarPath);
                sw.Write(val);
                sw.Close();
                return true;
            }
            catch (Exception exp8003)
            {
                Log.write("[ WRN : 8003 ] " + exp8003.Message);
                return false;
            }
        }
        private bool IsFileUsed(string file)
        {
            try
            {
                FileStream fs;
                fs = File.Open(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                if (fs != null)
                {
                    //MessageBox.Show(fs.ToString());
                    fs.Close();
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                //Console.WriteLine(e.Message);
                //Thread.Sleep(1000);
                return true;
            }
        }
        #endregion
    }
}
