using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddNewWardPage.xaml
    /// </summary>
    public partial class AddNewWardPage : Page
    {
        Clothes contextclothes;
        public AddNewWardPage(Clothes clothes)
        {
            InitializeComponent();
            contextclothes = clothes;
            DataContext = contextclothes;
            CbCollor.ItemsSource = App.DB.Collor.ToList();
            CbType.ItemsSource = App.DB.Type.ToList();
           
        }

        private void BAddType_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTypeClothesPage(new Component.Type()));
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog().GetValueOrDefault())
                {
                    contextclothes.Photo = File.ReadAllBytes(dialog.FileName);
                    DataContext = null;
                    DataContext = contextclothes;
                }
            }
            catch
            {
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var error = "";        
                if (contextclothes.Photo == null)
                {
                    error += "Добавте фото одежды \n";
                }
                if (contextclothes.Type == null)
                {
                    error += "Выберете тип одежды \n";
                }
                if (contextclothes.Collor == null)
                {
                    error += "Выберете цвет одежды \n";
                }
                if (contextclothes.Size == null)
                {
                    error += "Заполните  размер одежды \n";
                }
                if (error != "")
                {
                    MessageBox.Show(error);
                    return;
                }
                if(contextclothes.id == 0)
                App.DB.Clothes.Add(contextclothes);
                
                App.DB.SaveChanges();
                NavigationService.Navigate(new MainMenuPage());
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

        private void CbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var Type = App.DB.Type.FirstOrDefault(x => x.id == CbType.SelectedIndex +2 );
                if (Type != null)
                    TbWeather.Text = (App.DB.Weather.FirstOrDefault(x => x.Id == Type.WeatherId) as Weather).Titile.ToString();
            }
            catch
            {
                return;
            }
        }
    }
}
