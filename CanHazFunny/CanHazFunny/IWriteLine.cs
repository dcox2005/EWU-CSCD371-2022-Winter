using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public interface IWriteLine
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
