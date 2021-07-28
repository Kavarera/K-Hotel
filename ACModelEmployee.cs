using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Data.SqlClient;

namespace HotelApp
{
    public class ACModelEmployee
    {
        public static void addEmp(string uname, string sandi, string nama, string email, string alamat, string tglLahir, int jobid)
        {
            try
            {
                SqlConnection con = new SqlConnection(HotelApp.Helper.conval("thedb"));
                SqlCommand cmd = new SqlCommand($"INSERT INTO Employee(Username, Sandi, Nama, Email, Alamat, tglLahir, jobId) VALUES ('{uname}', '{sandi}', '{nama}'" +
                    $"'{email}', '{tglLahir}', '{jobid}')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void updateEmp(string uname, string sandi, string nama, string email, string alamat, string tglLahir, int jobid)
        {
            try
            {
                SqlConnection con = new SqlConnection(HotelApp.Helper.conval("thedb"));
                SqlCommand cmd = new SqlCommand($"UPDATE Employee" +
                    $"SET Username = '{uname}'," +
                    $"Sandi = '{MySHA256ENC.SHA256Enc.Get_Enc(sandi)}'," +
                    $"Nama = '{nama}'," +
                    $"Email = '{email}'," +
                    $"Alamat = '{alamat}'," +
                    $"tglLahir = '{tglLahir}'," +
                    $"jobId = '{jobid}'" +
                    $"WHERE Username = {uname} AND Nama = '{nama}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show($"Employee {nama} is updated");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public static void deleteEmp(string nama)
        {
            try
            {
                SqlConnection con = new SqlConnection(HotelApp.Helper.conval("thedb"));
                SqlCommand cmd = new SqlCommand($"DELETE FROM Employee WHERE Nama = '{nama}''");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show($"Employee {nama} is deleted..");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
