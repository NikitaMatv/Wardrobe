using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wardrobe.Component;
namespace Wardrobe
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static wardrobe_selectionEntities DB = new wardrobe_selectionEntities();
        public static User LoggedUser;
    }
}
