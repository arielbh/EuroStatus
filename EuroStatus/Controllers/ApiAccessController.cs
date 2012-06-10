using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace EuroStatus.Controllers
{
    public class ApiAccessController : ApiController
    {
        private readonly PlayerRepsitory _repsitory;

        public ApiAccessController()
        {
            _repsitory = new PlayerRepsitory();
        }

        // GET /api/apiaccess
        public IEnumerable<Player> Get()
        {
           return  _repsitory.GetPlayers();
        }

        // GET /api/apiaccess/5
        public Player Get(int id)
        {
            return _repsitory.GetPlayers().ToArray()[id];
        }

     
    }

    public class PlayerRepsitory
    {
        private IEnumerable<Player> _players;

        public IEnumerable<Player> GetPlayers()
        {
            return _players ?? (_players = new List<Player>()
                                               {
                                                   new Player
                                                       {
                                                           Name = "Ariel",
                                                           Score = 11,
                                                           Games = new Game[]
                                                                       {
                                                                           new Game
                                                                               {
                                                                                   Order = 1,
                                                                                   TeamA = "Greece",
                                                                                   TeamB = "Poland",
                                                                                   TeamAScore = 1,
                                                                                   TeamBScore = 1,
                                                                                   IsValid = true,


                                                                               },
                                                                           new Game
                                                                               {
                                                                                   Order = 2,
                                                                                   TeamA = "Russia",
                                                                                   TeamB = "Czech",
                                                                                   TeamAScore = 4,
                                                                                   TeamBScore = 1,
                                                                                   IsValid = true,


                                                                               },
                                                                       }

                                                       },
                                                   new Player
                                                       {
                                                           Name = "Eyal",
                                                           Score = 21,
                                                           Games = new Game[]
                                                                       {
                                                                           new Game
                                                                               {
                                                                                   Order = 1,
                                                                                   TeamA = "Greece",
                                                                                   TeamB = "Poland",
                                                                                   TeamAScore = 0,
                                                                                   TeamBScore = 1,
                                                                                   IsValid = true,


                                                                               },
                                                                           new Game
                                                                               {
                                                                                   Order = 2,
                                                                                   TeamA = "Russia",
                                                                                   TeamB = "Czech",
                                                                                   TeamAScore = 4,
                                                                                   TeamBScore = 5,
                                                                                   IsValid = true,
                                                                               },
                                                                       }

                                                       }
                                               });
        }
    }

    public class Game
    {
        public int Order { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public bool IsOvertime { get; set; }
        public bool IsPenalties { get; set; }
        public int TeamAPenalties { get; set; }
        public int TeamBPenalties { get; set; }
        public bool IsValid { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Game[] Games { get; set; }

    }
}
