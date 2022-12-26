using Soft4U.Classes;
using Soft4U.DB;
using Soft4U.Pages;
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


namespace Soft4U.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                try
                {
                    if (TxbLogin.Text != "" && PassBox.Password != "")
                    {
                        if (context.Users.Where(e => e.Login == TxbLogin.Text && e.Password == PassBox.Password).FirstOrDefault() != null)
                        {
                            CurrentUser.currentUser = context.Users.Where(e => e.Login == TxbLogin.Text && e.Password == PassBox.Password).First();
                            App.MainFrame.Navigate(new MainPage());
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Невверный логин или пароль", "Данные введены не верно",MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите логин, пароль", "Данные не введены", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Авторизацияя не удалась", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnRegistrait_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            TxbLogin.Text = "";
            PassBox.Password = "";
            this.Visibility = Visibility.Collapsed;
            registration.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
