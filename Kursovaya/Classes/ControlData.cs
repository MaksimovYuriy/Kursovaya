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
        public List<Entity> data = new List<Entity>();

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
                        DateOnly date = DateOnly.FromDateTime(Convert.ToDateTime(entitySplit[6]));
                        Entity entity = new Entity(entitySplit[0], entityCost, entitySplit[2], entitySplit[3], entitySplit[4], entitySold, date);
                        data.Add(entity);
                    }
                }
            }
        }

        public override void setData()
        {
            grid.ItemsSource = data;
            AllEntities.countActions += 1;
        }

        public override Entity getEntity(ComboBox marks, TextBox costs, ComboBox colors, ComboBox workers, ComboBox adresses, ComboBox solds)
        {
            string mark = marks.SelectedItem as string ?? "";
            int cost = 0;
            if (Convert.ToInt64(costs.Text) >= 1000000000)
            {
                MessageBox.Show("Цена слишком большая!");
            }
            cost = Convert.ToInt32(costs.Text);
            string color = colors.SelectedItem as string ?? "";
            string worker = workers.SelectedItem as string ?? "";
            string adress = adresses.SelectedItem as string ?? "";
            bool sold = Convert.ToBoolean(solds.SelectedItem);
            return new Entity(mark, cost, color, worker, adress, (bool)sold);
        }

        public override void Update()
        {
            AllEntities.countEntity = 0;
            Read(Constants.entityFile);
            setData();
        }

        public double[] getDaysForGraph(int n)
        {
            DateTime[] dateOnlies = new DateTime[n];
            for (int i = 0; i < dateOnlies.Length; i++)
            {
                dateOnlies[i] = DateTime.Today.AddDays((-1) * i);
            }
            dateOnlies.Reverse();
            double[] result = new double[n];
            for (int i = 0; i < dateOnlies.Length; i++)
            {
                result[i] = dateOnlies[i].ToOADate();
            }
            return result;
        }

        public double[] getValuesForGraph(int n)
        {
            var Dict = new Dictionary<DateTime, int>();
            DateTime[] dateOnlies = new DateTime[n];
            for (int i = 0; i < dateOnlies.Length; i++)
            {
                dateOnlies[i] = DateTime.Today.AddDays((-1) * i);
            }
            dateOnlies.Reverse();
            foreach(var item in dateOnlies)
            {
                Dict.Add(item, 0);
            }
            Update();
            foreach(var item in data)
            {
                string[] entity = item.ToString().Split(';');
                if (Convert.ToBoolean(entity[5]))
                {
                    DateTime date = Convert.ToDateTime(entity[6]);
                    if (date >= DateTime.Today.AddDays(-4))
                    {
                        Dict[date]++;
                    }
                }
            }
            double[] result = new double[n];
            int k = 0;
            foreach(var item in Dict)
            {
                result[k] = item.Value;
                k++;
            }
            return result;
        }
    }
}
