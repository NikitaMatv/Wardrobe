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
using WardrobeAdmin.Components;
using WardrobeAdmin.Pages;

namespace WardrobeAdmin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListClothesPage.xaml
    /// </summary>
    public partial class ListClothesPage : Page
    {
        public ListClothesPage()
        {
            InitializeComponent();

            CbWeather.ItemsSource = App.DB.User.ToList();
            CbWeather.SelectedIndex = 0;
            LvWard.ItemsSource = App.DB.Clothes.Where(x => x.User.Name == CbWeather.Text).ToList();
            if (LvWard.Items.Count != 0)
            {
                SpCount0.Visibility = Visibility.Collapsed;
            }
            else
            {
                SpCount0.Visibility = Visibility.Visible;
            }
        }

       
        private void BtLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectitem = (sender as MenuItem).DataContext as Clothes;
            NavigationService.Navigate(new EdittClothesPage(selectitem));
        }

        private void BtLeave_Click_1(object sender, RoutedEventArgs e)
        {
            LvWard.ItemsSource = App.DB.Clothes.Where(x => x.User.Name == CbWeather.Text).ToList();
            if(LvWard.Items.Count != 0)
            {
                SpCount0.Visibility = Visibility.Collapsed;
            }
            else
            {
                SpCount0.Visibility = Visibility.Visible;
            }
        }
    }
}
