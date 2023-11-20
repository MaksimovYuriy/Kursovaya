using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    internal class Entity
    {
        public int id {  get; private set; }
        public string mark { get; private set; }
        public int cost { get; private set; }
        public string color { get; private set; }
        public string worker { get; private set; }
        public string adress { get; private set; }

        public Entity(int id, string mark, int cost, string color, string worker, string adress)
        {
            this.id = id;
            this.mark = mark;
            this.cost = cost;
            this.color = color;
            this.worker = worker;
            this.adress = adress;
        }
    }
}
