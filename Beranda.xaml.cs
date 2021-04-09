﻿using System;
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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for Beranda.xaml
    /// </summary>
    public partial class Beranda : Window
    {

        double mpWidth;
        ReservationControl RC = new ReservationControl();

        public Beranda(MainWindow mw)
        {
            InitializeComponent();
            //mw = new MainWindow();
            //MessageBox.Show(mw.Status.ToString(),"!");
            //MessageBox.Show(mw.Status.ToString());
            if (!mw.Status)
            {
                MessageBox.Show(mw.Status.ToString(), "Authentication Error!");
            }


            //Set MP WIDTH
            mpWidth = BerandaWindow.Width;



            lbl_username.Content = mw.karyawan.Nama;
            lbl_JobName.Content = mw.karyawan.JobName;
            var Converter = new System.Windows.Media.BrushConverter();


            switch (lbl_JobName.Content)
            {
                case "Front Office":
                    button1.Content = "Reservation";
                    button2.Content = "Check In";
                    button3.Content = "Request Additional Items";
                    button3.FontSize = 7;
                    button4.Content = "Check Out";
                    button5.Content = "Master Room Type";
                    button5.FontSize = 7;
                    button6.Content = "Master Room";
                    button6.FontSize = 7;
                    button7.FontSize = 7;
                    button7.Content = "Master Item";
                    break;

                case "Housekeeper - Supervisor":
                    button1.Content = "Add Housekeeping Schedule";
                    button1.FontSize = 7;
                    baratas.Background = (Brush)Converter.ConvertFromString("#F08CFF");

                    #region turnoffbutton
                    button2.Visibility = Visibility.Collapsed;
                    button3.Visibility = Visibility.Collapsed;
                    button4.Visibility = Visibility.Collapsed;
                    button5.Visibility = Visibility.Collapsed;
                    button6.Visibility = Visibility.Collapsed;
                    button7.Visibility = Visibility.Collapsed;
                    button2.IsEnabled = false;
                    button3.IsEnabled = false;
                    button4.IsEnabled = false;
                    button5.IsEnabled = false;
                    button6.IsEnabled = false;
                    button7.IsEnabled = false;
                    #endregion
                    break;
                case "Admin":
                    button1.Content = "Master Employee";
                    button1.FontSize = 12;
                    baratas.Background = (Brush)Converter.ConvertFromString("#008CFF");

                    #region turnoffbutton
                    button2.Visibility = Visibility.Collapsed;
                    button3.Visibility = Visibility.Collapsed;
                    button4.Visibility = Visibility.Collapsed;
                    button5.Visibility = Visibility.Collapsed;
                    button6.Visibility = Visibility.Collapsed;
                    button7.Visibility = Visibility.Collapsed;
                    button2.IsEnabled = false;
                    button3.IsEnabled = false;
                    button4.IsEnabled = false;
                    button5.IsEnabled = false;
                    button6.IsEnabled = false;
                    button7.IsEnabled = false;
                    #endregion
                    break;

                case "Housekeeper":
                    button1.Content = "Cleaning Room";
                    button1.FontSize = 12;
                    baratas.Background = (Brush)Converter.ConvertFromString("#39DF8D");

                    #region turnoffbutton
                    button2.Visibility = Visibility.Collapsed;
                    button3.Visibility = Visibility.Collapsed;
                    button4.Visibility = Visibility.Collapsed;
                    button5.Visibility = Visibility.Collapsed;
                    button6.Visibility = Visibility.Collapsed;
                    button7.Visibility = Visibility.Collapsed;
                    button2.IsEnabled = false;
                    button3.IsEnabled = false;
                    button4.IsEnabled = false;
                    button5.IsEnabled = false;
                    button6.IsEnabled = false;
                    button7.IsEnabled = false;
                    #endregion
                    break;


                default:
                    button1.Visibility = Visibility.Collapsed;
                    button2.Visibility = Visibility.Collapsed;
                    button3.Visibility = Visibility.Collapsed;
                    button4.Visibility = Visibility.Collapsed;
                    button5.Visibility = Visibility.Collapsed;
                    button6.Visibility = Visibility.Collapsed;
                    button7.Visibility = Visibility.Collapsed;
                    button1.IsEnabled = false;
                    button2.IsEnabled = false;
                    button3.IsEnabled = false;
                    button4.IsEnabled = false;
                    button5.IsEnabled = false;
                    button6.IsEnabled = false;
                    button7.IsEnabled = false;
                    break;

            }


            System.Threading.Thread.Sleep(500);



            this.Show();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BerandaWindow.Opacity = 0;
            //BerandaWindow.BeginAnimation(WidthProperty, new DoubleAnimation(1, 900, TimeSpan.FromSeconds(1)));
            BerandaWindow.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.7)));

        }

        private void tg_btn_ham_Checked(object sender, RoutedEventArgs e)
        {


            Sidebar.BeginAnimation(WidthProperty, new DoubleAnimation(50, 200, TimeSpan.FromSeconds(1)));
            if (button1.Content.ToString()=="Reservation")
            {

                RC.BeginAnimation(WidthProperty, new DoubleAnimation(RC.Width, BerandaWindow.Width - 200, TimeSpan.FromSeconds(1)));
            }


        }

        private void tg_btn_ham_Unchecked(object sender, RoutedEventArgs e)
        {
            Sidebar.BeginAnimation(WidthProperty, new DoubleAnimation(200, 50, TimeSpan.FromSeconds(1)));

            if (button1.Content.ToString() == "Reservation")
            {

                RC.BeginAnimation(WidthProperty, new DoubleAnimation(RC.Width, BerandaWindow.Width - 50, TimeSpan.FromSeconds(1)));
            }


        }
        
        

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        bool btn1= false;

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            if (button1.Content.ToString() == "Reservation")
            {
                if(btn1)
                {
                    MainPanel.Children.Remove(RC);
                    btn1 = false;
                    
                }
                else
                {
                    MainPanel.Children.Add(RC);
                    btn1 = true;
                }
            }

        }
    }
}
