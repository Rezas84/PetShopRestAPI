using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using PetShop.Infrastracture.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopAppContext _ctx;
        public UserRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(User entity)
        {
            _ctx.Users.Add(entity);
            _ctx.SaveChanges();

        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            return _ctx.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _ctx.Users;
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }
    }
    }
