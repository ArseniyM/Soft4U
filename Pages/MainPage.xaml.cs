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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = CurrentUser.currentUser;
            using (Soft4UDbContext context = new Soft4UDbContext())
            {
                if (CurrentUser.currentUser.Role == 2)
                {
                    foreach (var item in context.UserPrograms.Where(e => e.Iduser == CurrentUser.currentUser.Id).ToList())
                    {
                        dataGridPO.Items.Add(new
                        {
                            Name = context.Programs.Where(e => e.Id == item.Idprograms).Select(e => e.Name).First(),
                            Date = item.DateLicEnd
                        });
                    }
                    foreach (var item in context.ApplicationsUsers.Where(e => e.Iduser == CurrentUser.currentUser.Id).ToList())
                    {
                        dataGridUserApp.Items.Add(new
                        {
                            Type = context.Types.Where(e => e.Id == item.Idtype).Select(e => e.Name).First(),
                            Name = context.Programs.Where(e => e.Id == item.Idprogramm).Select(e => e.Name).First(),
                            StatusApp = context.Statuses.Where(e => e.Id == item.Idstatus).Select(e => e.StatusName).First()
                        });
                    }
                }
                else if (CurrentUser.currentUser.Role == 1)
                {
                    foreach (var item in context.Users.ToList())
                    {
                        dataGridClients.Items.Add(new
                        {
                            SurName = item.Surname,
                            Name = item.Name,
                            MidlName = item.Middlename,
                            LicCount = context.ApplicationsUsers.Where(e => e.Iduser == item.Id).Count()
                        });
                    }
                    foreach (var item in context.ApplicationsUsers.ToList())
                    {
                        dataGridClientApp.Items.Add(new
                        {
                            Type = context.Types.Where(e => e.Id == item.Idtype).Select(e => e.Name).First(),
                            Name = context.Programs.Where(e => e.Id == item.Idprogramm).Select(e => e.Name).First(),
                            FIO = context.Users.Where(e => e.Id == item.Iduser).Select(e => e.Surname + " " + e.Name + " " + e.Middlename).First()
                        });
                    }
                }
            }
        }
    }
}