using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Tests
{
    internal class MockThing : ISavable
    {
        public string Name { get; set; }

        public MockThing(string name)
        {
            Name=name;
        }

        public string ToText()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }
}
