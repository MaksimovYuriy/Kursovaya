using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya.Classes
{
    abstract class AbstractData
    {
        public abstract DataGrid data { get; set; }

        public AbstractData(DataGrid data_)
        {
            data = data_;
        }

        public abstract void Add();
        public abstract void Remove();
    }
}
