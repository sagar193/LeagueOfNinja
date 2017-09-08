using LeagueOfNinjaEF.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //LoNInitializer.Initialize(context);


            //Database.SetInitializer(new CreateDatabaseIfNotExists<LoNContext>());
            //LoNContext context = new LoNContext();
            //context.Database.Initialize(true);
        }
    }
}
