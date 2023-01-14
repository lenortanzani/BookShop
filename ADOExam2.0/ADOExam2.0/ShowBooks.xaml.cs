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
    public partial class ShowBooks : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public ShowBooks()
        {
            InitializeComponent();         
            ShowBooksBtn(null, null);
        }
        private void ShowBooksBtn(object sender, RoutedEventArgs e)
        {
            string sqlBooks =
                "SELECT B.name 'Book', S.name 'Series' , B.series_number 'Series number', G.name 'Genre', A.name 'Author', B.pages 'Pages', " +
                "B.publication_year 'Publication year', P.name 'Publisher', B.cost_price 'Cost price', B.price 'Price' " +
                "FROM Books B " +
                "JOIN Series S ON S.id = B.series_id " +
                "JOIN Genres G ON G.id = B.genre_id " +
                "JOIN Authors A ON A.id = B.author_id " +
                "JOIN Publishers P ON P.id = B.publisher_id";

            //string testString = "SELECT *  FROM Books"; // reserve

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlBooks, connection);
                SqlDataAdapter adapterBooks = new SqlDataAdapter(command);
                DataTable dtBooks = new DataTable("Books");
                adapterBooks.Fill(dtBooks);
                dgShownBooks.ItemsSource = dtBooks.DefaultView;
            }
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
