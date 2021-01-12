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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ИСС_Автопрокат.Data;
using ИСС_Автопрокат.MyWindow;

namespace ИСС_Автопрокат.MyPage
{
    /// <summary>
    /// Логика взаимодействия для DataPageContracts.xaml
    /// </summary>
    public partial class DataPageContracts : Page
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public static DataGrid dataGrid;
        public DataPageContracts()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            DataGridContracts.ItemsSource = carSaleEntities.Contracts.ToList();
            dataGrid = DataGridContracts;
        }
        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            AddContractsWindow addContractsWindow = new AddContractsWindow();
            addContractsWindow.Show();
        }

        private void Updatebtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridContracts.SelectedItem == null)
            {
                MessageBox.Show("Выберите строку для изменения!", "", MessageBoxButton.OK);
            }
            else
            {
                int id = (DataGridContracts.SelectedItem as Contracts).ID_Contract;
                UpdateContractsWindow updateContractWindow = new UpdateContractsWindow(id);
                updateContractWindow.ShowDialog();
            }
        }
    }
}
