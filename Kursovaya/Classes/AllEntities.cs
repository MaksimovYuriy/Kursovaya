using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kursovaya.Classes
{
    static class AllEntities
    {
        public static int countEntity = 0;
        public static int countActions = 0;

        public static DateTime start = DateTime.Now;

        public static string getSoldString(string line)
        {
            string[] split = line.Split(';');
            string result = split[0] + ";" + split[1] + ";" + split[2] + ";" + split[3] + ";" + split[4] + ";" + "True";
            return result;
        }

        public static void Filter(MainWindow main)
        {
            var SourceList = new CollectionViewSource() { Source = main.Data.ItemsSource };
            ICollectionView ICV = SourceList.View;
            var filter = new Predicate<object>(x => ((Entity)x).sold == true);
            ICV.Filter = filter;
            main.Data.ItemsSource = ICV;
        }
    }
}
