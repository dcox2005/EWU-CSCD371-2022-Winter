using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester
{
    private IJokeService _JokeService;
    private IWriteJoke _WriteJoke;

    public Jester(IJokeService jokeService, IWriteJoke writeJoke)
    {
        if (jokeService is null || writeJoke is null) throw new ArgumentNullException();

        _JokeService = jokeService;
        _WriteJoke = writeJoke;
    }

    public void TellJoke()
    {
        string res = "";
        do
        {
            res = _JokeService.GetJoke();
        } while (res.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase) || res.Contains("ChuckNorris", StringComparison.OrdinalIgnoreCase));

        _WriteJoke.JokeWriter(res);
    }
}

