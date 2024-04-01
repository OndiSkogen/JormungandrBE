using JormungandrBE.Collections.Deck.Interfaces;
using JormungandrBE.Collections.MetaGame.DTO;
using JormungandrBE.Collections.MetaGame.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JormungandrBE.Collections.MetaGame.Controllers
{
    public class MetaGameController : ControllerBase
    {
        private readonly IMetaGameService _metaGameService;
        private readonly IDeckService _deckService;
        public MetaGameController(IMetaGameService metaGameService, IDeckService deckService)
        {
            _metaGameService = metaGameService;
            _deckService = deckService;
        }

        [HttpGet]
        public List<MetaGameDTO> GetMetaGamesBySeason(string seasonId)
        {
            var model = new List<MetaGameDTO>();
            var metaGames = _metaGameService.GetMetaGamesForSeason(seasonId);

            foreach (var metaGame in metaGames)
            {
                new MetaGameDTO
                {
                    SeasonEvent = metaGame.SeasonEvent,
                    Decks = metaGame.Decks,
                };
            }

            return model;
        }

        [HttpPost]
        public ActionResult<MetaGameDTO> CreateMetaGame(MetaGameDTO metaGameDTO)
        {
            var metaGame = new Models.MetaGame
            {
                SeasonEvent = metaGameDTO.SeasonEvent,
                Decks = metaGameDTO.Decks,
            };
            _metaGameService.CreateMetaGame(metaGame);
            return CreatedAtRoute("GetMetaGame", new { id = metaGame.Id }, metaGameDTO);
        }
    }
}
