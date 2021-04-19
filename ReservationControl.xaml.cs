using System;
using System.Collections.Generic;
using System.Data;
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

using System.Configuration;
using System.Data.SqlClient;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for ReservationControl.xaml
    /// </summary>
    public partial class ReservationControl : UserControl
    {
        
        public ReservationControl()
        {

            InitializeComponent();


            StartDate.


            #region cadangan
            //ReservationPanel.Width = 1080;

            //btn_kiri.Content = "<<";
            //btn_kanan.Content = ">>";

            //LoadRoomType();
            //LoadItem();
            #endregion
        }






























        //private DataView SearchExistRoom(string rt)
        //{
        //    SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand($"SELECT RoomNumber ,  RoomFloor , Description FROM Room WHERE Status = 'Empty' AND RoomType = {rt}",con);
        //    cmd.ExecuteNonQuery();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable("ExistRoom");
        //    sda.Fill(dt);
        //    con.Close();
        //    return dt.DefaultView;
        //}


        //private void LoadItem()
        //{
        //    SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        //    con.Open();
        //    SqlDataReader sdr = new SqlCommand($"SELECT Nama FROM Item", con).ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        cb_RequestAdditionalItems.Items.Add(sdr["Nama"]).ToString();
        //    }
        //    sdr.Close();
        //    con.Close();

        //}

        //private void LoadRoomType()
        //{
        //    SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        //    con.Open();
        //    SqlDataReader sdr = new SqlCommand("SELECT Nama , Capacity ,  RoomPrice FROM RoomType",con).ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        cb_RoomType.Items.Add(sdr["Nama"].ToString());
        //    }
        //    sdr.Close();
        //    con.Close();
        //}

        //private void SearchExistCustomer(SqlConnection con, string CustomerName)
        //{
        //    SqlCommand cmd = new SqlCommand($"SELECT NAMA , NIK ,  GENDER , PHONE FROM Customer WHERE NAMA LIKE '%{CustomerName}%'",con);
        //    cmd.ExecuteNonQuery();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable("CustomerName");
        //    sda.Fill(dt);

        //    dg_CustomerData.ItemsSource = dt.DefaultView;


        //}

        //private void tb_UserSearch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        //    con.Open();
        //    SearchExistCustomer(con, tb_UserSearch.Text.ToString());
        //    con.Close();
        //}

        //private void btn_search_Click(object sender, RoutedEventArgs e)
        //{

        //    string rtId="";
        //    SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand($"SELECT ID FROM RoomType WHERE Nama = '{cb_RoomType.SelectedItem.ToString()}'",con);
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.Read())
        //    {
        //        rtId = sdr["ID"].ToString();
        //    }
        //    con.Close();

        //    dg_ListAvalaibleRooms.ItemsSource = SearchExistRoom(rtId);


        //}

        //private DataTable createDataTable(string nama, string header1, string header2, string header3)
        //{
        //    DataTable dt = new DataTable(nama);
        //    dt.Columns.Add(header1);
        //    dt.Columns.Add(header2);
        //    dt.Columns.Add(header3);

        //    return dt;
        //}


        //private void btn_kanan_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
