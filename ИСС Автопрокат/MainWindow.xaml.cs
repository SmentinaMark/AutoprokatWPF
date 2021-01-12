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
using ИСС_Автопрокат.MyPage;

namespace ИСС_Автопрокат
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainBtnClick_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MainPage();
        }

        private void ClientBtnClick_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DataPageClients();
        }

        private void AutoBtnClick_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DataPageCars();
        }

        private void ContractsBtnClick_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DataPageContracts();
        }
    }
}
