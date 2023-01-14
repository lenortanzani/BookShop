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
    public partial class SearchBook : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        enum SearchMode { byName = 0, byAuthor, byGenre}
        public SearchBook()
        {
            InitializeComponent();

        }
       
        private void SearchByName(object sender, RoutedEventArgs e)            
        {
            string bookName = bookToSearch.Text.ToString();
            string sqlSearchByName =
                $"SELECT B.name 'Book', S.name 'Series' , B.series_number 'Series number', G.name 'Genre', A.name 'Author', B.pages 'Pages', " +
                $"B.publication_year 'Publication year', P.name 'Publisher', B.cost_price 'Cost price', B.price 'Price' " +
                $"FROM Books B " +
                $"JOIN Series S ON S.id = B.series_id " +
                $"JOIN Genres G ON G.id = B.genre_id " +
                $"JOIN Authors A ON A.id = B.author_id " +
                $"JOIN Publishers P ON P.id = B.publisher_id " +
                $"WHERE B.name LIKE '%{bookName}%'";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSearchByName, connection);
                SqlDataAdapter adapterFoundBooks = new SqlDataAdapter(command);
                DataTable dtFoundBooks = new DataTable("FoundBooks1");
                adapterFoundBooks.Fill(dtFoundBooks);
                dgFoundBooks.ItemsSource = dtFoundBooks.DefaultView;
            }
        }

        private void SearchByAuthor(object sender, RoutedEventArgs e)
        {
            string bookAuthor = bookToSearch.Text.ToString();
            string sqlSearchByAuthor =
                $"SELECT B.name 'Book', S.name 'Series' , B.series_number 'Series number', G.name 'Genre', A.name 'Author', B.pages 'Pages', " +
                $"B.publication_year 'Publication year', P.name 'Publisher', B.cost_price 'Cost price', B.price 'Price' " +
                $"FROM Books B " +
                $"JOIN Series S ON S.id = B.series_id " +
                $"JOIN Genres G ON G.id = B.genre_id " +
                $"JOIN Authors A ON A.id = B.author_id " +
                $"JOIN Publishers P ON P.id = B.publisher_id " +
                $"WHERE A.name LIKE '%{bookAuthor}%'";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSearchByAuthor, connection);
                SqlDataAdapter adapterFoundBooks = new SqlDataAdapter(command);
                DataTable dtFoundBooks = new DataTable("FoundBooks2");
                adapterFoundBooks.Fill(dtFoundBooks);
                dgFoundBooks.ItemsSource = dtFoundBooks.DefaultView;
            }
        }

        private void SearchByGenre(object sender, RoutedEventArgs e)
        {
            string bookGenre = bookToSearch.Text.ToString();
            string sqlSearchByAuthor =
                $"SELECT B.name 'Book', S.name 'Series' , B.series_number 'Series number', G.name 'Genre', A.name 'Author', B.pages 'Pages', " +
                $"B.publication_year 'Publication year', P.name 'Publisher', B.cost_price 'Cost price', B.price 'Price' " +
                $"FROM Books B " +
                $"JOIN Series S ON S.id = B.series_id " +
                $"JOIN Genres G ON G.id = B.genre_id " +
                $"JOIN Authors A ON A.id = B.author_id " +
                $"JOIN Publishers P ON P.id = B.publisher_id " +
                $"WHERE G.name LIKE '%{bookGenre}%'";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlSearchByAuthor, connection);
                SqlDataAdapter adapterFoundBooks = new SqlDataAdapter(command);
                DataTable dtFoundBooks = new DataTable("FoundBooks3");
                adapterFoundBooks.Fill(dtFoundBooks);
                dgFoundBooks.ItemsSource = dtFoundBooks.DefaultView;
            }
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
