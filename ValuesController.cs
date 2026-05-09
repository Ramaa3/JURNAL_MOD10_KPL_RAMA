using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Modul10_103022400143
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public static List<Game> games = new List<Game>()
        {
            new Game() { Id = 1, Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = new List<string>{"PC"}, Mode = new List<string>{"Multiplayer"}, isOnline = true, Harga = 0 },
            new Game() { Id = 2, Nama = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, Platform = new List<string>{"PC", "PS4", "PS5", "Xbox"}, Mode = new List<string>{ "Singleplayer", "Multiplayer" }, isOnline = true, Harga = 300000 },
            new Game() { Id = 3, Nama = "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform =  new List<string>{ "PC", "PS4", "PS5", "Xbox", "Switch" }, Mode = new List<string>{ "Singleplayer"}, isOnline = false, Harga = 250000 }

        };

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return games;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            

            if (games == null ) {
                return NotFound();
            }
            return Ok(game);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<Game>Create(Game game)
        {
               games.Add(game);
               return Ok(game);
                
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Game> Put(int id, Game game)
        {
            var index = games.FindIndex(g => g.Id == id);


            if (index == -1)
            {
                return NotFound();
            }
            games[index] = game;
            return Ok(game);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);


            if (games == null)
            {
                return NotFound();
            }
            games.Remove(game);
            return Ok(game);
        }
    }
}
