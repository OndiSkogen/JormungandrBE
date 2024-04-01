using JormungandrBE.Collections.EventResult.Interfaces;
using JormungandrBE.Collections.Player.Interfaces;
using JormungandrBE.Collections.SeasonEvent.Interfaces;
using JormungandrBE.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JormungandrBE.Collections.SeasonEvent.Controllers
{
    public class SeasonEventController : ControllerBase
    {
        private readonly ISeasonEventService _seasonEventService;
        private readonly IPlayerService _playerService;
        private readonly IEventResultService _eventResultService;

        public SeasonEventController(ISeasonEventService seasonEventService, IPlayerService playerService, IEventResultService eventResultService)
        {
            _seasonEventService = seasonEventService;
            _playerService = playerService;
            _eventResultService = eventResultService;
        }
        [HttpGet]
        public Models.SeasonEvent GetSeasonEvent(string id)
        {
            var seasonEvent = _seasonEventService.GetSeasonEvent(id);
            if (seasonEvent == null)
            {
                return new Models.SeasonEvent();
            }
            return seasonEvent;
        }
        [HttpPost]
        public CreateEventDTO CreateSeasonEvent(CreateEventDTO seasonEvent)
        {
            var newEvent = new Models.SeasonEvent
            {
                Date = seasonEvent.Date,
                EventNumber = seasonEvent.EventNumber,
                SeasonId = seasonEvent.SeasonId
            };

            foreach (var result in seasonEvent.EventResults)
            {
                var eventResult = new EventResult.Models.EventResult
                {
                    EventId = result.EventId,
                    PlayerId = result.PlayerId,
                    PlayerName = result.PlayerName,
                    Points = result.Points,
                    OMW = result.OMW,
                    GW = result.GW,
                    OGW = result.OGW,
                    Placement = result.Placement,
                };
                _eventResultService.CreateEventResult(eventResult);
                var player = _playerService.GetPlayer(result.PlayerName);
                if (player == null)
                {
                    player = new Player.Models.Player
                    {
                        PlayerName = result.PlayerName,
                        Events = 1,
                        Points = result.Points
                    };
                    player = AddWinLossTie(player, result.Points);
                    _playerService.CreatePlayer(player);
                }
                else
                {
                    player.Events++;
                    player.Points += result.Points;
                    player = AddWinLossTie(player, result.Points);
                    _playerService.UpdatePlayer(result.PlayerName, player);
                }
            }

            _seasonEventService.CreateSeasonEvent(newEvent);
            seasonEvent.Success = true;

            return seasonEvent;
        }
        [HttpPut]
        public bool UpdateSeasonEvent(string id, Models.SeasonEvent seasonEvent)
        {
            if (id != seasonEvent.Id)
            {
                return false;
            }

            _seasonEventService.UpdateSeasonEvent(id, seasonEvent);
            return true;
        }
        [HttpDelete]
        public bool DeleteSeasonEvent(string id)
        {
            var seasonEvent = _seasonEventService.GetSeasonEvent(id);
            if (seasonEvent == null)
            {
                return false;
            }
            _seasonEventService.DeleteSeasonEvent(id);
            return true;
        }

        private Player.Models.Player AddWinLossTie(Player.Models.Player player, int points)
        {
            switch (points)
            {
                case 0:
                    player.Losses += 4;
                    break;
                case 1:
                    player.Ties++;
                    player.Losses += 3;
                    break;
                case 2:
                    player.Ties += 2;
                    player.Losses += 2;
                    break;
                case 3:
                    player.Wins++;
                    player.Losses += 3;
                    break;
                case 4:
                    player.Wins++;
                    player.Ties++;
                    player.Losses += 2;
                    break;
                case 5:
                    player.Wins++;
                    player.Ties += 2;
                    player.Losses++;
                    break;
                case 6:
                    player.Wins += 2;
                    player.Losses += 2;
                    break;
                case 7:
                    player.Wins += 2;
                    player.Ties++;
                    player.Losses++;
                    break;
                case 8:
                    player.Wins += 2;
                    player.Ties += 2;
                    break;
                case 9:
                    player.Wins += 3;
                    player.Losses++;
                    break;
                case 10:
                    player.Wins += 3;
                    player.Ties++;
                    break;
                case 12:
                    player.Wins += 4;
                    break;
                default:
                    break;
            }

            return player;
        }
    }
}
