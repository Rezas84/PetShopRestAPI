using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Services
{
    public class PetValidatorService : BaseValidatorService, IPetValidatorService
    {
        private readonly IPetTypeRepository _petTypeRepository;
        private readonly IOwnerRepository _ownerRepository;
        public PetValidatorService(IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
            _ownerRepository = ownerRepository;
        }
        public bool PetValidation(Pet pet)
        {
            if (pet == null
                 || string.IsNullOrWhiteSpace(pet.Name)
                 || string.IsNullOrWhiteSpace(pet.Color))
                return false;
            var owner = _ownerRepository.GetById(pet.OwnerId);
            if (owner == null)
                throw new Exception("OwnerId failed");
            if (!(pet.PreviousOwnerId is null))
            {
                var previousOwner = _ownerRepository.GetById((int)pet.PreviousOwnerId);
                if (previousOwner is null)
                    throw new Exception("PreviousOwner not Exist");
            }
            var petType = _petTypeRepository.GetById(pet.petTypeId);
            if (petType == null)
                throw new Exception("PettypeId failed");


            return true;

        }


    }
}
