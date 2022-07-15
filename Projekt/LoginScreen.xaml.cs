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
    /// Logika interakcji dla klasy LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=ProjektDB;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            string data = "SELECT * FROM tblLogin WHERE Username=@Username AND Password=@Password";
            SqlCommand sqlCmd = new SqlCommand(data, sqlcon);

            sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
            sqlCmd.ExecuteNonQuery();
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            sqlcon.Close();

            txtUsername.Text = "";
            txtPassword.Password = "";
            if (count > 0)
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Login albo hasło jest niepoprawne");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen register = new RegisterScreen();
            this.Close();
            register.Show();
        }
    }
}
