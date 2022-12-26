using Soft4U.DB;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tFam.Text != "" && tName.Text != "" && tLogin.Text != "" && tPas.Password != "")
                {
                    using (Soft4UDbContext context = new Soft4UDbContext())
                    {
                        if (context.Users.Where(e => e.Login == tLogin.Text).FirstOrDefault() == null)
                        {

                            User newUser = new User
                            {
                                Surname = tFam.Text,
                                Name = tName.Text,
                                Login = tLogin.Text,
                                Password = tPas.Password,
                                Role = 1
                            };
                            if (tOtch.Text != "")
                                newUser.Middlename = tOtch.Text;
                            context.Users.Add(newUser);
                            context.SaveChanges();
                            MessageBox.Show("Регистрация прошла успешно", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Пользователь с логином {tLogin.Text} уже зарегистрирован.","Повторение логина", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }
                else
                {
                    string str = "Новый пользователь не создан, так как не заполнены поля: ";
                    str += (tFam.Text == "") ? "  Фамилия," : "";
                    str += (tName.Text == "") ? "  Имя," : "";
                    str += (tLogin.Text == "") ? "  Логин," : "";
                    str += (tPas.Password == "") ? "  Пароль," : "";
                    str = str.TrimEnd(',');
                    MessageBox.Show(str, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка. Пользователь не создан.\n{ex.Message}", "Ошибка");
            }
        }
    }
}
