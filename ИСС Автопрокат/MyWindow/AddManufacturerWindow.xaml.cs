﻿using System;
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
    /// Логика взаимодействия для AddManufacturerWindow.xaml
    /// </summary>
    public partial class AddManufacturerWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public AddManufacturerWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Nametbx.Text) && !string.IsNullOrEmpty(Countrytbx.Text) &&
                !string.IsNullOrEmpty(Citytbx.Text) && !string.IsNullOrEmpty(Streettbx.Text) &&
                !string.IsNullOrEmpty(NumHousetbx.Text) && !string.IsNullOrEmpty(NumCartbx.Text) && 
                int.TryParse(NumCartbx.Text, out int idCar) && int.TryParse(NumHousetbx.Text, out int idNumh))
            {
                Manufacturers manufacturers = new Manufacturers()
                {
                    Name_Manufacturer = Nametbx.Text,
                    Country_Manufacturer = Countrytbx.Text,
                    City_Manufacturer = Citytbx.Text,
                    Street_Manufacturer = Streettbx.Text,
                    HouseNumber_Manufacturer = int.Parse(NumHousetbx.Text),
                    CodeProduct_Manufacturer = int.Parse(NumCartbx.Text)
                };
                carSaleEntities.Manufacturers.Add(manufacturers);
                carSaleEntities.SaveChanges();
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
