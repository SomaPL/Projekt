using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Rental.xaml
    /// </summary>
    public partial class Rental : Page
    {
        public Rental()
        {
            InitializeComponent();
            BindingDataGrid();
        }

        private void BindingDataGrid()
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=ProjektDB;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM tblRental";
            cmd.Connection= sqlcon;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable("Wypożyczalnia");

            dataAdapter.Fill(dataTable);

            Grid1.ItemsSource = dataTable.DefaultView;
        }
    }
}
