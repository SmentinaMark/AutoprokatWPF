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
    /// Логика взаимодействия для AddCarsWindow.xaml
    /// </summary>
    public partial class AddCarsWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public AddCarsWindow()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Nametbx.Text) && !string.IsNullOrEmpty(Pricetbx.Text) && int.TryParse(Pricetbx.Text, out int id))
            {
                Product product = new Product()
                {
                    Name_Product = Nametbx.Text,
                    Price_Product = Convert.ToDecimal(Pricetbx.Text)
                };
                carSaleEntities.Product.Add(product);
                carSaleEntities.SaveChanges();
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
