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
            controlBox.SetData(Marks, Constants.markFile);
            controlBox.SetData(Colors, Constants.colorFile);
            controlBox.SetData(Adresses, Constants.adressFile);
            controlBox.SetData(Workers, Constants.workerFile);
            controlBox.SetBoolData(Solds);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (controlData.Check(Marks, Costs, Colors, Workers, Adresses, Solds))
            {
                controlData.Add(controlData.GetEntity(Marks, Costs, Colors, Workers, Adresses, Solds));
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
