using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueOfNinjaEF.Models
{
    public class Ninja
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NinjaId { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }

        //Foreign key for Chest Equipment
        public int? ChestRefId { get; set; }
        [ForeignKey("ChestRefId")]
        public virtual Equipment Chest { get; set; }

        //Foreign key for Helmet Equipment
        public int? HelmetRefId { get; set; }
        [ForeignKey("HelmetRefId")]
        public virtual Equipment Helmet { get; set; }

        //Foreign key for Leg Equipment
        public int? LegRefId { get; set; }
        [ForeignKey("LegRefId")]
        public virtual Equipment Legs { get; set; }

        //Foreign key for Gloves Equipment
        public int? GlovesRefId { get; set; }
        [ForeignKey("GlovesRefId")]
        public virtual Equipment Gloves { get; set; }

        //Foreign key for Shoes Equipment
        public int? ShoesRefId { get; set; }
        [ForeignKey("ShoesRefId")]
        public virtual Equipment Shoes { get; set; }
    }
}
