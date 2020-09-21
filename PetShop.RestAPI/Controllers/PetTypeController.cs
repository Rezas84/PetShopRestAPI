using Microsoft.AspNetCore.Mvc;
using PetShop.Core.DomainServices.Interfaces;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController: ControllerBase
    {
        private readonly IPetTypeService _petTypeService;
        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get()
        {
            try
            {
                var result=_petTypeService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(500, "Process failed!!??:(");
            }
            
        }
        
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            try
            {
                var result = _petTypeService.GetById(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");

            }

        }

        [HttpPut("{id}")]
        public ActionResult<PetType> Put(int id, [FromBody] PetType petType)
        {
            try
            {
                if (id < 0 || id != petType.Id)
                {
                    return NotFound("ID Error! Please check id");

                }
                var result = _petTypeService.Update(petType);
                if (result)
                    return Accepted(petType);
                return StatusCode(500, $"Ops failed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");

            }
        }
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            try
            {
                var result = _petTypeService.Delete(id);
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
