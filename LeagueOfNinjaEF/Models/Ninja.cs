using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueOfNinjaEF.Models
{
    class Ninja
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NinjaId { get; set; }
        public string Name { get; set; }

        //Foreign key for Chest Equipment
        [ForeignKey("ChestRefId")]
        public virtual Equipment Chest { get; set; }
        public int? ChestRefId { get; set; }

        //Foreign key for Helmet Equipment
        [ForeignKey("HelmetRefId")]
        public Equipment Helmet { get; set; }
        public int? HelmetRefId { get; set; }

        //Foreign key for Leg Equipment
        [ForeignKey("LegRefId")]
        public Equipment Legs { get; set; }
        public int? LegRefId { get; set; }

        //Foreign key for Gloves Equipment
        [ForeignKey("GlovesRefId")]
        public Equipment Gloves { get; set; }
        public int? GlovesRefId { get; set; }

        //Foreign key for Shoes Equipment
        [ForeignKey("ShoesRefId")]
        public Equipment Shoes { get; set; }
        public int? ShoesRefId { get; set; }
    }
}
