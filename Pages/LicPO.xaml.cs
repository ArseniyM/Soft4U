using Soft4U.Classes;
using Soft4U.DB;
using Soft4U.Windows;
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

namespace Soft4U.Pages
{
    /// <summary>
    /// Логика взаимодействия для LicPO.xaml
    /// </summary>
    public partial class LicPO : Page
    {
        public LicPO()
        {
            InitializeComponent();
            LicPOPage.DataContext = CurrentUser.currentUser;
            using (Soft4UDbContext context = new Soft4UDbContext()) {
                LicPOAdminList.ItemsSource = context.Programs.ToList();
                LicPOUserList.ItemsSource = context.Programs.ToList();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            EditPO editPO = new EditPO((Program)LicPOAdminList.SelectedValue);
            this.Visibility = Visibility.Collapsed;
            editPO.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                if (context.UserPrograms.Where(e => e.Idprograms == ((Program)LicPOAdminList.SelectedValue).Id).Count() == 0)
                {
                    MessageBoxResult res = MessageBox.Show($"Вы уверены, что хотите удалить {((Program)LicPOAdminList.SelectedValue).Name}", "Удаление", MessageBoxButton.OKCancel);
                    if (res == MessageBoxResult.OK)
                    {
                        context.Programs.Remove((Program)LicPOAdminList.SelectedValue);
                        context.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show($"На данный момент ряд пользователей обладают лицензией на {((Program)LicPOAdminList.SelectedValue).Name}.\n"+
                        "Нельзя удалить ПО, если у пользователей есть действующие линцензии на него", "Невозможно аудалить");
                }
            }
        }

        private void AddPOBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPO addPO = new AddPO();
            this.Visibility = Visibility.Collapsed;
            addPO.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
