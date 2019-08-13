using RHEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace RevHousingAPI.IRepositories
{
    public interface ILocationRepository
    {
        Location Get(int id);

        IEnumerable<Location> GetAll();

        void Add(Location location);
        void Update(Location location);
    }
}