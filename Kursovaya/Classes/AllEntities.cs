﻿using System;
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
            string result = split[0] + ";" + split[1] + ";" + split[2] + ";" + split[3] + ";" + split[4] + ";" + "True" + ";" + split[6];
            return result;
        }

        public static void filterSold(MainWindow main)
        {
            var SourceList = new CollectionViewSource() { Source = main.Data.ItemsSource };
            ICollectionView ICV = SourceList.View;
            var filter = new Predicate<object>(x => ((Entity)x).sold == true);
            ICV.Filter = filter;
            if (ICV != null)
            {
                main.Data.ItemsSource = ICV;
            }
        }

        public static void filterMark(MainWindow main)
        {
            var SourceList = new CollectionViewSource() { Source = main.Data.ItemsSource };
            ICollectionView ICV = SourceList.View;
            var filter = new Predicate<object>(x => ((Entity)x).mark == (main.Marks.SelectedItem as string));
            ICV.Filter = filter;
            if (ICV != null)
            {
                main.Data.ItemsSource = ICV;
            }
        }

        public static void fullFilter(MainWindow main, string mark, string color, string worker, string adress, bool? sold)
        {
            var SourceList = new CollectionViewSource() { Source = main.Data.ItemsSource };
            ICollectionView ICV = SourceList.View;

            if(sold != null)
            {
                var filter = new Predicate<object>(x => ((Entity)x).mark.Contains(mark) && ((Entity)x).color.Contains(color) && ((Entity)x).worker.Contains(worker) && ((Entity)x).adress.Contains(adress) && ((Entity)x).sold == sold);
                ICV.Filter = filter;
            }
            else
            {
                var filter = new Predicate<object>(x => ((Entity)x).mark.Contains(mark) && ((Entity)x).color.Contains(color) && ((Entity)x).worker.Contains(worker) && ((Entity)x).adress.Contains(adress));
                ICV.Filter = filter;
            }
            if (ICV != null)
            {
                main.Data.ItemsSource = ICV;
            }
        }
    }
}
