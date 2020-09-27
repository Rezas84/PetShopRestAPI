using PetShop.Infrastracture.Entity;
using PetShopRestAPI.Infrastructure.Filter;
using System.Collections.Generic;

namespace PetShop.Core.DomainServices.Interfaces
{
    public interface IPetRepository
    {
        void Init();
        Pet Create(Pet model);
        bool Update(Pet model);
        bool Delete(int Id);
        Pet GetById(int Id);
        IEnumerable<Pet> GetByType(int petTypeId );
        IEnumerable<Pet> GetAll();
        IEnumerable<Pet> GetFiveCheapestPet();
        IEnumerable<Pet> FilterByName(string petName);
        FilterList<Pet> Filter(Filter filter);
    }
}
