using System;
using Soft4U.DB;
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
using System.Xml.Linq;
using Soft4U.Classes;
using System.DirectoryServices.ActiveDirectory;

namespace Soft4U.Windows
{
    /// <summary>
    /// Логика взаимодействия для AppCreate.xaml
    /// </summary>
    public partial class AppCreate : Window
    {
        public AppCreate()
        {
            InitializeComponent();
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                ComBoxTitel.ItemsSource = context.Types.OrderBy(e => e.Id).Select(e => e.Name).ToList();
                ComBoxNameLic.ItemsSource = context.Programs.Select(e => e.Name).ToList();

            }
        }

        private void BtnClickSand(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Soft4UDbContext context = new Soft4UDbContext())
                {
                    if (context.ApplicationsUsers.Where(e => e.Idtype == ComBoxTitel.SelectedIndex + 1 &&
                    e.Idprogramm == context.Programs.Where(e => e.Name == ComBoxNameLic.Text).First().Id &&
                    e.Iduser == CurrentUser.currentUser.Id
                    ).FirstOrDefault() == null)
                    {
                        ApplicationsUser application = new ApplicationsUser();
                        application.Idtype = ComBoxTitel.SelectedIndex + 1;
                        application.Idprogramm = context.Programs.Where(e => e.Name == ComBoxNameLic.Text).First().Id;
                        application.Iduser = CurrentUser.currentUser.Id;
                        if (TxbComent.Text != null)
                        {
                            application.Comment = TxbComent.Text;
                        }
                        context.ApplicationsUsers.Add(application);
                        context.SaveChanges();
                        MessageBox.Show("Заявка создана.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Такая заявка уже есть и мы скоро её рассмотрим.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка. Заявка не была создана.\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}