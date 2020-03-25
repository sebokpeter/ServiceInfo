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

        /// <summary>Returns an IActionResult containing the ServiceInfo object with the given id from the database.</summary>
        /// <param name="id">The id of the service.</param>
        /// <returns>
        ///     If id exists in the database: IActionResult containing the ServiceInfo object.
        ///     If id does not exist: BadRequest saying "No object exists for id:" + id.
        ///     Any other exception: BedRequest with the exception message.
        /// </returns>
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
                return BadRequest("Error occured: " + e.Message);
            }
        }
        
        /// <summary>Returns a collection of all services.</summary>
        /// <returns>IEnumerable containing all services.</returns>
        [HttpGet]
        public IEnumerable<ServiceInfo> Get()
        {
            var serviceInfos = repository.GetAll();
            return serviceInfos;
        }

        /// <summary>Creates new Service and stores it in the database.</summary>
        /// <param name="serviceInfo">A ServiceInfo object containing the data of the service.</param>
        /// <returns>
        ///     If it succeeds: OkRequest saying "New ServiceInfo is inserted to database with id: {serviceID}.".
        ///     Else: BadRequest stating the cause of the fail.
        /// </returns>
        [HttpPost]
        public IActionResult Post([FromBody] ServiceInfo serviceInfo)
        {
            try
            {
                if (serviceInfo == null)
                {
                    return BadRequest("serviceInfo cannot be null.");
                }

                var newServiceInfo = repository.Add(serviceInfo);

                return Ok($"New Service has been inserted successfuly to database with id: {newServiceInfo.Id}.");

            }
            catch (Exception e)
            {
                return BadRequest("Error occured: " + e.Message);
            }
        }

        /// <summary>Updates the data of an existing Service.</summary>
        /// <param name="serviceInfo">A ServiceInfo object containing the updated data of the service.</param>
        /// <returns>
        ///     If it succeeds: OkRequest saying "Service with id: {serviceID} is successfully modified.".
        ///     Else: BadRequest stating the cause of the fail.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ServiceInfo serviceInfo)
        {
            try
            {
                if (serviceInfo == null)
                {
                    return BadRequest("serviceInfo cannot be null.");
                }

                repository.Edit(serviceInfo);
                return Ok($"Service with id: {serviceInfo.Id} is successfully modified.");

            }
            catch (Exception e)
            {
                return BadRequest("Error occured: " + e.Message);
            }
        }

        /// <summary>Deletes the Service, with the provided id, from the database.</summary>
        /// <param name="id">The id of the Service.</param>
        /// <returns>
        ///     If it succeeds: OkRequest saying "Service with id: {id} has been removed from the database.".
        ///     Else: BadRequest stating the cause of the fail.
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (repository.Get(id) == null)
                {
                    return BadRequest($"Service with id: {id} does not exist.");
                }
                repository.Remove(id);
                return Ok($"Service with id: {id} has been removed from the database.");
            }
            catch (Exception e)
            {
                return BadRequest("Error occured: " + e.Message);
            }
        }
    }
}
