using JormungandrBE.Collections.Player.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JormungandrBE.Collections.Player.Controllers
{
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public ActionResult<Models.Player> GetPlayer(string id)
        {
            var player = _playerService.GetPlayer(id);
            if (player == null)
            {
                return new Models.Player();
            }
            return player;
        }

        [HttpPost]
        public ActionResult<Models.Player> CreatePlayer(Models.Player player)
        {
            _playerService.CreatePlayer(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        [HttpPut]
        public bool UpdatePlayer(string name, Models.Player player)
        {
            if (name != player.PlayerName)
            {
                return false;
            }

            _playerService.UpdatePlayer(name, player);
            return true;
        }

        [HttpDelete]
        public bool DeletePlayer(string name)
        {
            var player = _playerService.GetPlayer(name);
            if (player == null)
            {
                return false;
            }

            _playerService.DeletePlayer(name);
            return true;
        }
    }
}
