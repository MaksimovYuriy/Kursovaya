using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya.Classes
{
    static class DataOperations
    {
        public static void Write(List<string> list)
        {
            using (var sw = new StreamWriter(Constants.entityFile, false))
            {
                sw.WriteLineAsync(string.Empty);
            }
            using (var sw = new StreamWriter(Constants.entityFile, true))
            {
                foreach (var item in list)
                {
                    sw.WriteLineAsync(item);
                }
            }
        }

        public static void Remove(DataGrid grid)
        {
            List<string> rights = new List<string>();
            if (grid.SelectedItem != null)
            {
                string remove = (grid.SelectedItem as Entity).ToString();
                using (var sr = new StreamReader(Constants.entityFile))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != remove && line != "")
                        {
                            rights.Add(line);
                        }
                    }
                }
                Write(rights);
            }
        }

        public static void Sell(DataGrid grid)
        {
            List<string> rights = new List<string>();
            if (grid.SelectedItem != null)
            {
                Entity entity = grid.SelectedItem as Entity;
                string selectedEntity = entity.ToString();
                entity.Sell();
                string soldEntity = AllEntities.getSoldString(entity.ToString());
                using (var sr = new StreamReader(Constants.entityFile))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            if (line == selectedEntity)
                            {
                                rights.Add(soldEntity);
                            }
                            else
                            {
                                rights.Add(line);
                            }
                        }
                    }
                }
                Write(rights);
            }
        }
    }
}
