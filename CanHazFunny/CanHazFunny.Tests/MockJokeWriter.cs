using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;

public class MockJokeWriter : IWriteJoke
{
    public string? Output { get; set; }
    public void JokeWriter(string message)
    {
        Output = message;
    }
}
