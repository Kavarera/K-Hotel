using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for CheckOutUControl.xaml
    /// </summary>
    public partial class CheckOutUControl : UserControl
    {
        SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        public CheckOutUControl()
        {
            InitializeComponent();
        }


        private bool checkRoomStat(string number)
        {
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(ID) FROM Room WHERE RoomStatus = 'Filled' AND RoomNumber = {number}", con);
            con.Open();
            bool ab = Convert.ToBoolean(cmd.ExecuteScalar());
            con.Close();
            return ab;
        }

        private void tb_RoomNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {

                MessageBox.Show(checkRoomStat(tb_RoomNumber.Text).ToString());
                if (checkRoomStat(tb_RoomNumber.Text))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand($"SELECT ID FROM Room WHERE RoomNumber = {tb_RoomNumber.Text}", con);
                        string roomid = cmd.ExecuteScalar().ToString();
                        cmd = new SqlCommand($"SELECT ReservationID FROM ReservationRoom WHERE RoomID = {roomid}", con);
                        string reservationid = cmd.ExecuteScalar().ToString();
                        cmd = new SqlCommand($"SELECT CustomerID FROM Reservation WHERE ID={reservationid}", con);
                        string customerid = cmd.ExecuteScalar().ToString();
                        cmd = new SqlCommand($"SELECT Nama FROM Customer WHERE ID = {customerid}", con);
                        tb_Name.Text = cmd.ExecuteScalar().ToString();
                        cmd = new SqlCommand($"SELECT RoomTypeID FROM Room WHERE ID = {roomid}", con);
                        cmd = new SqlCommand($"SELECT Nama FROM RoomType WHERE ID = {cmd.ExecuteScalar()}", con);
                        tb_RoomType.Text = cmd.ExecuteScalar().ToString();
                        SqlDataReader sdr = new SqlCommand($"SELECT CheckInDateTime , CheckOutDateTime FROM ReservationRoom WHERE ReservationID = {reservationid} AND RoomID={roomid}", con).ExecuteReader();
                        while (sdr.Read())
                        {
                            tb_CheckIn.Text = sdr["CheckInDateTime"].ToString().Substring(0, 10);
                            tb_CheckOut.Text = sdr["CheckOutDateTime"].ToString().Substring(0, 10);
                        }
                        con.Close();
                    }
                    catch(Exception ex)
                    {

                        MessageBox.Show(ex.Message, ex.Source);
                    }
                }
                else
                {

                    MessageBox.Show("Room number is invalid...","Wrong number");
                }
            }
        }

        private void Submit_btn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"UPDATE Room SET RoomStatus = 'Empty' WHERE RoomNumber = {tb_RoomNumber.Text}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
