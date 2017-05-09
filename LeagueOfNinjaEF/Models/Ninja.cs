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
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("ChestID")]
        public virtual Equipment Chest { get; set; }
        public int? EquipmentID { get; set; }
        [ForeignKey("HelmetID")]
        public Equipment Helmet { get; set; }
        public int? HelmetID { get; set; }
        [ForeignKey("LegID")]
        public Equipment Legs { get; set; }
        public int? LegID { get; set; }
        [ForeignKey("GloveID")]
        public Equipment Gloves { get; set; }
        public int? GlovesID { get; set; }
        [ForeignKey("ShoesID")]
        public Equipment Shoes { get; set; }
        public int? ShoesID { get; set; }
    }
}
