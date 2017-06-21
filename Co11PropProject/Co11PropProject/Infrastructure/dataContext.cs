using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Co11PropProject.Models;

namespace Co11PropProject.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext() : base("PropManDB")
        {

        }

        public System.Data.Entity.DbSet<Co11PropProject.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Co11PropProject.Models.Property> Properties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<User>()
                .HasMany(u => u.Properties)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);

        }

    }
}