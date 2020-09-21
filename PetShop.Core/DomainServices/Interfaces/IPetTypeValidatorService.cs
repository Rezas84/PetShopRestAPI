using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Interfaces
{
    public interface IPetTypeValidatorService: IBaseValidatorService
    {
        bool petTypeValidation(PetType petType);
    }
}
