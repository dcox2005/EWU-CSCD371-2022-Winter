using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Tests;

public class Student : Person
{
    // This is bad design used for simplicity (don't do this at home) :)
    public Grade Grade { get; set; }
    public Student(string name) : base(name)
    {

    }
}
