using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya.Classes
{
    abstract class AbstractBox
    {
        protected abstract string file { get; set; }
        public AbstractBox() { }

        public abstract void Add(string x);
        public abstract void Reset();
    }
}
