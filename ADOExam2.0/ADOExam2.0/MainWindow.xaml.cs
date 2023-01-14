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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADOExam2._0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "user" && pbPassword.Password.ToString() == "123")
            {
                BookStore bookStore = new BookStore();
                bookStore.ShowDialog();
            }
            else
            {
                tbLogin.Text = "";
                pbPassword.Password = "";
                MessageBox.Show("Incorrect login or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
