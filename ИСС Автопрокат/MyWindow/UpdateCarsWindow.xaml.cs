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
using ИСС_Автопрокат.Data;
using ИСС_Автопрокат.MyPage;

namespace ИСС_Автопрокат.MyWindow
{
    /// <summary>
    /// Логика взаимодействия для UpdateCarsWindow.xaml
    /// </summary>
    public partial class UpdateCarsWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        int Id;
        public UpdateCarsWindow(int ProductsId)
        {
            InitializeComponent();
            Id = ProductsId;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = (from m in carSaleEntities.Product where m.ID_Product == Id select m).Single();
            carSaleEntities.SaveChanges();

            if (!string.IsNullOrEmpty(Nametbx.Text) && !string.IsNullOrEmpty(Pricetbx.Text) && int.TryParse(Pricetbx.Text, out int id))
            {
                product.Name_Product = Nametbx.Text;
                product.Price_Product = Convert.ToDecimal(Pricetbx.Text);
                DataPageCars.dataGrid.ItemsSource = carSaleEntities.Product.ToList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Проверьте вводимые данные!", "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
