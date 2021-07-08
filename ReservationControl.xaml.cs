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
using System.Text.RegularExpressions;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for ReservationControl.xaml
    /// </summary>
    public partial class ReservationControl : UserControl
    {

        int RoomPrice, MoreItem1, MoreItem2=0;
        SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        public ReservationControl()
        {

            InitializeComponent();


            #region cadangan
            //ReservationPanel.Width = 1080;

            //btn_kiri.Content = "<<";
            //btn_kanan.Content = ">>";

            //LoadRoomType();
            //LoadItem();
            #endregion
        }

        private void ReservationPanel_Loaded(object sender, RoutedEventArgs e)
        {
            cb_LoadRoomType();
            LoadItems();

        }

        private void LoadItems()
        {
            try
            {
                con.Open();
                SqlDataReader sdr = new SqlCommand($"SELECT Nama FROM Items", con).ExecuteReader();
                while (sdr.Read())
                {
                    cb_moreitem1.Items.Add(sdr["Nama"].ToString());
                    cb_moreitem2.Items.Add(sdr["Nama"].ToString());
                }
                sdr.Close();
                con.Close();
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void cb_ClearRoomType()
        {
            //For beranda.xaml.cs
            cb_roomtype.Items.Clear();
        }

        private void cb_LoadRoomType()
        {
            try
            {
                con.Open();
                SqlDataReader sdr = new SqlCommand("SELECT Nama , Id FROM RoomType", con).ExecuteReader();
                while (sdr.Read())
                {
                    cb_roomtype.Items.Add(sdr["Nama"].ToString());
                }
                sdr.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void cb_roomtype_Selected(object sender, RoutedEventArgs e)
        {
            LoadRoomType();
        }

        private void LoadRoomType()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT  RoomNumber ,  RoomFloor , Description FROM Room WHERE RoomStatus = 'Empty' AND RoomTypeID = {RoomLoader.getID(con, "RoomType", cb_roomtype.SelectedItem.ToString())}", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable("ExistRoom");
                sda.Fill(dt);
                con.Close();
                dg_AddRoom.ItemsSource = dt.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            LoadRoomType();
        }

        private int calculateTotal()
        {
            return RoomPrice + MoreItem1 + MoreItem2;
        }

        private void dg_AddRoom_CurrentCellChanged(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)dg_AddRoom.SelectedItem;


            if(row != null)
            {
                tb_RoomNumber_AddRoom.Text = row.Row[0].ToString();
                tb_RoomFloors_AddRoom.Text = row.Row[1].ToString();
                tb_RoomType_AddRoom.Text = cb_roomtype.SelectedItem.ToString();
                try
                {
                    con.Open();
                    SqlDataReader sdr = new SqlCommand($"SELECT RoomPrice FROM RoomType WHERE Nama = '{cb_roomtype.SelectedItem.ToString()}'", con).ExecuteReader();
                    while (sdr.Read())
                    {
                        RoomPrice = Int32.Parse(sdr["RoomPrice"].ToString());
                    }
                    sdr.Close();
                    con.Close();
                    lbl_price.Content= calculateTotal();
                }
                catch(SqlException esql)
                {
                    con.Close();
                    MessageBox.Show(esql.ToString(),"SQL EXCEPTION!!!");
                }
                catch(Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.ToString());
                }
                
            }


        }

        private void labelNIK_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void labelPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb_nights_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb_moreitem1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cb_moreitem1.SelectedItem != null)
            {
                try
                {
                    con.Open();
                    SqlDataReader sdr = new SqlCommand($"SELECT RequestPrice FROM Items WHERE Nama = '{cb_moreitem1.SelectedItem.ToString()}'", con).ExecuteReader();
                    while (sdr.Read())
                    {
                        if (tb_moreitem1.Text != "")
                        {
                            MoreItem1 = Int32.Parse(sdr["RequestPrice"].ToString()) * Int32.Parse(tb_moreitem1.Text.ToString());
                        }
                    }
                    sdr.Close();
                    con.Close();
                    lbl_price.Content = calculateTotal().ToString();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message, cb_moreitem1.SelectedItem.ToString());
                }
            }
        }

        private void tb_moreitem2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cb_moreitem1.SelectedItem != null)
            {
                try
                {
                    con.Open();
                    SqlDataReader sdr = new SqlCommand($"SELECT RequestPrice FROM Items WHERE Nama = '{cb_moreitem2.SelectedItem.ToString()}'", con).ExecuteReader();
                    while (sdr.Read())
                    {
                        if (tb_moreitem2.Text != "")
                        {
                            MoreItem2 = Int32.Parse(sdr["RequestPrice"].ToString()) * Int32.Parse(tb_moreitem2.Text.ToString());
                        }
                    }
                    sdr.Close();
                    con.Close();
                    lbl_price.Content = calculateTotal().ToString();
                }

                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message, cb_moreitem2.SelectedItem.ToString());
                }
            }
        }

        private void tb_moreitem2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);


        }

        private void tb_moreitem1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
