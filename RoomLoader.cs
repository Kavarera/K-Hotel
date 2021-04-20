using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace HotelApp
{
    public static class RoomLoader
    {
        

        public static string getID(SqlConnection con, string TableName, string Nama, string RoomType = "RoomType", int RoomID = 0)
        {
            
            con.Open();

            if (RoomType == "Room")
            {

                SqlCommand cmd = new SqlCommand($"SELECT ID FROM {TableName} WHERE Nama = '{Nama}' Status = 'Empty'", con);
                var result = cmd.ExecuteScalar();
                con.Close();
                return result.ToString();


            }

            else if (RoomType == "RoomType")
            {

                SqlCommand cmd = new SqlCommand($"SELECT ID FROM {TableName} WHERE Nama = '{Nama}'", con);
                var result = cmd.ExecuteScalar();
                con.Close();
                return result.ToString();

            }

            else if(RoomType == "ReservationRoom")
            {
                SqlCommand cmd = new SqlCommand($"SELECT ID FROM {TableName} WHERE RoomID = '{RoomID}'", con);
                var result = cmd.ExecuteScalar();
                con.Close();
                return result.ToString();
            }

            else
                con.Close();
                return "Error RoomLoader-1";

        }


        public static int getPrice(SqlConnection con, string Nama)
        {

            int result;
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT RoomPrice FROM RoomType WHERE Nama = '{Nama}");
            return result = Int32.Parse(cmd.ExecuteScalar().ToString());

        }


    }
}
