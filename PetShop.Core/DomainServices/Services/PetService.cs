using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using PetShopRestAPI.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.DomainServices.Services
{
    public class PetService: IPetService
    {
        private readonly IPetValidatorService petValidationService;
        private readonly IPetRepository petRepository;
        
        public PetService(IPetValidatorService petValidationService,
            IPetRepository petRepository
            )
        {
            this.petValidationService = petValidationService;
            this.petRepository = petRepository;
            

        }

        public Pet Create(Pet model)
        {

            if (petValidationService.PetValidation(model))
                return petRepository.Create(model);
            model.Id = -2;
            return model;
        }
        public bool Update(Pet model)
        {
            if (petValidationService.PetValidation(model))
                return petRepository.Update(model);
            return false;
        }
        public bool Delete(int Id)
        {
            return petRepository.Delete(Id);
        }
        public Pet GetById(int Id)
        {
         return petRepository.GetById(Id);
        }
        public IEnumerable<Pet> GetByType(int petTypeId)
        {
            return petRepository.GetByType(petTypeId);
        }
        public IEnumerable<Pet> GetAll()
        {
            return petRepository.GetAll();
        }
        public IEnumerable<Pet> GetFiveCheapestPet()
        {
            return petRepository.GetFiveCheapestPet();
        }
        public IEnumerable<Pet> SortAllPetsByPrice()
        {
            return petRepository.GetAll()?.OrderBy(x=>x.price);
        }

        public IEnumerable<Pet> FilterByName(string petName)
        {
            return petRepository.FilterByName(petName);
        }

        public FilterList<Pet> Filter(Filter filter)
        {
            return petRepository.Filter(filter);
        }
    }
}
