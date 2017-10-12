using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.DAL
{
    public interface IUnitOfWork
    {
        GenericRepository<Models.Type> TypeRepository { get; set; }
        GenericRepository<Equipment> EquipmentRepository { get; set; }
        GenericRepository<Ninja> NinjaRepository { get; set; }

        void Save();
    }
}
