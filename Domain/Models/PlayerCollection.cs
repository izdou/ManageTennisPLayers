using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Models
{
    /// <summary>
    /// Object contain list of player to map jsonresult 
    /// </summary>
    public class PlayerCollection
    {
        public PlayerCollection()
        { }
        /// <summary>
        /// List of players
        /// </summary>
		public IEnumerable<Player> Players { get; set; }
    }
}