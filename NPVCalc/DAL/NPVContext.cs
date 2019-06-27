using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using NPVCalc.Models;

namespace NPVCalc.DAL
{
    public class NPVContext : DbContext
    {

        public NPVContext() : base("NPVContext")
        {
        }

        public DbSet<NPV> NPV { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }



    }
}