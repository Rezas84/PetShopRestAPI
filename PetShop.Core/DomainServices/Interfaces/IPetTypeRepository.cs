using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainServices.Interfaces
{
   public interface IPetTypeRepository
    {
        void Init();
        bool Create(PetType model);
        bool Update(PetType model);
        bool Delete(int Id);
        PetType GetById(int Id);
        IEnumerable<PetType> GetAll();
    }
}
