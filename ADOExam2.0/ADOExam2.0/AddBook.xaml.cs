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
    public partial class AddBook : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public AddBook()
        {
            InitializeComponent();
            // РЕДАКТОР
            cbPublishers.Items.Clear();
            string sqlSetPublishers =
                $"SELECT name FROM Publishers";
            List<string> publishersList = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var setPublishers = new SqlCommand(sqlSetPublishers, connection);
                var readerPublishers = setPublishers.ExecuteReader();
                while (readerPublishers.Read())
                {
                    publishersList.Add(readerPublishers.GetString(0));
                }
            }
            foreach (string element in publishersList)
            {
                cbPublishers.Items.Add(new ComboBoxItem() { Content = element });
            }

            // ЖАНРЫ
            cbGenres.Items.Clear();
            string sqlSetGenres =
                $"SELECT name FROM Genres";
            List<string> genresList = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var setGenres = new SqlCommand(sqlSetGenres, connection);
                var readerGenres = setGenres.ExecuteReader();
                while (readerGenres.Read())
                {
                    genresList.Add(readerGenres.GetString(0));
                }
            }
            foreach (string element in genresList)
            {
                cbGenres.Items.Add(new ComboBoxItem() { Content = element });
            }

            // АВТОР
            cbAuthor.Items.Clear();
            string sqlSetAuthors =
                $"SELECT name FROM Authors";
            List<string> authorsList = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var setAuthor = new SqlCommand(sqlSetAuthors, connection);
                var readerAuthors = setAuthor.ExecuteReader();
                while (readerAuthors.Read())
                {
                    authorsList.Add(readerAuthors.GetString(0));
                }
            }
            foreach (string element in authorsList)
            {
                cbAuthor.Items.Add(new ComboBoxItem() { Content = element });
            }

            // СЕРИИ
            cbSeries.Items.Clear();
            string sqlSetSeries =
                $"SELECT name FROM Series";
            List<string> seriesList = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var setSeries = new SqlCommand(sqlSetSeries, connection);
                var readerSeries = setSeries.ExecuteReader();
                while (readerSeries.Read())
                {
                    seriesList.Add(readerSeries.GetString(0));
                }
            }
            foreach (string element in seriesList)
            {
                cbSeries.Items.Add(new ComboBoxItem() { Content = element });
            }
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                const int STEP = 1;
                // индекс редактора
                int publishersIndex = cbPublishers.SelectedIndex;
                publishersIndex++;
                // индекс жанра
                int genresIndex = cbGenres.SelectedIndex;
                genresIndex++;
                // индекс автора
                int authorsIndex = cbAuthor.SelectedIndex;
                authorsIndex++;
                // индекс серии
                int seriesIndex = cbSeries.SelectedIndex;
                seriesIndex++;
                // индекс популярности автора
                int authorsPopularityIndex = cbAuthorPopularity.SelectedIndex;


                int publisherId, genreId, authorId, seriesId;
                string authorsPopularity;
                // нахожу индекс айдишников в зависимости от наличия введенного значения
                if (bookPublisher.Text.ToString() != "")
                    publisherId = cbPublishers.Items.Count + STEP;
                else
                    publisherId = publishersIndex;

                if (bookGenre.Text.ToString() != "")
                    genreId = cbGenres.Items.Count + STEP;
                else
                    genreId = genresIndex;

                if (bookAuthor.Text.ToString() != "")
                    authorId = cbAuthor.Items.Count + STEP;
                else
                    authorId = authorsIndex;

                if (authorsPopularityIndex == 0)
                    authorsPopularity = "true";
                else
                    authorsPopularity = "false";

                if (bookSeries.Text.ToString() != "")
                    seriesId = cbSeries.Items.Count + STEP;
                else
                    seriesId = seriesIndex;

                // получаю true или false для Новинок и Бестселлеров
                string isNovelty = ((ComboBoxItem)cbIsNovelty.SelectedItem).Content.ToString();
                string isBestseller = ((ComboBoxItem)cbIsBestseller.SelectedItem).Content.ToString();

                string sqlAddBook =
                        "INSERT INTO Books VALUES " +
                        $"('{bookName.Text.ToString()}', {bookPages.Text}, '{bookPublicationYear.Text}', " +
                        $"{bookCostPrice.Text}, {bookPrice.Text}, {bookSeriesNumber.Text}, " +
                        $"'{isNovelty}', '{isBestseller}', {genreId}, {authorId}, {publisherId}, {seriesId})";

                string sqlAddPublisher =
                    $"INSERT INTO Publishers VALUES ('{bookPublisher.Text.ToString()}')";
                string sqlAddGenre =
                    $"INSERT INTO Genres VALUES ('{bookGenre.Text.ToString()}')";
                string sqlAddAuthor =
                    $"INSERT INTO Authors VALUES ('{bookAuthor.Text.ToString()}', '{authorsPopularity}')";
                string sqlAddSeries =
                    $"INSERT INTO Series VALUES ('{bookSeries.Text.ToString()}')";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // не добавляет запись если в TextBox не введено значение
                    if (bookPublisher.Text.ToString() != "")
                    {
                        var addPublisher = new SqlCommand(sqlAddPublisher, connection);
                        addPublisher.ExecuteNonQuery();
                    }
                    if (bookGenre.Text.ToString() != "")
                    {
                        var addGenre = new SqlCommand(sqlAddGenre, connection);
                        addGenre.ExecuteNonQuery();
                    }
                    if (bookAuthor.Text.ToString() != "")
                    {
                        var addAuthor = new SqlCommand(sqlAddAuthor, connection);
                        addAuthor.ExecuteNonQuery();
                    }
                    if (bookSeries.Text.ToString() != "")
                    {
                        var addSeries = new SqlCommand(sqlAddSeries, connection);
                        addSeries.ExecuteNonQuery();
                    }
                    var addBook = new SqlCommand(sqlAddBook, connection);
                    addBook.ExecuteNonQuery();
                    MessageBox.Show("The book was added", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Fill the table completely", "Exclamation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}