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
        IRepository<Models.Type> TypeRepository { get; set; }
        IRepository<Equipment> EquipmentRepository { get; set; }
        IRepository<Ninja> NinjaRepository { get; set; }

        void Save();
    }
}
