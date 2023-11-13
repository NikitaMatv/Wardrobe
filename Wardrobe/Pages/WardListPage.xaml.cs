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
using Wardrobe.Component;

namespace Wardrobe.Pages
{
    /// <summary>
    /// Логика взаимодействия для WardListPage.xaml
    /// </summary>
    public partial class WardListPage : Page
    {
        public WardListPage()
        {
            InitializeComponent();
            LvWard.ItemsSource = App.DB.Clothes.ToList();
            
        }

        private void BtLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectitem = (sender as MenuItem).DataContext as Clothes;
            NavigationService.Navigate(new AddNewWardPage(selectitem));
        }

    }
}
