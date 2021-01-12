using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using ИСС_Автопрокат.Data;
using ИСС_Автопрокат.MyWindow;

namespace ИСС_Автопрокат.MyPage
{
    /// <summary>
    /// Логика взаимодействия для DataPageCars.xaml
    /// </summary>
    public partial class DataPageCars : Page
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public static DataGrid dataGrid;
        DataSet dataSet;
        public DataPageCars()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            DataGridCars.ItemsSource = carSaleEntities.Product.ToList();
            dataGrid = DataGridCars;
        }
        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            AddCarsWindow addCarsWindow = new AddCarsWindow();
            addCarsWindow.ShowDialog();
        }
        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCars.SelectedItem == null)
            {
                MessageBox.Show("Выберите строку для удаления!", "", MessageBoxButton.OK);
            }
            else
            {
                int Id = (DataGridCars.SelectedItem as Product).ID_Product;
                var del = carSaleEntities.Product.Where(m => m.ID_Product == Id).Single();
                carSaleEntities.Product.Remove(del);
                carSaleEntities.SaveChanges();
                DataGridCars.ItemsSource = carSaleEntities.Product.ToList();
            }
        }
        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCars.SelectedItem == null)
            {
                MessageBox.Show("Выберите строку для изменения!", "", MessageBoxButton.OK);
            }
            else
            {
                int id = (DataGridCars.SelectedItem as Product).ID_Product;
                UpdateCarsWindow updateCarsWindow = new UpdateCarsWindow(id);
                updateCarsWindow.ShowDialog();
            }
        }

        private void Manufactbtn_Click(object sender, RoutedEventArgs e)
        {
            ManufacturersWindow manufacturersWindow = new ManufacturersWindow();
            manufacturersWindow.Show();
        }
    }
}
