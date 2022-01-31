using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public interface IWriteJoke
{
    public virtual void JokeWriter(string message)
    {
        Console.WriteLine(message);
    }
}
