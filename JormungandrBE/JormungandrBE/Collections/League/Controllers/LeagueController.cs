using JormungandrBE.Collections.League.DTO;
using JormungandrBE.Collections.League.Interfaces;
using JormungandrBE.Collections.Season.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JormungandrBE.Collections.League.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        private readonly ISeasonService _seasonService;

        public LeagueController(ILeagueService leagueService, ISeasonService seasonService)
        {
            _leagueService = leagueService;
            _seasonService = seasonService;
        }

        [HttpGet]
        public LeagueDTO Get()
        {
            var model = new LeagueDTO();
            var league = _leagueService.GetLeagues().FirstOrDefault();

            if (league != null)
            {
                model.Name = league.Name;
                model.Format = league.Format;
                model.Preamble = league.Preamble;
                model.Prizes = league.Prizes;
                model.TieBreakers = league.TieBreakers;
                model.PointLeaders = league.PointLeaders;
                model.MetaGame = league.MetaGame;
            }

            return model;
        }

        [HttpPost]
        public void Post([FromBody] LeagueDTO model)
        {
            var league = new Models.League
            {
                Name = model.Name,
                Format = model.Format,
                Preamble = model.Preamble,
                Prizes = model.Prizes,
                TieBreakers = model.TieBreakers,
                PointLeaders = model.PointLeaders,
                MetaGame = model.MetaGame
            };
            _leagueService.CreateLeague(league);
        }
    }
}
