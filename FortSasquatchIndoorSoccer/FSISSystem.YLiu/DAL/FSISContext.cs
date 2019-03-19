﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using FSISSystem.YLiu.Data;

namespace FSISSystem.YLiu.DAL
{
    internal class FSISContext:DbContext
    {
        public FSISContext() : base("FSIS_db")
        {

        }
        public DbSet<Guardian> Guardians { get; set; }
    }
}
