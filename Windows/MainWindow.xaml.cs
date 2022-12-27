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
using System.Windows.Shapes;
using Soft4U.Pages;
using Soft4U.Classes;

namespace Soft4U.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameN.Navigate(new MainPage());
            App.MainFrame = FrameN;
            this.DataContext = CurrentUser.currentUser;

            Binding binding = new Binding
            {
                Source = CurrentUser.currentUser,
                Path = new PropertyPath("Name"),
                Mode = BindingMode.TwoWay
            };
            tLogin.SetBinding(TextBlock.TextProperty, binding);
        }

        private void BtnMain(object sender, RoutedEventArgs e)
        {
            FrameN.Navigate(new MainPage());
        }

        private void BtnMy(object sender, RoutedEventArgs e)
        {
            FrameN.Navigate(new MyLic());
        }

        private void BtnLic(object sender, RoutedEventArgs e)
        {
            FrameN.Navigate(new LicPO());
        }

        private void BtnApp(object sender, RoutedEventArgs e)
        {
            FrameN.Navigate(new ApplicationPage());
        }

        private void BtnClients(object sender, RoutedEventArgs e)
        {
            FrameN.Navigate(new ClientsPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.currentUser = new DB.User();
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
