using ShopLab4.ViewModel;
using System.Windows;

namespace ShopLab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new WindowViewModel();
            MainFrame.Content = new MainPage();
        }
    }
}
