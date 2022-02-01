using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester : IJokeService, IWriteJoke
{
    private JokeService _JokeService;
    private WriteJoke _WriteJoke;

    public string GetJoke()
    {
        string res = "";
        do
        {
            res = _JokeService.GetJoke();
        } while (res.Contains("Chuck Norris"));
        return res;

        //look to catch "ChuckNorris" and other varients that ignore case
    }

    public Jester(JokeService jokeService, WriteJoke writeJoke)
    {
        if (jokeService is null || writeJoke is null) throw new ArgumentNullException();

        _JokeService = jokeService;
        _WriteJoke = writeJoke;
    }

    public void TellJoke()
    {
        string res = GetJoke();
        _WriteJoke.JokeWriter(res);
    }
}

