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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace ADOExam2._0
{
    public partial class ShowSales : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public ShowSales()
        {
            InitializeComponent();
            ShowSalesBtn(null, null);
        }
        private void ShowSalesBtn(object sender, RoutedEventArgs e)
        {
            string sqlShowSales =
                "SELECT name 'Book', amount 'Amount', price 'Price' FROM Sales";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlShowSales, connection);
                SqlDataAdapter adapterSales = new SqlDataAdapter(command);
                DataTable dtSales = new DataTable("Sales");
                adapterSales.Fill(dtSales);
                dgSalesList.ItemsSource = dtSales.DefaultView;
            }
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
