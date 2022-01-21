using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture;

public abstract class Thing : ISavable
{
    public abstract string Name { get; set; }

    public Thing(string name)
    {
        Name = name;
    }

    public virtual string ToText()
    {
        return $"{nameof(Name)}: {Name}";
    }
}

