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
    public partial class DeleteBook : Window
    {
        static string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Bookshop;Integrated Security=True";
        public DeleteBook()
        {
            InitializeComponent();

            cbDelete.Items.Clear();
            string sqlSetBooks =
                $"SELECT name FROM Books";
            List<string> bookList = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var setBooks = new SqlCommand(sqlSetBooks, connection);
                var readerBooks = setBooks.ExecuteReader();
                while (readerBooks.Read())
                {
                    bookList.Add(readerBooks.GetString(0));
                }
            }
            foreach (string element in bookList)
            {
                cbDelete.Items.Add(new ComboBoxItem() { Content = element });
            }
        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                string deletingBook = ((ComboBoxItem)cbDelete.SelectedItem).Content.ToString();

                string sqlSellBook = $"DELETE FROM Books WHERE name LIKE '{deletingBook}'";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var deleteBook = new SqlCommand(sqlSellBook, connection);
                    deleteBook.ExecuteNonQuery();
                }
                //MessageBox.Show(deletingBook);

                MessageBox.Show("The book was deleted", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch
            {
                MessageBox.Show("Select the book to delete", "Exclamation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
