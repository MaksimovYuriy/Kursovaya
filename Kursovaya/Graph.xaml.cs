using Kursovaya.Classes;
using ScottPlot.Plottable;
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
    /// Логика взаимодействия для Graph.xaml
    /// </summary>
    public partial class Graph : Window
    {
        private double[]? X;
        private double[]? Y;
        private MainWindow main;
        private ControlData cd;
        public Graph(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            cd = new ControlData(main.Data);
        }

        private void BuildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                X = cd.getDaysForGraph(Convert.ToInt32(NDays.Text));
                Y = cd.getValuesForGraph(Convert.ToInt32(NDays.Text));

                SellGraph.Plot.AddScatter(X, Y);
                SellGraph.Plot.XAxis.DateTimeFormat(true);
                SellGraph.Refresh();
                SellGraph.Reset();
            }
            catch
            {
                MessageBox.Show("Минимальное количество дней: 4");
            }
        }
    }
}
