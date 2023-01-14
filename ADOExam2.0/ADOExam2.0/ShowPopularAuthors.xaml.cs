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
    public partial class ShowPopularAuthors : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public ShowPopularAuthors()
        {
            InitializeComponent();
            ShowPopularAuthorsBtn(null, null);
        }
        private void ShowPopularAuthorsBtn(object sender, RoutedEventArgs e)
        {
            string sqlShowPopularAuthors =
                "SELECT A.name 'Author' FROM Authors A WHERE isPopular = 'true'";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlShowPopularAuthors, connection);
                SqlDataAdapter adapterPopularAuthors = new SqlDataAdapter(command);
                DataTable dtPopularAuthors = new DataTable("Bestsellers");
                adapterPopularAuthors.Fill(dtPopularAuthors);
                dgShownAuthors.ItemsSource = dtPopularAuthors.DefaultView;
            }
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
