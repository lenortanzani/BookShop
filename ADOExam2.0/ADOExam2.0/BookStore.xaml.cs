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

namespace ADOExam2._0
{
    public partial class BookStore : Window
    {
        public BookStore()
        {
            InitializeComponent();
        }

        private void ShowBooks(object sender, RoutedEventArgs e)
        {
            ShowBooks showBooks = new ShowBooks();
            showBooks.ShowDialog();
        }

        private void ShowNovelties(object sender, RoutedEventArgs e)
        {
            ShowNovelties showNovelties = new ShowNovelties();
            showNovelties.ShowDialog();
        }

        private void ShowBestsellers(object sender, RoutedEventArgs e)
        {
            ShowBestsellers showBestsellers = new ShowBestsellers();
            showBestsellers.ShowDialog();
        }

        private void ShowPopularAuthors(object sender, RoutedEventArgs e)
        {
            ShowPopularAuthors showPopularAuthors = new ShowPopularAuthors();
            showPopularAuthors.ShowDialog();
        }

        private void AddBooks(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.ShowDialog();
        }

        private void DeleteBooks(object sender, RoutedEventArgs e)
        {
            DeleteBook deleteBook = new DeleteBook();
            deleteBook.ShowDialog();
        }

        private void EditBooks(object sender, RoutedEventArgs e)
        {
            EditBook editBook = new EditBook();
            editBook.ShowDialog();
        }

        private void SellBooks(object sender, RoutedEventArgs e)
        {
            SellBook sellBook = new SellBook();
            sellBook.ShowDialog();
        }
        private void Search(object sender, RoutedEventArgs e)
        {
            SearchBook searchBook = new SearchBook();
            searchBook.ShowDialog();
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
