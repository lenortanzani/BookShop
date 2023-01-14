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
    public partial class SellBook : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public SellBook()  
        {
            InitializeComponent();

            cbSales.Items.Clear();
            string sqlSetSales =
                $"SELECT name FROM Books";
            List<string> salesList = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var setSales = new SqlCommand(sqlSetSales, connection);
                var readerSales = setSales.ExecuteReader();
                while (readerSales.Read())
                {
                    salesList.Add(readerSales.GetString(0));
                }
            }
            foreach (string element in salesList)
            {
                cbSales.Items.Add(new ComboBoxItem() { Content = element });
            }
        }

        private void SellBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                string sellableBook = ((ComboBoxItem)cbSales.SelectedItem).Content.ToString();

                string sqlSellBook = $"DELETE FROM Books WHERE name LIKE '%{sellableBook}%'";
                string sqlSalesNote = $"INSERT INTO Sales SELECT name, 1, price FROM Books WHERE name LIKE '%{sellableBook}%'";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var makeSelesNote = new SqlCommand(sqlSalesNote, connection);
                    makeSelesNote.ExecuteNonQuery();
                    var sellBook = new SqlCommand(sqlSellBook, connection);
                    sellBook.ExecuteNonQuery();
                }

                MessageBox.Show("The book was sold", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Select the book to sell", "Exclamation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowSalesBtn(object sender, RoutedEventArgs e)
        {
            ShowSales showSales = new ShowSales();
            showSales.ShowDialog();
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
