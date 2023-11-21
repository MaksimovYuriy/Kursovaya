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
        public AddWindow(MainWindow main_)
        {
            InitializeComponent();
            main = main_;
            controlBox.SetData(Marks, Constants.markFile);
            controlBox.SetData(Colors, Constants.colorFile);
        }
    }
}
