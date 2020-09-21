using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.DomainServices.Services
{
    public class PetTypeRepository : IPetTypeRepository
    {
        public PetTypeRepository()
        {

        }
        public void Init()
        {

            Create(new PetType
            {
                Type = "Bird"
            });


            Create(new PetType
            {
                Type = "Fish"
            });
            Create(new PetType
            {
                Type = "Dog"
            }); Create(new PetType
            {
                Type = "Cat"
            });

        }
        public bool Create(PetType model)
        {
            try
            {
                if (DbContext.petTypes == null)
                    DbContext.petTypes = new List<PetType>();
                var Id = 1;
                if (DbContext.petTypes.Count() > 0)
                {
                    Id = Convert.ToInt32(DbContext.Owners.Max(x => x.Id) + 1);
                }
                model.Id = Id;
                DbContext.petTypes.Add(model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(PetType model)
        {
            try
            {
                if (DbContext.petTypes == null)
                    return false;

                var oldEntity = DbContext.petTypes.FirstOrDefault(x => x.Id == model.Id);
                if (oldEntity == null)
                    return false;
                oldEntity.Type = model.Type;
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
                if (DbContext.petTypes == null)
                    return false;

                var oldEntity = DbContext.petTypes.FirstOrDefault(x => x.Id == Id);
                if (oldEntity == null)
                    return false;
                DbContext.petTypes.Remove(oldEntity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public PetType GetById(int Id)
        {
            var model = DbContext.petTypes?.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                throw new System.Exception("Item Not Exists!");
            return model;
        }

        public IEnumerable<PetType> GetAll()
        {
            return DbContext.petTypes;
        }

    }
}

