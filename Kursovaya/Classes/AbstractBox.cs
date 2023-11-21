﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kursovaya.Classes
{
    abstract class AbstractBox
    {
        public AbstractBox() { }
        public abstract void Add(string x, string file);
        public abstract void SetData(ComboBox box, string file);
        public abstract void SetBoolData(ComboBox box);
    }
}
