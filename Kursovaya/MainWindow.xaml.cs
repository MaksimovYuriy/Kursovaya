using Kursovaya.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private ControlData? cd;
        public MainWindow()
        {
            InitializeComponent();
            ControlBox controlBox = new ControlBox();
            controlBox.SetData(Marks, Constants.markFile);
        }

        private void SessionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SessionWindow SessionWnd = new SessionWindow(this);
                SessionWnd.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxWindow ComboBoxWnd = new ComboBoxWindow(this);
                ComboBoxWnd.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddWindow AddWnd = new AddWindow(this);
                AddWnd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Marks.SelectedItem = null;
                cd = new ControlData(Data);
                cd.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cd = new ControlData(Data);
                DataOperations.Remove(Data, cd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cd = new ControlData(Data);
                DataOperations.Sell(Data, cd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                Marks.SelectedItem = null;
                cd = new ControlData(Data);
                cd.Update();
                AllEntities.FilterSold(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                cd = new ControlData(Data);
                cd.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Marks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CheckBox.IsChecked = false;
                cd = new ControlData(Data);
                cd.Update();
                AllEntities.FilterMark(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FilterWindow FilterWnd = new FilterWindow(this);
                FilterWnd.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}