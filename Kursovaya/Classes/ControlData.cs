using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kursovaya.Classes
{
    internal class ControlData : AbstractData
    {
        public DataGrid grid { get; private set; }

        public ControlData(DataGrid grid)
        {
            this.grid = grid;
        }

        public override void Read(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                List<Entity> entities = new List<Entity>();
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        string[] entitySplit = line.Split(';');
                        int entityCost = Convert.ToInt32(entitySplit[1]);
                        bool entitySold = Convert.ToBoolean(entitySplit[5]);
                        Entity entity = new Entity(entitySplit[0], entityCost, entitySplit[2], entitySplit[3], entitySplit[4], entitySold);
                        entities.Add(entity);
                    }
                }
                this.grid.ItemsSource = entities;
            }
        }

        public override void Add(Entity entity)
        {
            using (StreamWriter sw = new StreamWriter(Constants.entityFile, true))
            {
                sw.WriteLineAsync(entity.ToString());
            }
            Update();
        }

        public override bool Check(ComboBox mark, TextBox cost, ComboBox color, ComboBox worker, ComboBox adress, ComboBox sold)
        {
            return mark.SelectedItem != null && cost.Text != null && color.SelectedItem != null && worker.SelectedItem != null && adress.SelectedItem != null && sold.SelectedItem != null;
        }

        public override Entity GetEntity(ComboBox marks, TextBox costs, ComboBox colors, ComboBox workers, ComboBox adresses, ComboBox solds)
        {
            string mark = marks.SelectedItem as string;
            int cost = Convert.ToInt32(costs.Text);
            string color = colors.SelectedItem as string;
            string worker = workers.SelectedItem as string;
            string adress = adresses.SelectedItem as string;
            bool? sold = solds.SelectedItem as bool?;
            return new Entity(mark, cost, color, worker, adress, (bool)sold);
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            AllEntities.count = 0;
            Read(Constants.entityFile);
        }
    }
}
