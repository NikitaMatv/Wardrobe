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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        User contextuser;
        public RegPage(User user)
        {
            InitializeComponent();
            contextuser = user;
            DataContext = contextuser;
            CbGender.ItemsSource = App.DB.Gender.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                var error = "";
                if (contextuser.Password == null)
                {
                    error += " Заполните пароль\n";
                }
                if (contextuser.Login == null)
                {
                    error += " Заполните логин\n";
                }
                if (contextuser.Age == 0)
                {
                    error += " Заполните возраст\n";
                }
                if (contextuser.Name == null)
                {
                    error += " Заполните имя\n";
                }
                if (contextuser.Surname == null)
                {
                    error += " Заполните фамилия\n";
                }
                if (CbGender.SelectedIndex == -1)
                {
                    error += " Заполните пол\n";
                }
                if (contextuser.Сode_Word == null)
                {
                    error += " Заполните кодовое слово\n";
                }
                if (error != String.Empty)
                {
                    MessageBox.Show($"{error}");
                    return;
                }
                contextuser.GenderId = CbGender.SelectedIndex + 1;
                contextuser.DateReg = DateTime.Now;
                contextuser.RoleId = 1;
                App.DB.User.Add(contextuser);
                App.DB.SaveChanges();
                NavigationService.Navigate(new MenuPage(new User()));
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
