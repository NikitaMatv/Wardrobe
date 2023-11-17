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
    /// Логика взаимодействия для SelectClothesListPage.xaml
    /// </summary>
    public partial class SelectClothesListPage : Page
    {
        public SelectClothesListPage() 
        {
            InitializeComponent();
           
            CbWeather.ItemsSource = App.DB.Weather.ToList();
            SpStart.Visibility = Visibility.Visible;
        }

  


        private void BtLeave_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new MainMenuPage());
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            IEnumerable<Clothes> filterService = App.DB.Clothes.Where(x => x.UserId == App.LoggedUser.id).ToList();
            if (CbWeather.Text != "")
            {
                filterService = filterService.Where(x => x.Type.Weather.Titile == CbWeather.Text).ToList();
            }
            int number;

            bool success = int.TryParse(TbTemperatura.Text, out number);
            if (TbTemperatura.Text != "" && success == true)
            {
                filterService = filterService.Where(x => x.Type.TemperatureMin < number && x.Type.TemperatureMax > number).ToList();
            }
            LvWard.ItemsSource = filterService.ToList();
            SpStart.Visibility = Visibility.Collapsed;
            if (filterService.Count() == 0)
            {
                SpCount0.Visibility = Visibility.Visible;
            }
            else
            {
                SpCount0.Visibility = Visibility.Collapsed;
            }
        }
    }
}
