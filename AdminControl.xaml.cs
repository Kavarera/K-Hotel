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
using System.Data;

namespace HotelApp
{
    /// <summary>
    /// Interaction logic for AdminControl.xaml
    /// </summary>
    public partial class AdminControl : UserControl
    {
        SqlConnection con = new SqlConnection(Helper.conval("thedb"));
        public AdminControl()
        {
            InitializeComponent();
        }

        private void tb_dateofbirth_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_dateofbirth.ToolTip = "Year-Month-Days";
        }

        private void tb_nama_LostFocus(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(ID) FROM Employee WHERE Nama = '{tb_nama.Text}'", con);
            con.Open();
            if (Convert.ToBoolean(cmd.ExecuteScalar()))
            {
                btn_addOrUpdate.Content = "UPDATE";
                con.Close();
            }
            else
            {
                btn_addOrUpdate.Content = "ADD";
                con.Close();
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            ACModelEmployee.deleteEmp(tb_nama.Text);
        }

        private void loadDg()
        {
            /* COMMAND SQL JOIN
                        * SELECT Employee.Username AS USERNAME , Employee.Nama AS NAME , Employee.Email AS EMAIL , Employee.Alamat AS ADDRESS, Employee.tglLahir AS 'DATE OF BIRTH', Job.jobName AS Job FROM Employee
                       INNER JOIN Job ON Job.ID = Employee.jobId
                       */
            SqlCommand cmd = new SqlCommand($"SELECT Employee.Username AS USERNAME , Employee.Nama AS NAME , Employee.Email AS EMAIL , Employee.Alamat AS ADDRESS, Employee.tglLahir AS 'DATE OF BIRTH', Job.jobName AS Job FROM Employee " +
                $"INNER JOIN Job ON Job.ID = Employee.jobId", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable("Employee List");
            sda.Fill(dt);
            dg_employee.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void btn_addOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn_addOrUpdate.Content == "UPDATE")
            {
                if((string)pb_cpwd.Password== (string)pb_pwd.Password)
                {
                    ACModelEmployee.updateEmp(tb_username.Text, MySHA256ENC.SHA256Enc.Get_Enc((string)pb_cpwd.Password), tb_nama.Text, tb_email.Text, tb_address.Text, tb_dateofbirth.Text, Int32.Parse(tb_jobID.Text));
                }
                else
                {

                    MessageBox.Show("PASSWORD IS NOT MATCH!");
                }
            }
            else if ((string)btn_addOrUpdate.Content == "ADD")
            {
                if ((string)pb_cpwd.Password == (string)pb_pwd.Password)
                {
                    ACModelEmployee.updateEmp(tb_username.Text, MySHA256ENC.SHA256Enc.Get_Enc((string)pb_cpwd.Password), tb_nama.Text, tb_email.Text, tb_address.Text, tb_dateofbirth.Text, Int32.Parse(tb_jobID.Text));
                }
                else
                {
                    MessageBox.Show("PASSWORD IS NOT MATCH!");
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadDg();
        }
    }
}
