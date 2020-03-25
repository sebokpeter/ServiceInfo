using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceInfo.DataAccess
{
    public class ServiceInfoRepository : IRepository<ServiceInfo>
    {

        private readonly ServiceInfoDBContext dBContext;

        public ServiceInfoRepository(ServiceInfoDBContext context)
        {
            this.dBContext = context;
        }

        /// <summary>
        /// Add a ServiceInfo entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>The entity added to the database.</returns>
        public ServiceInfo Add(ServiceInfo entity)
        {
            ServiceInfo info = dBContext.ServiceInfos.Add(entity).Entity;
            dBContext.SaveChanges();

            return info;
        }

        /// <summary>
        /// Change an existing ServiceInfo entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be changed.</param>
        /// <returns>The changed entity.</returns>
        public ServiceInfo Edit(ServiceInfo entity)
        {
            dBContext.Entry(entity).State = EntityState.Modified;
            dBContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Retrieve a ServiceInfo entity based on its ID.
        /// </summary>
        /// <param name="id">The ID of the requested ServiceInfo entity.</param>
        /// <returns>The ServiceInfo entity with the given ID, if exists, null otherwise.</returns>
        public ServiceInfo Get(int id)
        {
            ServiceInfo info = dBContext.ServiceInfos.FirstOrDefault(s => s.Id == id);

            return info;
        }

        /// <summary>
        /// Retrieve all ServiceInfo entities stored in the database.
        /// </summary>
        /// <returns>An IEnumerable<ServiceInfo> containing all ServiceInfo entities in the database.</returns>
        public IEnumerable<ServiceInfo> GetAll()
        {
            return dBContext.ServiceInfos.ToList();
        }

        /// <summary>
        /// Remove the ServiceInfo entity with the given ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity being deleted.</param>
        public void Remove(int id)
        {
            ServiceInfo info = dBContext.ServiceInfos.FirstOrDefault(s => s.Id == id);

            if (info == null)
            {
                throw new ArgumentException($"No ServiceInfo entity with the id of {id} can be found!");
            }

            dBContext.ServiceInfos.Remove(info);
            dBContext.SaveChanges();
        }
    }
}
