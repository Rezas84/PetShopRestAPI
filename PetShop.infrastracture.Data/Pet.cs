using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastracture.Entity
{
    public class Pet: BaseEntity
    {
        

        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? SoldDate { get; set; }
        public string Color { get; set; }
        public int OwnerId { get; set; }
        public int petTypeId { get; set; }
        public int? PreviousOwnerId { get; set; }
        public double price { get; set; }

    }
}
