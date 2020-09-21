using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Services
{

    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeValidatorService _petTypeValidationService;
        private readonly IPetTypeRepository _petTypeRepository;
        public PetTypeService(IPetTypeValidatorService petTypeValidationService, IPetTypeRepository petTypeRepository)
        {
            _petTypeValidationService = petTypeValidationService;
            _petTypeRepository = petTypeRepository;
        }
        public bool Create(PetType model)
        {
            if (_petTypeValidationService.petTypeValidation(model))
                return _petTypeRepository.Create(model);
            return false;
        }
        public bool Update(PetType model)
        {
            if (_petTypeValidationService.petTypeValidation(model))
                return _petTypeRepository.Update(model);
            return false;
        }

        public IEnumerable<PetType> GetAll()
        {
            return _petTypeRepository.GetAll();
        }

        public PetType GetById(int Id)
        {
            return _petTypeRepository.GetById(Id);
        }
        public bool Delete(int Id)
        {
            return _petTypeRepository.Delete(Id);
        }


    }
}
