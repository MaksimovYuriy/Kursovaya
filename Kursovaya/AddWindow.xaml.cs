using Kursovaya.Classes;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private MainWindow main;
        private ControlBox controlBox = new ControlBox();
        private ControlData controlData;
        public AddWindow(MainWindow main_)
        {
            InitializeComponent();
            main = main_;
            controlData = new ControlData(main.Data);
            controlBox.setData(Marks, Constants.markFile);
            controlBox.setData(Colors, Constants.colorFile);
            controlBox.setData(Adresses, Constants.adressFile);
            controlBox.setData(Workers, Constants.workerFile);
            controlBox.setBoolData(Solds);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataOperations.Add(controlData.getEntity(Marks, Costs, Colors, Workers, Adresses, Solds), controlData);
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
