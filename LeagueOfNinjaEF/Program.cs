using LeagueOfNinjaEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF
{
    class Program
    {
        static void Main(string[] args)
        {
            LoNContext context = new LoNContext();
            LoNInitializer.Initialize(context);
        }
    }
}
