using Soft4U.DB;
using Soft4U.Classes;
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
using Soft4U.Windows;

namespace Soft4U.Pages
{//Передать
    /// <summary>
    /// Логика взаимодействия для MyLic.xaml
    /// </summary>
    public partial class MyLic : Page
    {
        public MyLic()
        {
            InitializeComponent();

            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                var userPrograms = context.UserPrograms.Where(e => e.Iduser == CurrentUser.currentUser.Id).ToList();
                List<UserProgramList> list = new List<UserProgramList>();
                foreach (var item in userPrograms)
                {
                    list.Add(new UserProgramList()
                    {
                        Name = context.Programs.Where(e => e.Id == item.Idprograms).Select(e => e.Name).First(),
                        Discription = context.Programs.Where(e => e.Id == item.Idprograms).Select(e => e.Discription).First(),
                        DateLicens = item.DateLicens,
                        DateLicEnd = item.DateLicEnd
                    });
                }
                MyLicList.ItemsSource = list;
            }
        }

        private void BtnClickTakeApplication(object sender, RoutedEventArgs e)
        {
            AppCreate appCreate = new AppCreate(((Button)sender).DataContext, 1);
            this.Visibility = Visibility.Collapsed;
            appCreate.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
