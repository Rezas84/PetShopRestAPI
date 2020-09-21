using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PetShop.Core.DomainServices.Services
{
    public class OwnerRepository : IOwnerRepository
    {
        public OwnerRepository()
        {

        }
        public void Init()
        {
            Create(new Owner
            {
                FirstName = "Reza",
                LastName = "Sarf",
                Address = "Tinhghojvej 44 2600 Søborg",
                PhoneNumber = "2298765435",
                Email = "s@s.com"
            });
            Create(new Owner
            {
                FirstName = "Pia",
                LastName = "King",
                Address = "Orsegade 44 2600 Søborg",
                PhoneNumber = "88963457",
                Email = "f@f.com"
            });
            Create(new Owner
            {
                FirstName = "Sara",
                LastName = "Finn",
                Address = "Storgade 44 2600 Søborg",
                PhoneNumber = "33877866",
                Email = "t@m.com"
            }); Create(new Owner
            {
                FirstName = "Alex",
                LastName = "Bia",
                Address = "lkagade89 44 2600 Søborg",
                PhoneNumber = "98976743",
                Email = "r@m.com"

            });

        }
        public bool Create(Owner model)
        {
            try
            {
                if (DbContext.Owners == null)
                    DbContext.Owners = new List<Owner>();
                var Id = 1;
                if (DbContext.Owners.Count() > 0)
                {
                    Id = Convert.ToInt32(DbContext.Owners.Max(x => x.Id) + 1);
                }
                model.Id = Id;
                DbContext.Owners.Add(model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Owner model)
        {
            try
            {
                if (DbContext.Owners == null)
                    return false;

                var oldEntity = DbContext.Owners.FirstOrDefault(x => x.Id == model.Id);
                if (oldEntity == null)
                    return false;
                oldEntity.FirstName = model.FirstName;
                oldEntity.LastName = model.LastName;
                oldEntity.Address = model.Address;
                oldEntity.PhoneNumber = model.PhoneNumber;
                oldEntity.Email = model.Email;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                if (DbContext.Owners == null)
                    return false;

                var oldEntity = DbContext.Owners.FirstOrDefault(x => x.Id == Id);
                if (oldEntity == null)
                    return false;
                DbContext.Owners.Remove(oldEntity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Owner GetById(int Id)
        {
            var model = DbContext.Owners?.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                throw new System.Exception("Item Not Exists!");
            return model;
        }

        public IEnumerable<Owner> GetAll()
        {
            return DbContext.Owners
                ;

        }
    }
}
