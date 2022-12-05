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

namespace PhotoCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        public PageClient()
        {
            InitializeComponent();
            dgClient.ItemsSource = DBContext.GetContext().Client.ToList();
        }

        private void btRed_Click(object sender, RoutedEventArgs e)
        {
            WindowAddClient windowAddClient = new WindowAddClient(this, (sender as Button).DataContext as Client);
            windowAddClient.Show();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddClient windowAddClient = new WindowAddClient(this, null);
            windowAddClient.Show();
        }

        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            var clientDel = dgClient.SelectedItems.Cast<Client>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientDel.Count()} элементы?", "Внимание",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    DBContext.GetContext().Client.RemoveRange(clientDel);
                    DBContext.GetContext().SaveChanges();
                    dgClient.ItemsSource = DBContext.GetContext().Client.ToList();
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
