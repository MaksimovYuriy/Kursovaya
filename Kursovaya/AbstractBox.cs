using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya
{
    abstract class AbstractBox
    {
        public AbstractBox() { }

        public abstract void Add(string x);
        public abstract void Reset();
    }
}
