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
    /// Логика взаимодействия для RestorePage.xaml
    /// </summary>
    public partial class RestorePage : Page
    {
        User contextuser;
        public RestorePage(User user)
        {
            InitializeComponent();
            contextuser = user;
            DataContext = contextuser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var error = "";
                if (contextuser.Сode_Word == null)
                {
                    error = "Заполните кодовое слова\n";
                }
                if (contextuser.Login == null)
                {
                    error = "Заполните логин\n";
                }
                if (contextuser.Password == null)
                {
                    error = "Заполните новый пароль\n";
                }
                if (error != "")
                {
                    MessageBox.Show($"{error}");
                    return;
                }
                var user = App.DB.User.FirstOrDefault(x => x.Сode_Word == contextuser.Сode_Word && x.Login == contextuser.Login);
                if (user != null)
                {
                    user.Password = contextuser.Password;
                    App.DB.SaveChanges();
                    NavigationService.Navigate(new MenuPage(new User()));
                }
                else
                {
                    MessageBox.Show("Ошибка. Неверный код или логина\n");
                    return;
                }
            }

            catch
            {
                return;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new MenuPage(new User()));
            }
            catch
            {
                return;
            }
           
        }
    }
}
