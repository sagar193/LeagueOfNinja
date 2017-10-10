using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.DAL
{
    class NinjaRepository : GenericRepository<Ninja>
    {
        public NinjaRepository(LoNContext context) : base(context)
        {
        }
    }
}
