using Shop;
using Shop.Data;
using ShopLab4.ViewModel;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLab4
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            ShopData.Storehouse();

            IData shopData = new ShopData();
            
            MainWindow mainWindow = new MainWindow();
            WindowViewModel windowViewModel = new WindowViewModel();
            mainWindow.DataContext = windowViewModel;
            
            app.Run(); //mainWindow
        }


    }
}
