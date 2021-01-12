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
    /// Логика взаимодействия для UpdateClientWindow.xaml
    /// </summary>
    public partial class UpdateClientWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        int Id;
        public UpdateClientWindow(int ClientsId)
        {
            InitializeComponent();
            Id = ClientsId;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Clients clients = (from m in carSaleEntities.Clients where m.ID_Client == Id select m).Single();
            carSaleEntities.SaveChanges();

            if(!string.IsNullOrEmpty(Nametbx.Text) && !string.IsNullOrEmpty(Countrytbx.Text) &&
                !string.IsNullOrEmpty(Citytbx.Text) && !string.IsNullOrEmpty(Streettbx.Text) &&
                !string.IsNullOrEmpty(numHtbx.Text) && int.TryParse(numHtbx.Text, out int id))
            {
                clients.FullName_Client = Nametbx.Text;
                clients.Country_Client = Countrytbx.Text;
                clients.City_Client = Citytbx.Text;
                clients.Street_Client = Streettbx.Text;
                clients.HouseNumber_Client = int.Parse(numHtbx.Text);
                DataPageClients.dataGrid.ItemsSource = carSaleEntities.Clients.ToList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Проверьте вводимые данные!", "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
