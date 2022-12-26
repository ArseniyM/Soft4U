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
        }
    }
}
