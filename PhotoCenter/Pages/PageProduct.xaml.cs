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
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        public PageProduct()
        {
            InitializeComponent();
        }

        private void texName_TextChanged(object sender, TextChangedEventArgs e)
        {
            (DataContext as ProductViewModel).GetProduct();
        }

        private void ComboSortirovka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as ProductViewModel).GetProduct();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            (DataContext as ProductViewModel).GetProduct();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            (DataContext as ProductViewModel).GetProduct();
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            (DataContext as ProductViewModel).GetProduct();
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            (DataContext as ProductViewModel).GetProduct();
        }
    }
}
