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
    /// Логика взаимодействия для MenuPages.xaml
    /// </summary>
    public partial class MenuPages : Page
    {
        public MenuPages()
        {
            InitializeComponent();
        }
        

        private void BtLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage(new User()));
        }

        private void ListWard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WardListPage());
        }
    }
}
