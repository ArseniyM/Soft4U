using Soft4U.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Soft4U.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplicationPage.xaml
    /// </summary>
    public partial class ApplicationPage : Page
    {
        public ApplicationPage()
        {
            InitializeComponent();
            this.DataContext = CurrentUser.currentUser;
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                if (CurrentUser.currentUser.Role == 1)
                    MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Idstatus == 1).ToList();
                else
                    MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Iduser == CurrentUser.currentUser.Id).OrderByDescending(e => e.Idstatus).ToList();
            }
        }

        private void Btngive_Click(object sender, RoutedEventArgs e)
        {
            ApplicationsUser app;
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                app = context.ApplicationsUsers.Where(e => e.Id == ((ApplicationsUser)((Button)sender).DataContext).Id).First();
                if (app != null)
                {
                    if (MessageBox.Show("Вы уверены, что хотите утвердить заявку?", "Подтверждение", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        UserProgram prog = new UserProgram();
                        prog.Idprograms = app.Idprogramm;
                        prog.Iduser = app.Iduser;
                        prog.DateLicens = (DateTime.Now).ToShortDateString();
                        prog.DateLicEnd = DateOnly.Parse(prog.DateLicens).AddMonths((int)context.Programs.Where(e => e.Id == prog.Idprograms).First().License).ToString();
                        context.UserPrograms.Add(prog);
                        app.Idstatus = 3;
                        context.SaveChanges();
                        MyLicList.ItemsSource = null;
                        if (CurrentUser.currentUser.Id == 1)
                            MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Idstatus == 1).ToList();
                        else
                            MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Iduser == CurrentUser.currentUser.Id).OrderByDescending(e => e.Idstatus).ToList();
                    };
                }
            }
        }

        private void Btnnext_Click(object sender, RoutedEventArgs e)
        {
            ApplicationsUser app;
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                app = context.ApplicationsUsers.Where(e => e.Id == ((ApplicationsUser)((Button)sender).DataContext).Id).First();
                if (app != null)
                {
                    if (MessageBox.Show("Вы уверены, что хотите утвердить заявку?", "Подтверждение", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        UserProgram prog = context.UserPrograms.Where(e => e.Idprograms == app.Idprogramm && e.Iduser == app.Iduser).First();
                        prog.DateLicEnd = DateOnly.Parse(prog.DateLicEnd).AddMonths((int)context.Programs.Where(e => e.Id == prog.Idprograms).First().License).ToString();
                        app.Idstatus = 3;
                        context.SaveChanges();
                        MyLicList.ItemsSource = null;
                        if (CurrentUser.currentUser.Role == 1)
                            MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Idstatus == 1).ToList();
                        else
                            MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Iduser == CurrentUser.currentUser.Id).OrderByDescending(e => e.Idstatus).ToList();
                    };
                }
            }
        }

        private void Btnclose_Click(object sender, RoutedEventArgs e)
        {
            ApplicationsUser app;
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                app = context.ApplicationsUsers.Where(e => e.Id == ((ApplicationsUser)((Button)sender).DataContext).Id).First();
                if (app != null)
                {
                    if (MessageBox.Show("Вы уверены, что хотите отклонить заявку?", "Подтверждение", MessageBoxButton.OKCancel) == MessageBoxResult.OK) 
                    {
                        app.Idstatus = 2;
                        context.SaveChanges();
                        MyLicList.ItemsSource = null;
                        if (CurrentUser.currentUser.Role == 1)
                            MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Idstatus == 1).ToList();
                        else
                            MyLicList.ItemsSource = context.ApplicationsUsers.Where(e => e.Iduser == CurrentUser.currentUser.Id).OrderByDescending(e => e.Idstatus).ToList();
                    };
                }
            }
        }
    }
}
