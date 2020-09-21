using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Interfaces
{
   public interface IOwnerValidatorService: IBaseValidatorService
    {
        bool Ownervalidator(Owner owner);
    }
}
