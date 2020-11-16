using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.AplicationServices.Interfaces;
using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastructure.Data.BindingModels;

namespace PetShop.RestAPI.Controllers
{
    [Route("/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public TokenController(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginBindingModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == model.UserName);


            //  if username is in database
            if (user == null)
                return Unauthorized();

            //  if password is correct
            if (!_authenticationService.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication Done
            return Ok(new
            {
                username = user.Username,
                token = _authenticationService.GenerateToken(user)
            });
        }

    }
}

