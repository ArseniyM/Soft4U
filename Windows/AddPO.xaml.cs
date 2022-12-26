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
    /// Логика взаимодействия для AddPO.xaml
    /// </summary>
    public partial class AddPO : Window
    {
        public AddPO()
        {
            InitializeComponent();
        }
        private void AddPOBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbName.Text != "" && TxbCost.Text != "" && TxbTime.Text != "" && TxbDiscription.Text != "")
                {
                    using (Soft4UDbContext context = new Soft4UDbContext())
                    {
                        if (context.Programs.Where(e => e.Name == TxbName.Text).FirstOrDefault() == null)
                        {

                            Program newProgram = new Program
                            {
                                Name = TxbName.Text,
                                Cost = Convert.ToInt32(TxbCost.Text),
                                Discription = TxbDiscription.Text,
                                License = Convert.ToInt32(TxbTime.Text)
                            };
                            context.Programs.Add(newProgram);
                            context.SaveChanges();
                            MessageBox.Show("По успешно добавлено", "Добавлено", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                        {   //Возможна дороботка
                            MessageBox.Show($"ПО с именем {TxbName.Text} уже присутствует.", "Повторение ПО", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }
                else
                {
                    string str = "Новое ПО не добавлено, так как не заполнены поля: ";
                    str += (TxbName.Text == "") ? "  Название," : "";
                    str += (TxbCost.Text == "") ? "  Стоимость," : "";
                    str += (TxbTime.Text == "") ? "  Длительность лицензии," : "";
                    str += (TxbDiscription.Text == "") ? "  Описание," : "";
                    str = str.TrimEnd(',');
                    MessageBox.Show(str, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка. ПО не добавлено.\n{ex.Message}", "Ошибка");
            }
        }
    }
}