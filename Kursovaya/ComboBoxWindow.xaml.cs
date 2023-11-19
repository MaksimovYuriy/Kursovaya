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

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для ComboBoxWindow.xaml
    /// </summary>
    public partial class ComboBoxWindow : Window
    {
        MainWindow main;
        public ComboBoxWindow(MainWindow main_)
        {
            InitializeComponent();
            main = main_;
        }

        private void AddMarkButton_Click(object sender, RoutedEventArgs e)
        {
            ControlBox cb = new ControlBox(main.markFile);
            cb.Add(MarkTextBox.Text);
        }

        private void AddWorkerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddColorButton_Click(object sender, RoutedEventArgs e)
        {
            ControlBox cb = new ControlBox(main.colorFile);
            cb.Add(ColorTextBox.Text);
        }

        private void AddAdressButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
