using Microsoft.AspNetCore.Mvc;
using PetShop.Core.DomainServices.Interfaces;
using PetShop.Core.DomainServices.Services;
using PetShop.Infrastracture.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController: ControllerBase
    {
        private readonly IOwnerservice _ownerService;
        public OwnerController(IOwnerservice ownerService)
        {
            _ownerService = ownerService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                var result = _ownerService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Process failed!!??:(");
            }
             
        }
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                var result = _ownerService.GetById(id);
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
        public ActionResult Post([FromBody] Owner owner)
        {
            try
            {

                var createResult = _ownerService.Create(owner);
                if (createResult)
                {
                    return Ok("Owner Added successfully");
                }
                return BadRequest("Ops Action failed");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            try
            {
                if (id < 0 || id != owner.Id)
                {
                    return NotFound("ID Error! Please check id");

                }
                var result = _ownerService.Update(owner);
                if (result)
                    return Accepted(owner);
                return StatusCode(500, $"Ops failed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Process failed!!??:( Exception Message:{ex.Message}");

            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
                var result = _ownerService.Delete(id);
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
