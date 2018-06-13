using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Microsoft.VisualBasic;

namespace FEUHS_AMS
{
    class Admin : XDLINE
    {
        public static string UserID = "";
        public void loadAccountlist(ListView lv)
        {
            List<string>[] accountlist = this.selectItems("users_table","user_id,username,account_type,first_name,last_name,middle_name,extension", 
               new string[] {"user_id", "username","account_type", "first_name", "last_name","middle_name", "extension"},"account_type = 'teacher' Or account_type = 'admin'");

           
            lv.Items.Clear();
            string[] user_id, username, account_type, first_name, last_name, middle_name, extension;
            int numberofQueries = accountlist.ElementAt(0).Count;

            user_id = new string[numberofQueries];
            username = new string[numberofQueries];
            account_type = new string[numberofQueries];
            first_name = new string[numberofQueries];
            last_name = new string[numberofQueries];
            middle_name = new string[numberofQueries];
            extension = new string[numberofQueries];
         

            int i = 0;
            foreach (List<string> d in accountlist)
            {
                int j = 0;
                foreach (string value in d)
                {
                    switch (i)
                    {
                        case 0:
                            user_id[j] = value;
                            break;
                        case 1:
                            username[j] = value;
                            break;
                        case 2:
                            account_type[j] = value;
                            break;
                        case 3:
                            first_name[j] = value;
                            break;
                        case 4:
                            last_name[j] = value;
                            break;
                        case 5:
                            middle_name[j] = value;
                            break;
                        case 6:
                            extension[j] = value;
                            break;
                        default:
                            break;
                    }
                    j++;
                }
                i++;
            }

            for (int h = 0; h <= numberofQueries - 1; h++)
            {
                lv.Items.Add(new Accounts{
                    User_ID = user_id[h],
                    Username = username[h],
                    Account_Type = account_type[h],
                    First_Name = first_name[h],
                    Last_Name = last_name[h],
                    Middle_Name = middle_name[h],
                    Extension = extension[h]                 
                });
            }
        }

    }

    public class Accounts
    {
        public static string account_edit_status = "EDITING...";
        public string User_ID { get; set; }
        public string Username { get; set; }
        public string Account_Type { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Extension { get; set; }
    }

    
}
