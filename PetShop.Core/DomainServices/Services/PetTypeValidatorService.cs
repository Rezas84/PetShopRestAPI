using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Services
{
    public class PetTypeValidatorService : BaseValidatorService, IPetTypeValidatorService
    {
        public bool petTypeValidation(PetType petType)
        {
            if (petType == null
                 || string.IsNullOrWhiteSpace(petType.Type))
                 return false;
            return true;
        }
    }
}
