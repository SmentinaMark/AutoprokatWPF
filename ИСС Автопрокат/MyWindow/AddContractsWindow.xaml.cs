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
    /// Логика взаимодействия для AddContractsWindow.xaml
    /// </summary>
    public partial class AddContractsWindow : Window
    {
        CarSaleEntities carSaleEntities = new CarSaleEntities();
        public AddContractsWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxAuto.ItemsSource = carSaleEntities.Product.ToList();
            cbxAuto.DisplayMemberPath = "ID_Product";

            cbxClient.ItemsSource = carSaleEntities.Clients.ToList();
            cbxClient.DisplayMemberPath = "ID_Client";
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxAuto.Text) && !string.IsNullOrEmpty(cbxClient.Text) &&
                !string.IsNullOrEmpty(dataTimePicker.Text) && int.TryParse(cbxAuto.Text, out int idAuto) &&
                int.TryParse(cbxClient.Text, out int idClient))
            {
                Contracts contracts = new Contracts()
                {
                    CodeProduct_Contract = int.Parse(cbxAuto.Text),
                    CodeClient_Contract = int.Parse(cbxClient.Text),
                    Date_Contract = dataTimePicker.Text,
                };
                carSaleEntities.Contracts.Add(contracts);
                carSaleEntities.SaveChanges();
                DataPageContracts.dataGrid.ItemsSource = carSaleEntities.Contracts.ToList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Проверьте вводимые данные!", "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
