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
    /// Логика взаимодействия для EditPO.xaml
    /// </summary>
    public partial class EditPO : Window
    {
        Program editProgram = new Program();
        public EditPO()
        {
            InitializeComponent();
        }

        public EditPO(Program program)
        {
            InitializeComponent();
            editProgram = program;
            TxbNameEdit.Text = program.Name;
            TxbDiscriptionEdit.Text = program.Discription;
            TxbCostEdit.Text = program.Cost.ToString();
            TxbTimeEdit.Text = program.License.ToString();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbNameEdit.Text != "" && TxbCostEdit.Text != "" && TxbDiscriptionEdit.Text != "" && TxbTimeEdit.Text != "")
                {
                    using (Soft4UDbContext context = new Soft4UDbContext())
                    {
                        if (context.Programs.Where(e => e.Id != editProgram.Id && e.Name == editProgram.Name).FirstOrDefault() == null)
                        {
                            editProgram = context.Programs.Where(e => e.Id == editProgram.Id).First();
                            editProgram.Name = TxbNameEdit.Text;
                            editProgram.Cost = double.Parse(TxbCostEdit.Text);
                            editProgram.Discription = TxbDiscriptionEdit.Text;
                            editProgram.License = long.Parse(TxbTimeEdit.Text);
                            context.SaveChanges();
                            MessageBox.Show("Изменения прошло успешно", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Изменения не сохранены, так как уже существует ПО с именем {editProgram.Name}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    string str = "Изменения не сохранены, так как не заполнены поля: ";
                    str += (TxbNameEdit.Text == "") ? "  Название," : "";
                    str += (TxbDiscriptionEdit.Text == "") ? "  Описание," : "";
                    str += (TxbTimeEdit.Text == "") ? "  Длительность," : "";
                    str += (TxbCostEdit.Text == "") ? "  Стоимость," : "";
                    str = str.TrimEnd(',');
                    MessageBox.Show(str, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка. Изменения не сохранены.\n{ex.Message}", "Ошибка");
            }
        }
    }
}
