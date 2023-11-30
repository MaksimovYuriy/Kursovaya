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
    /// Логика взаимодействия для FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        private MainWindow main;
        private ControlBox controlBox = new ControlBox();
        private ControlData controlData;
        public FilterWindow(MainWindow main_)
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

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filterMark = Marks.SelectedItem?.ToString() ?? "";
                string filterColor = Colors.SelectedItem?.ToString() ?? "";
                string filterWorker = Workers.SelectedItem?.ToString() ?? "";
                string filterAdress = Adresses.SelectedItem?.ToString() ?? "";
                bool filterSold = Convert.ToBoolean(Solds.SelectedItem);
                controlData = new ControlData(main.Data);
                controlData.Update();
                AllEntities.FullFilter(main, filterMark, filterColor, filterWorker, filterAdress, filterSold);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
