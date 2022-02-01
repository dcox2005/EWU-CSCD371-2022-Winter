using System;
using System.Net.Http;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        //Uri jokeURL = new("https://geek-jokes.sameerkumar.website/api");
        //string joke = HttpClient.GetStringAsync(jokeURL).Result;
        //return joke;

        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        return joke;
    }
}
