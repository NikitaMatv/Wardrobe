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
    /// Логика взаимодействия для AddTypeClothesPage.xaml
    /// </summary>
    public partial class AddTypeClothesPage : Page
    {
        Wardrobe.Component.Type contexttype;
        public AddTypeClothesPage(Wardrobe.Component.Type type)
        {
            InitializeComponent();
            contexttype = type;
            DataContext = contexttype;
            CbWeather.ItemsSource = App.DB.Weather.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                var error = "";
                if (CbWeather.SelectedItem != null)
                {
                    contexttype.WeatherId = CbWeather.SelectedIndex + 1;
                }
                if (contexttype.Title == null)
                {
                    error += "Заполните название\n";
                }
                if (contexttype.Description == null)
                {
                    error += "Заполните описание\n";
                }
                if (contexttype.WeatherId == null)
                {
                    error += "Выберете погоду\n";
                }
                if (contexttype.TemperatureMax == null)
                {
                    error += "Заполниет максимальную температуру\n";

                }
                if (contexttype.TemperatureMin == null)
                {
                    error += "Заполните минимальную температуру\n";
                }
                if (error != "")
                {
                    MessageBox.Show(error);
                    return;
                }
                App.DB.Type.Add(contexttype);
                App.DB.SaveChanges();
                NavigationService.Navigate(new AddNewWardPage(new Clothes()));
            }
            catch
            {
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }
    }
}
