using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya.Classes
{
    internal class ControlBox : AbstractBox
    {
        public ControlBox() { }

        public override void SetData(ComboBox box, string file)
        {
            List<string> items = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        items.Add(line);
                    }
                }
            }
            box.ItemsSource = items;
        }

        public override void SetBoolData(ComboBox box)
        {
            bool[] bools = new bool[2];
            bools[0] = false;
            bools[1] = true;
            box.ItemsSource = bools;
        }

        public override void Add(string x, string file)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLineAsync(x);
            }
        }
    }
}