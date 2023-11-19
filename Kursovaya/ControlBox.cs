using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya
{
    internal class ControlBox : AbstractBox
    {
        private ComboBox? box;
        protected override string file {  get; set; }
        protected List<string> items = new List<string>();

        public ControlBox(string fileName)
        {
            file = fileName;
            using (StreamReader sr = new StreamReader(file))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    items.Add(line);
                }
            }
        }
        public ControlBox(ComboBox box_, string fileName)
        {
            file = fileName;
            box = box_;
            using (StreamReader sr = new StreamReader(file))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if(line != "")
                    {
                        items.Add(line);
                    }
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
                await sw.WriteLineAsync();
            }
            using (StreamWriter sr = new StreamWriter(file, true))
            {
                foreach (string item in items)
                {
                    await sr.WriteLineAsync(item);
                }
            }
        }
    }
}
