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
    /// Логика взаимодействия для SessionWindow.xaml
    /// </summary>
    public partial class SessionWindow : Window
    {
        private TimeSpan working = DateTime.Now - AllEntities.start;
        public SessionWindow(MainWindow main)
        {
            InitializeComponent();
            Records.Text = AllEntities.countEntity.ToString();
            Actions.Text = AllEntities.countActions.ToString();
            DateStart.Text = AllEntities.start.ToString();
            TimeRunning.Text = working.ToString();
        }
    }
}
