using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya.Classes
{
    internal class Entity
    {
        public int id { get; private set; }
        public string mark { get; private set; }
        public int cost { get; private set; }
        public string color { get; private set; }
        public string worker { get; private set; }
        public string adress { get; private set; }
        public bool sold { get; private set; }
        public DateOnly date { get; private set; }

        public Entity(string mark, int cost, string color, string worker, string adress, bool sold)
        {
            this.id = AllEntities.countEntity;
            AllEntities.countEntity++;

            this.mark = mark;
            this.cost = cost;
            this.color = color;
            this.worker = worker;
            this.adress = adress;
            this.sold = sold;
            this.date = DateOnly.FromDateTime(DateTime.Now);
        }

        public Entity(string mark, int cost, string color, string worker, string adress, bool sold, DateOnly date)
        {
            this.id = AllEntities.countEntity;
            AllEntities.countEntity++;

            this.mark = mark;
            this.cost = cost;
            this.color = color;
            this.worker = worker;
            this.adress = adress;
            this.sold = sold;
            this.date = date;
        }

        public override string ToString()
        {
            return $"{mark};{cost};{color};{worker};{adress};{sold};{date}";
        }

        public void Sell()
        {
            if (!sold)
            {
                sold = true;
                date = DateOnly.FromDateTime(DateTime.Now);
            }
        }
    }
}
