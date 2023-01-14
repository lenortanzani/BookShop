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
    public partial class EditBook : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public EditBook()
        {
            InitializeComponent();
            // КНИГА
            cbEdition.Items.Clear();
            string sqlSetBooks =
                $"SELECT name FROM Books";
            List<string> booksList = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var setBooks = new SqlCommand(sqlSetBooks, connection);
                var readerBooks = setBooks.ExecuteReader();
                while (readerBooks.Read())
                {
                    booksList.Add(readerBooks.GetString(0));
                }
            }
            foreach (string element in booksList)
            {
                cbEdition.Items.Add(new ComboBoxItem() { Content = element });
            }

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
                string editingBook = ((ComboBoxItem)cbEdition.SelectedItem).Content.ToString();
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

                if (bookPublisher.Text.ToString() != "")
                    publisherId = cbPublishers.Items.Count + 1;
                else
                    publisherId = publishersIndex;

                if (bookGenre.Text.ToString() != "")
                    genreId = cbGenres.Items.Count + 1;
                else
                    genreId = genresIndex;

                if (bookAuthor.Text.ToString() != "")
                    authorId = cbAuthor.Items.Count + 1;
                else
                    authorId = authorsIndex;

                if (authorsPopularityIndex == 0)
                    authorsPopularity = "true";
                else
                    authorsPopularity = "false";

                if (bookSeries.Text.ToString() != "")
                    seriesId = cbSeries.Items.Count + 1;
                else
                    seriesId = seriesIndex;

                string isNovelty = ((ComboBoxItem)cbIsNovelty.SelectedItem).Content.ToString();
                string isBestseller = ((ComboBoxItem)cbIsBestseller.SelectedItem).Content.ToString();

                string sqlEditBook =
                    $"UPDATE Books SET name = '{bookName.Text.ToString()}', pages = {bookPages.Text}, publication_year = '{bookPublicationYear.Text}', " +
                    $"cost_price = {bookCostPrice.Text}, price = {bookPrice.Text}, series_number = {bookSeriesNumber.Text}, isNovelty = '{isNovelty}', " +
                    $"isBestseller = '{isBestseller}', genre_id = {genreId}, author_id = {authorId}, publisher_id = {publisherId}, series_id = {seriesId} " +
                    $"WHERE name LIKE '{editingBook}'";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var editBook = new SqlCommand(sqlEditBook, connection);
                    editBook.ExecuteNonQuery();
                }

                MessageBox.Show("The book was edited", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch
            {
                MessageBox.Show("Fill the table completely", "Exclamation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}