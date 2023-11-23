using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya.Classes
{
    abstract class AbstractData
    {
        public AbstractData() { }
        public abstract void Read(string file);
        public abstract void SetData();
        public abstract Entity GetEntity(ComboBox mark, TextBox cost, ComboBox color, ComboBox worker, ComboBox adress, ComboBox sold);
        public abstract bool Check(ComboBox mark, TextBox cost, ComboBox color, ComboBox worker, ComboBox adress, ComboBox sold);
        public abstract void Add(Entity entity);
        public abstract void Write(List<string> list);
        public abstract void Remove();
        public abstract void Update();
    }
}
