using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Services
{
    public class OwnerValidatorService : BaseValidatorService, IOwnerValidatorService
    {
        public bool Ownervalidator(Owner owner)
        {
            if (owner == null)
                throw new Exception("OwnerValidatorError: Owner is null");

            if (string.IsNullOrWhiteSpace(owner.FirstName))
                throw new Exception("OwnerValidatorError: OwnerFirstName is null");
            if (string.IsNullOrWhiteSpace(owner.LastName))
                throw new Exception("OwnerValidatorError: OwnerLastName is null");
            if (!ValidEmail(owner.Email))
                throw new Exception("OwnerValidatorError: Owneremail is not Valid");
            return true;
        }
    }
}
