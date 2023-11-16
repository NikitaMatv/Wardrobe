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
      
        }

        private void CbWeather_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbWeather.ItemsSource = App.DB.Clothes.Where(x => x.User.Name == CbWeather.Text).ToList();
        }
    }
}
