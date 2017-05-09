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
        public int ID { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        [ForeignKey("TypeID")]
        public virtual Type Type { get; set; }
        public int? TypeID { get; set; }
        public int Price { get; set; }
        
    }
}
