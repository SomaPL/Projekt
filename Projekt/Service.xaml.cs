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
    /// Logika interakcji dla klasy Service.xaml
    /// </summary>
    public partial class Service : Page
    {
        public Service()
        {
            InitializeComponent();
            BindingDataGrid();
        }
        /// <summary>
        /// Wyświetlenie zawartoście tabeli
        /// </summary>
        private void BindingDataGrid()
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=ProjektDB;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM tblService";
            cmd.Connection = sqlcon;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable("Serwis");

            dataAdapter.Fill(dataTable);

            Grid1.ItemsSource = dataTable.DefaultView;
        }

        /// <summary>
        /// Dodanie warrtości do tabeli
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddValues(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=ProjektDB;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblService (Auto,OpisProblemu,DataPrzyjecia) VALUES (@Auto,@OpisProblemu,@DataPrzyjecia)", sqlcon);


            cmd.Parameters.AddWithValue("@Auto",txtAuto.Text);
            cmd.Parameters.AddWithValue("@OpisProblemu", txtOpisProblemu.Text);
            cmd.Parameters.AddWithValue("@DataPrzyjecia", dateDataPrzyjecia.SelectedDate);
            cmd.ExecuteNonQuery();
            BindingDataGrid();
        }
    }
}
