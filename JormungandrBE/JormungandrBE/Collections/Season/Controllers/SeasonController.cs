using JormungandrBE.Collections.EventResult.DTO;
using JormungandrBE.Collections.EventResult.Interfaces;
using JormungandrBE.Collections.Season.DTO;
using JormungandrBE.Collections.Season.Interfaces;
using JormungandrBE.Collections.SeasonEvent.DTO;
using JormungandrBE.Collections.SeasonEvent.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JormungandrBE.Collections.Season.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;
        private readonly ISeasonEventService _seasonEventService;
        private readonly IEventResultService _seasonEventResultService;
        public SeasonController(ISeasonService seasonService, ISeasonEventService seasonEventService, IEventResultService seasonEventResultService)
        {
            _seasonService = seasonService;
            _seasonEventService = seasonEventService;
            _seasonEventResultService = seasonEventResultService;
        }

        [HttpGet]
        public List<SeasonDTO> GetSeasonsByLeague(string leagueId)
        {
            var model = new List<SeasonDTO>();
            var seasons = _seasonService.GetSeasonsForLeague(leagueId);

            foreach (var season in seasons)
            {
                if (season == null) continue;
                var events = _seasonEventService.GetSeasonEventsForSeason(season.Id);
                var seasonDTO = new SeasonDTO
                {
                    Name = season.Name,
                    LeagueChampion = season.Winner,
                    GroupStageWinner = season.GroupStageWinner,
                    SeasonEvents = BuildEventDTOs(events),
                };
                model.Add(seasonDTO);
            }

            return model;
        }

        [HttpPost]
        public ActionResult<SeasonDTO> CreateSeason(SeasonDTO seasonDTO)
        {
            var season = new Models.Season
            {
                Name = seasonDTO.Name,
                Winner = seasonDTO.LeagueChampion,
                GroupStageWinner = seasonDTO.GroupStageWinner,
            };
            _seasonService.CreateSeason(season);
            return CreatedAtRoute("GetSeason", new { name = season.Name }, seasonDTO);
        }

        private List<SeasonEventDTO> BuildEventDTOs(List<SeasonEvent.Models.SeasonEvent> events)
        {
            var model = new List<SeasonEventDTO>();

            foreach (var e in events)
            {
                if (e != null)
                {
                    var eventDTO = new SeasonEventDTO
                    {
                        EventDate = e.Date,
                        EventNumber = e.EventNumber,
                        EventResults = BuildResultDTOs(e.Id),
                    };
                    model.Add(eventDTO);
                }
            }

            return model;
        }

        private List<EventResultDTO> BuildResultDTOs(string eventId)
        {
            var model = new List<EventResultDTO>();
            var results = _seasonEventResultService.GetEventResultsForEvent(eventId);
            foreach (var result in results)
            {
                var resultDTO = new EventResultDTO
                {
                    EventId = result.EventId,
                    PlayerId = result.PlayerId,
                    PlayerName = result.PlayerName,
                    Points = result.Points,
                    OMW = result.OMW,
                    GW = result.GW,
                    OGW = result.OGW,
                    Placement = result.Placement
                };
                model.Add(resultDTO);
            }
            return model;
        }
    }
}
