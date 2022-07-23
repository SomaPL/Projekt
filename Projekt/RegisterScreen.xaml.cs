using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        public RegisterScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Połącznie z bazą oraz dodanie nowej osoby
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=localhost;Initial Catalog=ProjektDB;Integrated Security=True";
                SqlConnection sqlcon = new SqlConnection(connectionString);
                sqlcon.Open();
                string data = "INSERT INTO tblLogin VALUES (@Username,@Password)";
                SqlCommand sqlCmd = new SqlCommand(data, sqlcon);

                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                sqlCmd.ExecuteNonQuery();

                sqlcon.Close();

                txtUsername.Text = "";
                txtPassword.Password = "";
                LoginScreen login = new LoginScreen();
                this.Close();
                login.Show();
            }

            catch
            {
            }
        }
    }
}
