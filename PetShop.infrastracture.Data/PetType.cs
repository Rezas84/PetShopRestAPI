using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetShop.Infrastracture.Entity
{
    public class PetType : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Are you ok")]
        public string Type { get; set; }
        public virtual List<Pet> Pets { get; set; }

    }
}
