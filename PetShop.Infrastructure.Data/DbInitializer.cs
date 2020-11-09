using PetShop.Core.AplicationServices.Interfaces;
using PetShop.Infrastracture.Entity;
using PetShop.Infrastracture.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void DbSeed(PetShopAppContext ctx, IAuthenticationService authenticationService)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var petType = new PetType
            {
                Type = "Khar"
            };
            ctx.PetTypes.Add(petType);
            
            var owner = new Owner
            {
                FirstName = "Reza",
                Email = "a@a.com",
            };
            ctx.Owners.Add(owner);
            ctx.SaveChanges();
            var pet1 = ctx.pets.Add(new Pet()
            {
                Color = "Black",
                Name = "SomeName",
                OwnerId = owner.Id,
                Birthdate = DateTime.Now.AddMonths(-12),
                price = 1200,
                petTypeId = petType.Id,
            }).Entity;
            ctx.pets.Add(new Pet()
            {
                Color = "Black",
                Name = "SomeName",
                OwnerId = owner.Id,
                Birthdate = DateTime.Now.AddMonths(-12),
                price = 1200,
                petTypeId = petType.Id,
            });
            ctx.SaveChanges();

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationService.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationService.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);
            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.Users.AddRange(users);
            ctx.SaveChanges();
        }
    }
}

