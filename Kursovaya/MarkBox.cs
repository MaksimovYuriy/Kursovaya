using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya
{
    internal class MarkBox : AbstractBox
    {
        private ComboBox? box;
        protected string file = @"C:\Users\yuram\OneDrive\Рабочий стол\ООП Лабы\Kursovaya\Kursovaya\MarkList.txt";
        protected List<string> items = new List<string>();

        public MarkBox()
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    items.Add(line);
                }
            }
        }
        public MarkBox(ComboBox box_)
        {
            box = box_;
            using (StreamReader sr = new StreamReader(file))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    items.Add(line);
                }
            }
            box.ItemsSource = items;
        }

        public override void Add(string x)
        {
            items.Add(x);
            Reset();
        }

        public override async void Reset()
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                await sw.WriteLineAsync(string.Empty);
            }
            using (StreamWriter sr = new StreamWriter(file, true))
            {
                foreach(string item in items)
                {
                    await sr.WriteLineAsync(item);
                }
            }
        }
    }
}
