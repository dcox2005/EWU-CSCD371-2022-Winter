using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class WriteJoke: IWriteJoke
{
    public void JokeWriter(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }
        Console.WriteLine(message);
    }
}

