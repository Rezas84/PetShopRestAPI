using PetShop.Infrastracture.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.AplicationServices.Interfaces
{
   public interface IAuthenticationService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        string GenerateToken(User user);
    }
}
