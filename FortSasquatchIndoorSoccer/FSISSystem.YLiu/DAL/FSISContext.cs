using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FSISSystem.Yliu.Data;
using System.Data.Entity;

namespace FSISSystem.YLiu.DAL
{
    internal class FSISContext:DbContext
    {
        public FSISContext() : base("FSIS_db")
        {

        }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
