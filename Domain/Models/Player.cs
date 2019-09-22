using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Player
    {
        public Player() { }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ShortName { get; set; }

        public char Sex { get; set; }

        public Country Country { get; set; }

        public string Picture { get; set; }

        public Data Data { get; set; }
    }
}
