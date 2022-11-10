using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace P01WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private static List<Player> players = new List<Player>()
            {
                new Player()
                {
                    name = "Marcin",
                    lastName = "Nowak",
                    country = "Polska",
                    birthDate = "22.01.2000",
                    height = 1.8,
                    weigth = 82.2
                },
                new Player()
                {
                    name = "Karol",
                    lastName = "Inny",
                    country = "Niemcy",
                    birthDate = "12.11.1990",
                    height = 1.9,
                    weigth = 85.4
                },
                new Player()
                {
                    name = "Jan",
                    lastName = "Janowy",
                    country = "Grecja",
                    birthDate = "09.03.1990",
                    height = 1.95,
                    weigth = 88.4
                },
                new Player()
                {
                    name = "Marek",
                    lastName = "Jakis",
                    country = "Kanada",
                    birthDate = "22.01.1998",
                    height = 1.76,
                    weigth = 79.3
                }
            };

        [HttpGet]
        [Route("getPlayers")]
        public async Task<ActionResult<Player>> GetPlayers()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("getPlayersByCountry")]
        public async Task<ActionResult<Player>> GetPlayersByCountry(string conutry)
        {
            List<Player> foundPlayers = players.FindAll(x => x.country == conutry);
            if (foundPlayers == null)
                return BadRequest("No player not found");

            return Ok(foundPlayers);
        }

        [HttpGet]
        [Route("getPlayersHigherThan")]
        public async Task<ActionResult<Player>> GetPlayersHigherThan(double height)
        {
            List<Player> foundPlayers = players.FindAll(x => x.height > height);
            if (foundPlayers == null)
                return BadRequest("No player not found");

            return Ok(foundPlayers);
        }

        [HttpGet]
        [Route("getFirstNPlayers")]
        public async Task<ActionResult<Player>> GetFirstNPlayers(int n)
        {
            List<Player> firstNPlayers = players.Take(n).ToList();
            if (firstNPlayers == null)
                return BadRequest("No players in the list!");

            return Ok(firstNPlayers);
        }

        [HttpGet]
        [Route("getPlayer")]
        public async Task<ActionResult<Player>> GetPlayer(string name)
        {
            var player = players.Find(x => x.name == name);
            if (player == null)
                return BadRequest("Player not found");
            return Ok(player);
        }

        [HttpPost]
        [Route("postPlayer")]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            players.Add(player);
            return Ok(players);
        }

        [HttpPut]
        [Route("updatePlayer")]
        public async Task<ActionResult<Player>> UpdatePlayer(Player playerToUpdate)
        {
            var player = players.Find(x => x.name == playerToUpdate.name);
            if (player == null)
                return BadRequest("Player not found");

            player.name = playerToUpdate.name;
            player.lastName = playerToUpdate.lastName;
            player.country = playerToUpdate.country;
            player.birthDate = playerToUpdate.birthDate;
            player.height = playerToUpdate.height;
            player.weigth = playerToUpdate.weigth;

            return Ok(player);
        }

        [HttpDelete]
        [Route("deletePlayer")]
        public async Task<ActionResult<Player>> DeletePlayer(string name)
        {
            var player = players.Find(x => x.name == name);
            if (player == null)
                return BadRequest("Player not found");

            players.Remove(player);

            return Ok(player);
        }
    }
}
