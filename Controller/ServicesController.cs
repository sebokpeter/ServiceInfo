using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiceInfo.DataAccess;

namespace ServiceInfo.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IRepository<ServiceInfo> repository;

        public ServicesController(IRepository<ServiceInfo> repos)
        {
            repository = repos;
        }

        // GET: Services/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var serviceInfo = repository.Get(id);

                if (serviceInfo.Id != id)
                {
                    return BadRequest("No object exists for id: " + id);
                }

                return Ok(serviceInfo);
            }
            catch (Exception e)
            {
                return BadRequest("error occured: " + e.Message);
            }
        }
        // GET: Services
        [HttpGet]
        public IEnumerable<ServiceInfo> GetAll()
        {
            var serviceInfos = repository.GetAll();
            return serviceInfos;
        }

        // POST: Services
        [HttpPost]
        public IActionResult Post([FromBody] ServiceInfo serviceInfo)
        {
            try
            {
                if (serviceInfo == null)
                {
                    return BadRequest("ServiceInfo is null");
                }

                var newServiceInfo = repository.Add(serviceInfo);

                return Ok($"New ServiceInfo is inserted to database with id: {newServiceInfo.Id} ");

            }
            catch (Exception e)
            {
                return BadRequest("error occured: " + e.Message);
            }
        }

        // PUT: Services
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ServiceInfo serviceInfo)
        {
            try
            {
                if (serviceInfo == null)
                {
                    return BadRequest("ServiceInfo is null");
                }

                repository.Edit(serviceInfo);
                return Ok($"ServiceInfo  with id: {serviceInfo.Id} is successfully modified");

            }
            catch (Exception e)
            {
                return BadRequest("error occured: " + e.Message);
            }
        }

        // DELETE: Services/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (repository.Get(id) == null)
                {
                    return BadRequest($"no ServiceInfo with this id: {id}");
                }
                repository.Remove(id);
                return Ok($"ServiceInfo with id {id} is removed from the database");
            }
            catch (Exception e)
            {
                return BadRequest("error occured: " + e.Message);
            }
        }
    }
}
