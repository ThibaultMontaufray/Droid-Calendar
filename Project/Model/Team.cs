// Log code 51 - 05

/*
 * User: Thibault MONTAUFRAY
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Tools4Libraries;

namespace Assistant
{
	/// <summary>
	/// Description of Team.
	/// </summary>
	public class Team
	{
		#region Attribute
		private string filePath;
		
		private string name;
		private string service;
		private string description;
		private string localisation;
		private string chief;
		private string compagny;
		private List<User> listUser;
		
		private Interface_calendar int_cal;
		#endregion
		
		#region Properties
		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
		}
		public string Compagny
		{
			get { return compagny; }
			set { compagny = value; }
		}
		public string Chief
		{
			get { return chief; }
			set { chief = value; }
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public string Service
		{
			get { return service; }
			set { service = value; }
		}
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
		public string Localisation
		{
			get { return localisation; }
			set { localisation = value; }
		}
		public List<User> ListUsers
		{
			get 
            {
                CleanTeamDoublons();
                return listUser; 
            }
			set { listUser = value; }
		}
		#endregion
		
		#region Constructor
		public Team(Interface_calendar ic)
		{
			int_cal = ic;
			listUser = new List<User>();
		}
		
		public Team(Interface_calendar ic, string path)
		{
			int_cal = ic;
			listUser = new List<User>();
			
			filePath = path;
			this.LoadTeam();
		}
		
		public Team(Interface_calendar ic, string my_name, string my_service, string my_description, string my_localisation)
		{
			int_cal = ic;
			name = my_name;
			service = my_service;
			description = my_description;
			localisation = my_localisation;
			
			listUser = new List<User>();
		}
		#endregion
		
		#region Methods public
		public User GetUser(string userDescription)
		{
			try
			{
				if (this.ListUsers != null)
				{
					foreach (User user in this.ListUsers)
					{
						if ((user != null) && (userDescription.Contains(user.Name)) && (userDescription.Contains(user.Firstname))) return user;
					}
				}
				return null;
			}
			catch (Exception exp5103)
			{
				Log.write("[ WRN : 5103 ] " + exp5103.Message);
				return null;
			}
		}
        public User GetUser(User usertocompare)
        {
            try
            {
                if (this.ListUsers != null)
                {
                    foreach (User user in this.ListUsers)
                    {
                        if ((user != null) && (usertocompare.Name.Equals(user.Name)) && (usertocompare.Firstname.Equals(user.Firstname))) return user;
                    }
                }
                return null;
            }
            catch (Exception exp5104)
            {
                Log.write("[ WRN : 5104 ] " + exp5104.Message);
                return null;
            }
        }
		public bool LoadTeam()
		{
			try
			{
				if (!string.IsNullOrEmpty(filePath))
				{
					string s = File.ReadAllText(filePath.ToString());
					LoadTeamSettings(s.Split('\n'));
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception exp5002)
			{
				Log.write("[ ERR : 5002 ] Cannot load Team.\n" + exp5002.Message);
				return false;
			}
		}
		public bool LoadKalendars()
		{
			bool ret = true;
			bool ret_tmp;
			foreach (User u in listUser)
			{
				try
				{
					u.My_Team = this;
                    ret_tmp = u.LoadKalendar();
					if (!ret_tmp) ret = false;
				}
				catch (Exception exp5100)
				{
					Log.write("[ WRN : 5100 ] Cannot load user calendar for " + u.Name + ".\n" + exp5100.Message);
					ret = false;
				}
			}
			return ret;
		}
		public void AddUser(User u)
		{
			listUser.Add(u);
		}
        public void CopyUsersTo(List<User> lu)
        {
            foreach (User u in this.listUser)
            {
                lu.Add(new User(u));
            }
        }
		public bool SaveTeam(Team t)
		{
			string output = "";
			output += "<team>\n";

			if (int_cal.ListActivities.Count < 1)
			{
				output += "<activity name=\"Congé payés\" value=\"CPA\" color=\"Yellow\" />\n";
				output += "<activity name=\"Equivalent jour repos\" value=\"EJR\" color=\"LawnGreen\" />\n";
				output += "<activity name=\"Récupération\" value=\"REC\" color=\"Red\" />\n";
				output += "<activity name=\"Congé non payés\" value=\"CNP\" color=\"DarkViolet\" />\n";
				output += "<activity name=\"Travail temps partiel\" value=\"TPA\" color=\"Cyan\" />\n";
			}
			else
			{
				foreach (string  act in int_cal.ListActivities)
				{
					output += "\t<activity";
					output += " name=\"" + act.Split('|')[0] + "\"";
					output += " value=\"" + act.Split('|')[1] + "\"";
					output += " color=\"" + act.Split('|')[2] + "\" />\n";
				}
			}
			output += "\t<name value=\"" + t.name + "\" />\n";
			output += "\t<service value=\"" + t.service + "\" />\n";
			output += "\t<localisation value=\"" + t.localisation + "\" />\n";
			output += "\t<chief value=\"" + t.chief + "\" />\n";
			output += "\t<compagny value=\"" + t.compagny + "\" />\n";
			output += "\t<description value=\"" + t.description + "\" />\n";
			
			output += "\t<export_oncall value=\"";
			foreach (string element in int_cal.ExportsList)
			{
				output += element + ";";
			}
            output += "\" />\n";
            output += "\t<export_filename value=\"" + this.int_cal.ExportFileName + "\" />\n";
            output += "\t<export_options header=\"" + this.int_cal.ExportHeader + "\" />\n";
			
			foreach (User u in t.listUser)
			{
				output += "\t<user";
				output += " name=\"" + u.Name + "\"";
                output += " firstname=\"" + u.Firstname + "\"";
                output += " matricule=\"" + u.Matricule + "\"";
                output += " manager=\"" + u.Manager + "\"";
                output += " avatar=\"" + u.Avatar + "\"";
                output += " country=\"" + u.Country + "\"";
                output += " calendarFamilly=\"" + u.CalendarFamilly + "\"";
                output += " role=\"" + u.Role + "\"";
				output += " arrivaldate=\"" + u.ArrivalDate + "\"";
                output += " calendarpath=\"" + u.Kalendar.KalendarPath + "\"";
                output += " picturepath=\"" + u.PicturePath + "\" />\n";
            }
			output += "</team>\n";
            try
            {
                using (StreamWriter outfile = new StreamWriter(t.filePath))
                {
                    outfile.Write(output);
                }
                return true;
            }
            catch (Exception exp5105)
            {
                Log.write("[ ERR : 5105 ] Cannot record the file.\n" + exp5105.Message);
                return false;
            }
		}
        public void Update(User u)
        {
            foreach (User u_tmp in this.listUser)
            {
                if (u_tmp.Equals(u))
                {
                    u_tmp.Copy(u);
                    break;
                }
            }
        }
        public bool Contains(User u)
        {
            foreach (User u_tmp in this.listUser)
            {
                if (u_tmp.Equals(u)) return true;
            }
            return false;
        }
        public void CleanTeamDoublons()
        {
            bool completed = false;
            List<string> thelist = new List<string>();
            while (!completed)
            {
                thelist.Clear();
                completed = true;
                foreach (User u in listUser)
                {
                    if (u.Name == null)
                    {
                        listUser.Remove(u);
                        completed = false;
                        break;
                    }
         
                    if (thelist.Contains(u.Name + u.Firstname + u.Matricule))
                    {
                        listUser.Remove(u);
                        completed = false;
                        break;
                    }
                    else thelist.Add(u.Name + u.Firstname + u.Matricule);
                }
            }
        }
		#endregion
		
		#region Methods private
		private void LoadTeamSettings(string[] text)
		{
			try
			{
				bool flagTeam = false;
				User user;
				int_cal.ListActivities.Clear();
				int_cal.ExportsList.Clear();
				
				foreach (string line in text)
				{
					if(line.Contains("</team>")) flagTeam = false;
					if(line.Contains("<team>")) flagTeam = true;
					
					if(flagTeam)
					{
						if (line.Replace('\t', ' ').Contains("<export_oncall value="))
						{
							if(line.Split('"').Length>0)
							{
								string s;
								s = line.Split('"')[1];
								foreach (string element in s.Split(';'))
								{
									if (!string.IsNullOrEmpty(element)) int_cal.ExportsList.Add(element);
								}
							}
						}
						if (line.Replace('\t', ' ').Contains("<activity name="))
						{
							if(line.Split('"').Length>4)
							{
								string s;
								s = line.Split('"')[1];
								s += "|";
								s += line.Split('"')[3];
								s += "|";
								s += line.Split('"')[5];
								int_cal.ListActivities.Add(s);
							}
                        }
                        if (line.Replace('\t', ' ').Contains("<export_filename value="))
                        {
                            if (line.Split('"').Length > 0) this.int_cal.ExportFileName = line.Split('"')[1];
                        }
                        if (line.Replace('\t', ' ').Contains("<export_options"))
                        {
                            if (line.Split('"').Length > 0)
                            {
                                if (line.Split('"')[1].ToLower().Equals("true")) this.int_cal.ExportHeader = true;
                                else this.int_cal.ExportHeader = false;
                            }
                        }
						if (line.Replace('\t', ' ').Contains("<name value="))
						{
							if(line.Split('"').Length>0) this.name = line.Split('"')[1];
						}
						if (line.Replace('\t', ' ').Contains("<compagny value="))
						{
							if(line.Split('"').Length>0) this.compagny = line.Split('"')[1];
						}
						if (line.Replace('\t', ' ').Contains("<chief value="))
						{
							if(line.Split('"').Length>0) this.chief = line.Split('"')[1];
						}
						if (line.Replace('\t', ' ').Contains("<service value="))
						{
							if(line.Split('"').Length>0) this.service = line.Split('"')[1];
						}
						if (line.Replace('\t', ' ').Contains("<localisation value="))
						{
							if(line.Split('"').Length>0) this.localisation = line.Split('"')[1];
						}
						if (line.Replace('\t', ' ').Contains("<description value="))
						{
							if(line.Split('"').Length>0) this.description = line.Split('"')[1];
						}
						if (line.Replace('\t', ' ').Contains("<user"))
						{
                            int tmp = 0;
							user = new User(int_cal);
							this.listUser.Add(user);
							if(line.Split('"').Length>20)
							{
								user.Name = line.Split('"')[1];
								user.Firstname = line.Split('"')[3];
								user.Matricule = line.Split('"')[5];
                                int.TryParse(line.Split('"')[7], out tmp);
                                user.Manager = tmp;
                                user.Avatar = line.Split('"')[9];
                                user.Country = line.Split('"')[11];
                                user.CalendarFamilly = line.Split('"')[13];
                                user.Role = line.Split('"')[15];
                                user.ArrivalDate = line.Split('"')[17];
                                user.Kalendar.KalendarPath = line.Split('"')[19];
                                user.PicturePath = line.Split('"')[21];
								user.My_Team = this;
							}
						}
					}
				}
			}
			catch (Exception exp5101)
			{
                Log.write("[ ERR : 5001 ] We cannot load the team calendar.\n" + exp5101.Message);
			}
		}
		#endregion
	}
}
