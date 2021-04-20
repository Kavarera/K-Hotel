using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{ 
    public static class Employee
    {
        private static string nama = "";
        private static string jobname = "";
        public static string ids { get; set; }
        public static string Username { get; set; }
        public static string Sandi{get;set;}
        public static string Nama{
            get { return nama; }
            set { nama = value; }
        }



        public static string JobName{
            get { return jobname; }
            set { switch (value) {
                    case "1":
                        jobname = "Front Office";
                        break;
                    case "2":
                        jobname = "Housekeeper";
                        break;
                    case "3":
                        jobname = "Housekeeper - Supervisor";
                        break;
                    case "4":
                        jobname = "Admin";
                        break;
                    default:
                        jobname = "ERROR-UNDEFINED JOB";
                        break;
                }


            }
        }

    }
}
