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
    public partial class ShowNovelties : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public ShowNovelties()
        {
            InitializeComponent();
            ShowNoveltiesBtn(null, null);
        }
        private void ShowNoveltiesBtn(object sender, RoutedEventArgs e)
        {
            string sqlShowNovelties =
                "SELECT B.name 'Book', S.name 'Series' , G.name 'Genre', A.name 'Author', B.pages 'Pages', " +
                "B.publication_year 'Publication year', P.name 'Publisher', B.cost_price 'Cost price', B.price 'Price' " +
                "FROM Books B " +
                "JOIN Series S ON S.id = B.series_id " +
                "JOIN Genres G ON G.id = B.genre_id " +
                "JOIN Authors A ON A.id = B.author_id " +
                "JOIN Publishers P ON P.id = B.publisher_id " +
                "WHERE B.isNovelty = 'true'";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlShowNovelties, connection);
                SqlDataAdapter adapterNovelties = new SqlDataAdapter(command);
                DataTable dtNovelties = new DataTable("Novelties");
                adapterNovelties.Fill(dtNovelties);
                dgShownNovelties.ItemsSource = dtNovelties.DefaultView;
            }
        }
        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
