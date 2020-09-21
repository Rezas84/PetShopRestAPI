using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Services
{
    public class OwnerService : IOwnerservice
    {
        private readonly IOwnerValidatorService _ownerValidationService;
        private readonly IOwnerRepository _ownerRepository;
        public OwnerService (IOwnerValidatorService ownerValidationService, IOwnerRepository ownerRepository)
        {
            _ownerValidationService = ownerValidationService;
            _ownerRepository = ownerRepository;

        }
        public bool Create(Owner model)
        {
            if (_ownerValidationService.Ownervalidator(model))
                return _ownerRepository.Create(model);
            return false;
        }

        public bool Delete(int Id)
        {
            return _ownerRepository.Delete(Id);
        }

        public IEnumerable<Owner> GetAll()
        {
            return _ownerRepository.GetAll();
        }

        public Owner GetById(int Id)
        {
            return _ownerRepository.GetById(Id
                );

        }

        public bool Update(Owner model)
        {
            if (_ownerValidationService.Ownervalidator(model))
                return _ownerRepository.Update(model);
            return false;
        }
    }
}
