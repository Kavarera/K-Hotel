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
using System.Windows.Media.Animation;
using System.Security.Cryptography;
using System.Data.SqlClient;

using MySHA256ENC;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Username
        {
            get { return tb_username.Text; }
        }



        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tb_username_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_username.Text == "Username")
            {
                tb_username.Clear();
            }
        }

        private void pb_box_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pb_box.Password == "Password")
            {
                pb_box.Clear();
            }
        }
        
        //public Employee karyawan = new Employee();
        
        private async void btn_login_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection con = new SqlConnection(Helper.conval("thedb"));
            SqlCommand cmd = new SqlCommand($"SELECT Sandi, ID , Nama , JobID , Username FROM Employee WHERE Username = '{tb_username.Text}'",con);
            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                   Employee.Nama = sdr["Nama"].ToString();
                   Employee.Sandi = sdr["Sandi"].ToString();
                   Employee.JobName = sdr["JobID"].ToString();
                   Employee.Username = sdr["Username"].ToString();
                    Employee.ids = sdr["ID"].ToString();
                }

                if (Employee.Sandi== MySHA256ENC.SHA256Enc.Get_Enc(pb_box.Password) && Employee.Username == tb_username.Text)
                {
                    con.Close();

                    this.Dispatcher.Invoke(() => LoginWindow.BeginAnimation(HeightProperty, new DoubleAnimation(450, 0, TimeSpan.FromSeconds(0.5))));

                    status = true;
                    await Task.Delay(485);

                    Beranda beranda = new Beranda(this);
                    this.Hide();
                }
                else
                {
                    borderluar.BorderBrush = Brushes.Red;
                    await Task.Delay(1000);
                    borderluar.BorderBrush = Brushes.Cyan;
                }
                sdr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"ERROR");
                this.Close();
            }

            //MessageBox.Show(startSHA256(pb_box.Password), startSHA256(pb_box.Password).Length.ToString());
            //Parallel.Invoke(() => LoginWindow.BeginAnimation(WidthProperty, new DoubleAnimation(400, 0, TimeSpan.FromSeconds(1))));
        }

        public void getback(bool setat)
        {
            if (setat)
            {
                this.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 400;
            doubleAnimation.Duration = TimeSpan.FromSeconds(0.7);
            LoginWindow.BeginAnimation(OpacityProperty,new DoubleAnimation(0,1,TimeSpan.FromSeconds(1)));
            LoginWindow.BeginAnimation(WidthProperty, doubleAnimation);

            try {
                SqlConnection con = new SqlConnection(Helper.conval("thedb"));
                con.Open();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            
        }
    }
}
