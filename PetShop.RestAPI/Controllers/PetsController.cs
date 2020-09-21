using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;

namespace PetShop.RestAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            try
            {
                var result = _petService.GetAll();
                return Ok(result);
            }
            catch (Exception )
            {
                return StatusCode(500, "Process failed!!??:(");

            }

        }
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            try
            {
                if (id < 1)
                    throw new Exception("Id is not acceptable");
                var result = _petService.GetById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");

            }

        } 
        [HttpGet("{petName}")]
        public ActionResult<Pet> Get(string petName)
        {
            try
            {
                var result = _petService.FilterByName(petName);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");

            }

        }
        [HttpPost]
        public ActionResult Post([FromBody] Pet pet)
        {
            try
            {


                var createResult = _petService.Create(pet);
                if (createResult.Id > 0)
                    return StatusCode(201, createResult);
                return StatusCode(500, "Ops Action failed");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                if (id < 0 || id != pet.Id)
                {
                    return NotFound("ID Error! Please check id");

                }
                var result = _petService.Update(pet);
                if (result)
                    return Accepted(pet);
                return StatusCode(500, $"Ops failed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");

            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                var result = _petService.Delete(id);
                if (result)
                    return Accepted("Successfully Deleted");
                return StatusCode(500, $"Opssss failed");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");
            }
        }
    }
}
