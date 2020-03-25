using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceInfo.DataAccess;

namespace ServiceInfo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceInfoController : ControllerBase
    {
        private readonly IRepository<ServiceInfo> repository;

        public ServiceInfoController(IRepository<ServiceInfo> repos)
        {
            repository = repos;
        }

        // GET: api/ServiceInfo/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var serviceInfo = repository.Get(id);

                if (serviceInfo.Id == id)
                {
                    return BadRequest("No object exists for id: " + id);
                }

                return Ok(serviceInfo);
            }
            catch (Exception e)
            {
                return BadRequest("error occured: " + e);
            }
        }
        // GET: api/ServiceInfo
        [HttpGet]
        public IEnumerable<ServiceInfo> GetAll()
        {
            var serviceInfos = repository.GetAll();
            return serviceInfos;
        }

        // POST: api/ServiceInfo
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
                return BadRequest("error occured: " + e);
            }
        }

        // PUT: api/ServiceInfo/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ServiceInfo serviceInfo)
        {
            try
            {
                if (serviceInfo == null)
                {
                    return BadRequest("ServiceInfo is null");
                }

                var modifiedServiceInfo = repository.Get(serviceInfo.Id);
                if (modifiedServiceInfo == null)
                {
                    return BadRequest(" The modified ServiceInfo is null");
                }

                modifiedServiceInfo = serviceInfo;

                repository.Edit(modifiedServiceInfo);
                return Ok($"ServiceInfo  with id: {modifiedServiceInfo.Id} is successfully modified");

            }
            catch (Exception e)
            {
                return BadRequest("error occured: " + e);
            }
        }

        // DELETE: api/ApiWithActions/5
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
                return BadRequest("error occured: " + e);
            }
        }
    }
}
