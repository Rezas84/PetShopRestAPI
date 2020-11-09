using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using PetShopRestAPI.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet Create(Pet pet)
        {
            var petCreate =_ctx.pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return petCreate;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public FilterList<Pet> Filter(Filter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> FilterByName(string petName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetAll()
        {
            return _ctx.pets;
        }

        public Pet GetById(int Id)
        {
            return _ctx.pets
                ?.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Pet> GetByType(int petTypeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetFiveCheapestPet()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public bool Update(Pet model)
        {
            throw new NotImplementedException();
        }
    }
}
