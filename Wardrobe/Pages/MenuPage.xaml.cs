﻿using System;
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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        User contextuser;
        public MenuPage(User user)
        {
            InitializeComponent();
            contextuser = user;
            DataContext = contextuser;
            if(Properties.Settings.Default.Password != null && Properties.Settings.Default.Login != null)
            {
                SaveCb.IsChecked = true;
                contextuser.Password = Properties.Settings.Default.Password;
                contextuser.Login = Properties.Settings.Default.Login;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new RegPage(new User()));
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
                string eror = "";
                if (contextuser.Login != null)
                {
                    eror += $"Заполните поле логин\n";
                }
                if (contextuser.Password != null)
                {
                    eror += $"Заполните поле пароль\n";
                }
                if (eror != "")
                {
                    var user = App.DB.User.FirstOrDefault(x => x.Login == contextuser.Login
                    && x.Password == contextuser.Password);
                    if (user == null)
                    {
                        MessageBox.Show("Неверные данные\n");
                        return;
                    }
                    if (SaveCb.IsChecked == true)
                    {
                        Properties.Settings.Default.Login = contextuser.Login.ToString();
                        Properties.Settings.Default.Password = contextuser.Password.ToString();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Login = null;
                        Properties.Settings.Default.Password = null;
                        Properties.Settings.Default.Save();
                    }
                    App.LoggedUser = user;
                    NavigationService.Navigate(new MainMenuPage());
                }
                else
                {
                    MessageBox.Show($"{eror}");
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new RestorePage(new User()));
            }
            catch
            {
                return;
            }
        }
    }
}
