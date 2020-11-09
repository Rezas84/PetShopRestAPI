using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetShop.Infrastracture.Entity
{
    public class Pet : BaseEntity
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="Are you ok")]
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? SoldDate { get; set; }
        [MaxLength(15, ErrorMessage = "Are you ok")]
        public string Color { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        [ForeignKey("PetType")]
        public int petTypeId { get; set; }
        public int? PreviousOwnerId { get; set; }
        public double price { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual PetType PetType { get; set; }


    }
}
