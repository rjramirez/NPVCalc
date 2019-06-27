using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            modelBuilder.Entity<NPV>().HasKey(t => t.NPVId); //primary key defination  
            modelBuilder.Entity<NPV>().Property(t => t.NPVId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);  //identity col           
            base.OnModelCreating(modelBuilder);

        }



    }
}