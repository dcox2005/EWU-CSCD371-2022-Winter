using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester
{
    readonly private IJokeService _JokeService;
    readonly private IWriteJoke _WriteJoke;

    public Jester(IJokeService jokeService, IWriteJoke writeJoke)
    {
        if (jokeService is null)
        {
            throw new ArgumentNullException(nameof(jokeService));
        }

        if (writeJoke is null)
        {
            throw new ArgumentNullException(nameof(writeJoke));
        }
        _JokeService = jokeService;
        _WriteJoke = writeJoke;
    }

    public void TellJoke()
    {
        string res;
        do
        {
            res = _JokeService.GetJoke();
        } while (res.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase) || res.Contains("ChuckNorris", StringComparison.OrdinalIgnoreCase));

        _WriteJoke.JokeWriter(res);
    }
}

