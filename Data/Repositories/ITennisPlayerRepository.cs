using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ITennisPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Player GetById(int id);
        void Delete(Player player);
    }
}
