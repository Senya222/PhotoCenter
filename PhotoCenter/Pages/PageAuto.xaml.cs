using PhotoCenter.ViewModels;
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
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page, IGettingPassword
    {
        MainWindow mainWindow;
        public PageAuto(MainWindow main)
        {
            mainWindow = main;
            InitializeComponent();
            (DataContext as AuthorizationViewModel).GettingPassword = this;
        }
        public string GetPassword() => _passwordBox.Password;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as AuthorizationViewModel).LogIn())
            {
                mainWindow.Container.Navigate(new PageAdmin());
            }
            else MessageBox.Show("Неверный логин и/или пароль!");
        }
    }
}
