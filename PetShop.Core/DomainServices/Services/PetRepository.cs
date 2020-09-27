using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using PetShopRestAPI.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Core.DomainServices.Services
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {

        }
        public void Init()
        {

            Create(new Pet
            {
                Color = "Black",
                Name = "SomeName",
                OwnerId = 1,
                Birthdate = DateTime.Now.AddMonths(-12),
                price = 1200,
                petTypeId = 1,

            });
            Create(new Pet
            {
                Color = "Gray",
                Name = "Alex",
                OwnerId = 2,
                Birthdate = DateTime.Now.AddMonths(-24),
                price = 1000,
                petTypeId = 3,

            }); Create(new Pet
            {
                Color = "Brown",
                Name = "Lexi",
                OwnerId = 3,
                Birthdate = DateTime.Now.AddMonths(-44),
                price = 8000,
                petTypeId = 2,
            });

        }
        public Pet Create(Pet model)
        {
            try
            {
                if (DbContext.Pets == null)
                    DbContext.Pets = new List<Pet>();
                var Id = 1;
                if (DbContext.Pets.Count() > 0)
                {
                    Id = Convert.ToInt32(DbContext.Pets.Max(x => x.Id) + 1);
                }
                model.Id = Id;
                DbContext.Pets.Add(model);
                return model;
            }
            catch (Exception)
            {
                model.Id = -1;
                return model;
            }
        }
        public bool Update(Pet model)
        {
            try
            {
                if (DbContext.Pets == null)
                    return false;

                var oldEntity = DbContext.Pets.FirstOrDefault(x => x.Id == model.Id);
                if (oldEntity == null)
                    return false;
                if (oldEntity.OwnerId != model.OwnerId)
                    oldEntity.PreviousOwnerId = oldEntity.OwnerId;

                oldEntity.Birthdate = model.Birthdate;
                oldEntity.Color = model.Color;
                oldEntity.Name = model.Name;
                oldEntity.OwnerId = model.OwnerId;
                oldEntity.price = model.price;
                oldEntity.SoldDate = model.SoldDate;
                oldEntity.petTypeId = model.petTypeId;
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
                if (DbContext.Pets == null)
                    return false;

                var oldEntity = DbContext.Pets.FirstOrDefault(x => x.Id == Id);
                if (oldEntity == null)
                    return false;
                DbContext.Pets.Remove(oldEntity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Pet GetById(int Id)
        {
            var model = DbContext.Pets?.FirstOrDefault(x => x.Id == Id);

            return model;
        }
        public IEnumerable<Pet> GetByType(int petTypeId)
        {
            var list = DbContext.Pets?.Where(x => x.petTypeId == petTypeId);
            if (list == null)
                throw new System.Exception("Item Not Exists!");
            return list;
        }
        public IEnumerable<Pet> GetAll()
        {
            return DbContext.Pets;
        }
        public IEnumerable<Pet> GetFiveCheapestPet()
        {
            return DbContext.Pets?.Where(x => x.SoldDate == null).OrderBy(x => x.price).Take(5);
        }
        public IEnumerable<Pet>FilterByName(string petName)
        {
            return DbContext.Pets?.Where(x => x.Name.ToLower().Contains(petName.ToLower()));
        }
        public FilterList<Pet> Filter(Filter filter)
        {
            var list = DbContext.Pets;
            switch (filter.SearchField)
            {
                case"id":
                    int.TryParse(filter.Search, out int id);
                    list = list.Where(x => x.Id == id).ToList();
                    break;
                default:
                    break;
            }
            var filterList = new FilterList<Pet>
            {
                filter = filter,
                List = list,
                TotalCount = list.Count
            };
            return filterList;
        }
    }
}