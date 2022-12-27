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
                dataGridClients.ItemsSource = context.UserPrograms.Where(e => e.Iduser == CurrentUser.currentUser.Id).ToList();
            }
        }
    }
}