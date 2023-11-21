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
        private MainWindow main;
        private ControlBox controlBox = new ControlBox();
        public ComboBoxWindow(MainWindow main_)
        {
            InitializeComponent();
            main = main_;
        }

        private void AddMarkButton_Click(object sender, RoutedEventArgs e)
        {
            controlBox.Add(MarkTextBox.Text, main.markFile);
        }

        private void AddWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            controlBox.Add(WorkerTextBox.Text, main.workerFile);
        }

        private void AddColorButton_Click(object sender, RoutedEventArgs e)
        {
            controlBox.Add(ColorTextBox.Text, main.colorFile);
        }

        private void AddAdressButton_Click(object sender, RoutedEventArgs e)
        {
            controlBox.Add(AdressTextBox.Text, main.adressFile);
        }
    }
}
