using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Infrastracture.Entity
{
    public class Owner: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Are you ok")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Are you ok")]
        public string LastName { get; set; }
        [MaxLength(200, ErrorMessage = "Are you ok")]
        public string Address { get; set; }
        [MaxLength(15, ErrorMessage = "Are you ok")]
        public string PhoneNumber { get; set; }
        [MaxLength(100, ErrorMessage = "Are you ok")]
        public string Email { get; set; }
        public virtual List<Pet> Pets { get; set; }

    }
}
