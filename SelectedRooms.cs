using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    public class SelectedRooms
    {
        private DataTable dt;

        public SelectedRooms()
        {
            DataTable exampleDT = new DataTable("lalal");
            dt = exampleDT;
            dt.Columns.Add("Room Number");
            dt.Columns.Add("Room Floor");
            dt.Columns.Add("Description");
        }


        public DataTable DT
        {
            get { return dt; }
            set
            {

            }
        }


    }
}
