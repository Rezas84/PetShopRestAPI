using Microsoft.EntityFrameworkCore;
using PetShop.Infrastracture.Entity;
using PetShop.Infrastracture.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PetShop.Infrastructure.Data
{
    public class PetShopAppContext : DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {
        }
        public DbSet<Pet> pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
