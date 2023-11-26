using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace Kursovaya.Classes
{
    internal class ControlData : AbstractData
    {
        public DataGrid grid { get; private set; }
        private List<Entity> data = new List<Entity>();

        public ControlData(DataGrid grid)
        {
            this.grid = grid;
        }

        public override void Read(string file)
        {
            data.Clear();
            using (StreamReader sr = new StreamReader(file))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        string[] entitySplit = line.Split(';');
                        int entityCost = Convert.ToInt32(entitySplit[1]);
                        bool entitySold = Convert.ToBoolean(entitySplit[5]);
                        Entity entity = new Entity(entitySplit[0], entityCost, entitySplit[2], entitySplit[3], entitySplit[4], entitySold);
                        data.Add(entity);
                    }
                }
            }
        }

        public override void SetData()
        {
            grid.ItemsSource = data;
            AllEntities.countActions += 1;
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

        public override void Update()
        {
            AllEntities.countEntity = 0;
            Read(Constants.entityFile);
            SetData();
        }
    }
}
