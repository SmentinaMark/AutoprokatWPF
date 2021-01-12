using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ИСС_Автопрокат.Data;
using ИСС_Автопрокат.MyWindow;
namespace ИСС_Автопрокат.MyPage
{
    /// <summary>
    /// Логика взаимодействия для DataPageClients.xaml
    /// </summary>
    public partial class DataPageClients : Page
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public static DataGrid dataGrid;
        public DataPageClients()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            DataGridClients.ItemsSource = carSaleEntities.Clients.ToList();
            dataGrid = DataGridClients;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridClients.SelectedItem == null)
            {
                MessageBox.Show("Выберите строку для удаления!", "", MessageBoxButton.OK);
            }
            else
            {
                int Id = (DataGridClients.SelectedItem as Clients).ID_Client;
                var del = carSaleEntities.Clients.Where(m => m.ID_Client == Id).Single();
                carSaleEntities.Clients.Remove(del);
                carSaleEntities.SaveChanges();
                DataGridClients.ItemsSource = carSaleEntities.Clients.ToList();
            }
        }
        private void UpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridClients.SelectedItem == null)
            {
                MessageBox.Show("Выберите строку для изменения!", "", MessageBoxButton.OK);
            }
            else 
            {
                int id = (DataGridClients.SelectedItem as Clients).ID_Client;
                UpdateClientWindow updateClientWindow = new UpdateClientWindow(id);
                updateClientWindow.ShowDialog();
            }
        }
    }
}
