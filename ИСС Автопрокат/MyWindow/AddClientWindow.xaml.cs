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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public AddClientWindow()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Nametbx.Text) && !string.IsNullOrEmpty(Countrytbx.Text) &&
                !string.IsNullOrEmpty(Citytbx.Text) && !string.IsNullOrEmpty(Streettbx.Text) &&
                !string.IsNullOrEmpty(numHtbx.Text) && int.TryParse(numHtbx.Text, out int id))
            {
                Clients clients = new Clients()
                {
                    FullName_Client = Nametbx.Text,
                    Country_Client = Countrytbx.Text,
                    City_Client = Citytbx.Text,
                    Street_Client = Streettbx.Text,
                    HouseNumber_Client = int.Parse(numHtbx.Text)
                };
                carSaleEntities.Clients.Add(clients);
                carSaleEntities.SaveChanges();
                DataPageClients.dataGrid.ItemsSource = carSaleEntities.Clients.ToList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Проверьте вводимые данные!", "Ошибка", MessageBoxButton.OK);
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
