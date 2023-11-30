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
using Kursovaya.Classes;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для ComboBoxWindow.xaml
    /// </summary>
    public partial class ComboBoxWindow : Window
    {
        private ControlBox controlBox = new ControlBox();
        public ComboBoxWindow(MainWindow main_)
        {
            InitializeComponent();
        }

        private void AddMarkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controlBox.Add(MarkTextBox.Text, Constants.markFile);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controlBox.Add(WorkerTextBox.Text, Constants.workerFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddColorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controlBox.Add(ColorTextBox.Text, Constants.colorFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAdressButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controlBox.Add(AdressTextBox.Text, Constants.adressFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
