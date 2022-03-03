using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WordleApp.Controllers
{
    [Route("api/wordle")]
    [ApiController]
    public class WordleController : ControllerBase
    {
        private List<string>? _Words;
        public List<string> Words
        {
            get
            {
                if (_Words is null)
                {
                    _Words = System.IO.File().ReadAllLines("Words.txt").ToList();
                }
                return _Words;
            }
        }
    }

    // Route = /api/wordle/WordCount
    [HttpGet("WordCount")]
    public int GetWordCount()
    {
        return Words.Count;
    }
}
