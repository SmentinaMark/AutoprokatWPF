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
    /// Логика взаимодействия для ManufacturersWindow.xaml
    /// </summary>
    public partial class ManufacturersWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public static DataGrid dataGrid;
        public ManufacturersWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            DataGridManufacturer.ItemsSource = carSaleEntities.Manufacturers.ToList();
            dataGrid = DataGridManufacturer;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturerWindow addManufacturerWindow = new AddManufacturerWindow();
            addManufacturerWindow.ShowDialog();
        }

        private void updBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (DataGridManufacturer.SelectedItem as Manufacturers).ID_Manufacturer;
            UpdateManufacturerWindow updateManufacturerWindow = new UpdateManufacturerWindow(Id);
            updateManufacturerWindow.ShowDialog();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridManufacturer.SelectedItem == null)
            {
                MessageBox.Show("Проверьте вводимые данные!", "Ошибка", MessageBoxButton.OK);
            }
            else
            {
                int Id = (DataGridManufacturer.SelectedItem as Manufacturers).ID_Manufacturer;
                var del = carSaleEntities.Manufacturers.Where(m => m.ID_Manufacturer == Id).Single();
                carSaleEntities.Manufacturers.Remove(del);
                carSaleEntities.SaveChanges();
                DataGridManufacturer.ItemsSource = carSaleEntities.Manufacturers.ToList();
            }
        }
    }
}
