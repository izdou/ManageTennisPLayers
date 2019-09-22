using Commun.Helpers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TennisPlayersRepository: ITennisPlayerRepository
    {

        public List<Player> Players { get; set; }

        private static List<Player> loadTennisPlayesFromUrl()
        {
            return JsonReaderHelper<PlayerCollection>.GetSerializedJsonFromUrl().Players.ToList<Player>();
        }

        public TennisPlayersRepository()
        {
            Players = loadTennisPlayesFromUrl();
        }
        /// <summary>
        /// Get all players
        /// </summary>
        /// <returns>Players</returns>
        public IEnumerable<Player> GetAll()
        {
            return Players.OrderBy(pl => pl.Id);
        }
        /// <summary>
        /// GEt player by id
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Player</returns>
        public Player GetById(int id)
        {
            return Players.FirstOrDefault(pl => pl.Id == id);
        }
        /// <summary>
        /// Delete player from list of player
        /// </summary>
        /// <param name="player">Player to delete</param>
        public void Delete(Player player)
        {
            Players.Remove(player);
        }
    }
}
