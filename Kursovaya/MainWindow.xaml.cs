using Kursovaya.Classes;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterWindow FilterWnd = new FilterWindow(this);
            FilterWnd.Show();
        }

        private void SessionButton_Click(object sender, RoutedEventArgs e)
        {
            SessionWindow SessionWnd = new SessionWindow(this);
            SessionWnd.Show();
        }

        private void ComboBoxButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxWindow ComboBoxWnd = new ComboBoxWindow(this);
            ComboBoxWnd.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow AddWnd = new AddWindow(this);
            AddWnd.Show();
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            ControlData cd = new ControlData(Data);
            if(Data.ItemsSource == null)
            {
                cd.Update();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ControlData cd = new ControlData(Data);
            DataOperations.Remove(Data);
            cd.Update();
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            ControlData cd = new ControlData(Data);
            DataOperations.Sell(Data);
            cd.Update();
        }
    }
}