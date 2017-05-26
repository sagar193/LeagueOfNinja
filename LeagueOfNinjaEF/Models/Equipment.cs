using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.Models
{
    class Equipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Price { get; set; }

        //Foreign key for Type of Equipment
        public int TypeRefId { get; set; }
        [ForeignKey("TypeRefId")]
        public virtual Type Type { get; set; }

        public virtual ICollection<Ninja> Ninjas { get; set; }


    }
}
