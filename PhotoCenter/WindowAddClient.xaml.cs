using PhotoCenter.Pages;
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

namespace PhotoCenter
{
    /// <summary>
    /// Логика взаимодействия для WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        PageClient pageClient;
        private Client _client = new Client(); 
        public WindowAddClient(PageClient client, Client SelectedClient)
        {
            InitializeComponent();
            if (SelectedClient != null)
                _client = SelectedClient;


            pageClient = client;
            DataContext = _client;
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_client.LastName))
                errors.AppendLine("Укажите фамилию клиента!");
            if (string.IsNullOrWhiteSpace(_client.FirstName))
                errors.AppendLine("Укажите имя клиента!");
            if (string.IsNullOrWhiteSpace(_client.MiddleName))
                errors.AppendLine("Укажите отчество клиента!");
            if (string.IsNullOrWhiteSpace(_client.Phone))
                errors.AppendLine("Укажите телефон клиента!");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_client.ClientID == 0)
                DBContext.GetContext().Client.Add(_client);
            try
            {
                DBContext.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены!");
                DBContext.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                pageClient.dgClient.ItemsSource = DBContext.GetContext().Client.ToList();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btOtm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
