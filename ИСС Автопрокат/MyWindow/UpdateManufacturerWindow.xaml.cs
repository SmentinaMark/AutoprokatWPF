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

namespace ИСС_Автопрокат.MyWindow
{
    /// <summary>
    /// Логика взаимодействия для UpdateManufacturerWindow.xaml
    /// </summary>
    public partial class UpdateManufacturerWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        int Id;
        public UpdateManufacturerWindow(int IdManuf)
        {
            InitializeComponent();
            Id = IdManuf;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manufacturers manufacturers= (from m in carSaleEntities.Manufacturers where m.ID_Manufacturer == Id select m).Single();
            carSaleEntities.SaveChanges();

            if (!string.IsNullOrEmpty(Nametbx.Text) && !string.IsNullOrEmpty(Countrytbx.Text) &&
                !string.IsNullOrEmpty(Citytbx.Text) && !string.IsNullOrEmpty(Streettbx.Text) &&
                !string.IsNullOrEmpty(NumHousetbx.Text) && !string.IsNullOrEmpty(NumCartbx.Text) &&
                int.TryParse(NumCartbx.Text, out int idCar) && int.TryParse(NumHousetbx.Text, out int idNumh))
            {
                manufacturers.Name_Manufacturer = Nametbx.Text;
                manufacturers.Country_Manufacturer = Countrytbx.Text;
                manufacturers.City_Manufacturer = Citytbx.Text;
                manufacturers.Street_Manufacturer = Streettbx.Text;
                manufacturers.HouseNumber_Manufacturer = int.Parse(NumHousetbx.Text);
                manufacturers.CodeProduct_Manufacturer = int.Parse(NumCartbx.Text);
                ManufacturersWindow.dataGrid.ItemsSource = carSaleEntities.Manufacturers.ToList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Проверьте вводимые данные!", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NumCartbx.ItemsSource = carSaleEntities.Product.ToList();
            NumCartbx.DisplayMemberPath = "ID_Product";
        }
    }
}
