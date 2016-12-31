// Log code : 80 - 04

/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows;

namespace Assistant
{
	/// <summary>
	/// Description of User.
	/// </summary>
	public class User
	{
		#region Attribute
		private string name;
		private string firstname;
		private string role;
		private string matricule;
		private string arrivalDate;
        private string picturePath;
        private string country;
        private string avatar;
        private string calendarFamilly;
        private int level;
        private int manager;

        private Kalendar kalendar;
		private Team my_team;
		
		private bool modified;
        private Interface_calendar int_cal;
        #endregion
		
		#region Properties
        public string PicturePath
        {
            get { return picturePath; }
            set { picturePath = value; }
        }
        public int Level
        {
            get 
            {
                return CalcLevel(); 
            }
        }
        public int Manager
        {
            get { return manager; }
            set { manager = value; }
        }
        public string Avatar
        {
            get {
                if (avatar == null) return "Default";
                return avatar; 
            }
            set { avatar = value; }
        }
        public string CalendarFamilly
        {
            get {
                if (calendarFamilly == null) return calendarFamilly;
                return calendarFamilly; 
            }
            set { calendarFamilly = value; }
        }
        public bool Modified
		{
			get { return modified; }
			set { modified = value; }
		}
		public Team My_Team
		{
			get { return my_team; }
			set { my_team = value; }
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public string Firstname
		{
			get { return firstname; }
			set { firstname = value; }
		}
		public string Matricule
		{
			get { return matricule; }
			set { matricule = value; }
		}
		public string Role
		{
			get { return role; }
			set { role = value; }
		}
		public string ArrivalDate
		{
			get { return arrivalDate; }
			set { arrivalDate = value; }
		}
        public Interface_calendar IntCal
        {
            get { return int_cal; }
            set { int_cal = value; }
        }
        public Kalendar Kalendar
        {
            get { return kalendar; }
            set { kalendar = value; }
        }
        public string Country
        {
            get {
                if (country == null) return country;
                return country; 
            }
            set { country = value; }
        }
		#endregion
		
		#region Constructor
        public User(User u)
        {
            name = u.name;
            firstname = u.firstname;
            role = u.role;
            matricule = u.matricule;
            manager = u.manager;
            avatar = u.avatar;
            country = u.country;
            calendarFamilly = u.calendarFamilly;
            arrivalDate = u.arrivalDate;
            kalendar = new Kalendar(u);
            my_team = u.my_team;
            BuildUserCalendar();
        }
        public User(Interface_calendar ic)
        {
            int_cal = ic;
            BuildUserCalendar();
        }
        public User(Interface_calendar ic, string myPath)
        {
            string path = myPath.Split('\\')[myPath.Split('\\').Length - 1];
            if (path.Split(' ').Length > 1)
            {
                if (path.Split(' ')[1].Split('-').Length > 1)
                {
                    this.name = path.Split(' ')[1].Split('-')[0];
                    this.firstname = path.Split(' ')[1].Split('-')[1];
                }
            }

            int_cal = ic;
            modified = false;
            kalendar = new Kalendar(this, myPath);
        }
        public User(Interface_calendar ic, string my_name, string my_firstname, string my_matricule, string my_country, string my_calFam, string my_role, string my_arrivaldate, Kalendar my_kalendar, Team t)
		{
			int_cal = ic;
			modified = false;
			name = my_name;
			firstname = my_firstname;
            role = my_role;
            country = my_country;
            calendarFamilly = my_calFam;
            matricule = my_matricule;
			arrivalDate = my_arrivaldate;
			my_team = t;
			kalendar = my_kalendar;
            BuildUserCalendar();
		}
		#endregion
		
		#region Methods public
        public void Copy(User u)
        {
            name = u.name;
            firstname = u.firstname;
            role = u.role;
            matricule = u.matricule;
            manager = u.manager;
            avatar = u.avatar;
            country = u.country;
            calendarFamilly = u.calendarFamilly;
            arrivalDate = u.arrivalDate;
            //kalendar = new Kalendar(u);
            my_team = u.my_team;
        }
		public bool LoadKalendar()
		{
            return kalendar.Load();
		}
		public void AddKal(int y, int x, string s)
		{
            kalendar.Set(x, y, "2014", s);
		}
        public bool SaveKalendar()
		{
            return kalendar.Save();
		}
        //public bool SaveKalendar()
        //{
        //    if(string.IsNullOrEmpty(kalendarPath))
        //    {
        //        Log.write("[ ERR : 8001 ] There is no path to save your calendar.");
        //        return false;
        //    }
        //    else
        //    {
        //        string output = "";
        //        try
        //        {
        //            if (Kalendar != null && Kalendar.Count > 0)
        //            {
        //                for(int j=0 ; j< Kalendar[0].Count - 1 ; j++)
        //                {
        //                    for (int i = 0; i < Kalendar.Count - 1; i++)
        //                    {
        //                        for (int k = 0; k < Kalendar.Count - 1; k++)
        //                        {
        //                            output += Kalendar[k][i] + ";";
        //                        }
        //                        output += '\r';
        //                    }
        //                }
        //                return WriteFile(output, KalendarPath, null);
        //            }
        //            return false;
        //        }
        //        catch (Exception exp8000)
        //        {
        //            Log.write("[ ERR : 8000 ] Cannot save the user calendar.\n" + exp8000.Message);
        //            return false;
        //        }
        //    }
        //}
        public bool Equals(User u)
        {
            if (u != null && u.name != null && u.name.Equals(this.name) && u.firstname != null && u.firstname.Equals(this.firstname)) return true;
            else return false;
        }
        public bool Equals(string the_name, string the_first_name)
        {
            if (the_name.Equals(this.name) && the_first_name.Equals(this.firstname)) return true;
            else return false;
        }
        public void BuildUserCalendar()
        {
            kalendar = new Kalendar(this);
        }
		#endregion
		
		#region Methods private
        private int CalcLevel()
        {
            int point = 0;
            if (arrivalDate != null) 
            {
                if (arrivalDate.Split(' ').Length > 2)
                {
                    int year, month, day;
                    int.TryParse(arrivalDate.Split(' ')[3], out year);
                    int.TryParse(arrivalDate.Split(' ')[1], out day);
                    switch (arrivalDate.Split(' ')[2].ToLower())
                    {
                        case "janvier": month = 1; break;
                        case "fevrier": month = 2; break;
                        case "mars": month = 3; break;
                        case "avril": month = 4; break;
                        case "mai": month = 5; break;
                        case "juin": month = 6; break;
                        case "juillet": month = 7; break;
                        case "aout": month = 8; break;
                        case "septembre": month = 9; break;
                        case "octobre": month = 10; break;
                        case "novembre": month = 11; break;
                        case "decembre": month = 12; break;
                        default: month = 1; break;
                    }
                    DateTime dt = new DateTime(year, month, day);
                    point += ((DateTime.Now - dt).Days) / 30;
                }
            }

            // skill matrix

            // management
            point += manager * 1;

            // level steps
            if (point > 1000) point = 10;
            else if (point > 500) point = 9;
            else if (point > 300) point = 8;
            else if (point > 250) point = 7;
            else if (point > 200) point = 6;
            else if (point > 150) point = 5;
            else if (point > 100) point = 4;
            else if (point > 50) point = 3;
            else if (point > 25) point = 2;
            else if (point > 10) point = 1;
            else point = 0;
            
            return point;
        }
        #endregion
	}
}
