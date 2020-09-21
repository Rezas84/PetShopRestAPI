using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Interfaces
{
   public interface IOwnerRepository
    {
        void Init();
        bool Create(Owner model);
        bool Update(Owner model);
        bool Delete(int Id);
        Owner GetById(int Id);
        IEnumerable<Owner> GetAll();
    }
}
