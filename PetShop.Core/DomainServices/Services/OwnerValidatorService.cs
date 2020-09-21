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
            if (owner == null
                 || string.IsNullOrWhiteSpace(owner.FirstName)
                 || string.IsNullOrWhiteSpace(owner.LastName))
                return false;
            return true;
        }
    }
}
