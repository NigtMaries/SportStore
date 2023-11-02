using SportStore.Models;
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
using SportStore.Infrastructure;

namespace SportStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            using (SportStoreContext db = new SportStoreContext())
            {
                User user = db.Users.FirstOrDefault();
                MessageBox.Show("База данных подключена");
                statusUser.Text = user.RoleNavigation.Name;

            }
        }

        public MainWindow(User user)
        {
            InitializeComponent();

            List<string> sortList = new List<string>() { "По возрастанию цены", "По убыванию цены" };

            using (SportStoreContext db = new SportStoreContext())
            {
                
                if (user != null)
                {
                    statusUser.Text = user.RoleNavigation.Name;
                    MessageBox.Show($"{user.RoleNavigation.Name}: {user.Surname} {user.Name} {user.Patronymic}. \r\t");
                }
                else
                {
                    statusUser.Text = "Гость";
                    MessageBox.Show("Гость");
                }

                productlistView.ItemsSource = db.Products.ToList();
                sortUserComboBox.ItemsSource = sortList;
                sortUserComboBox.SelectedIndex = 0;
            }
            
        }


        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            new LocalWindow().Show();
            this.Close();
        }

        private void sortUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (SportStoreContext db = new SportStoreContext())
            {
                if (sortUserComboBox.SelectedValue == "По убыванию цены")
                {
                    productlistView.ItemsSource = db.Products.OrderByDescending(u => u.Cost).ToList();
                }

                if (sortUserComboBox.SelectedValue == "По возрастанию цены")
                {
                    productlistView.ItemsSource = db.Products.OrderBy(u => u.Cost).ToList();
                }
            }
        }
    }
}