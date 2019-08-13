﻿using RHEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevHousingAPI.IRepositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room Get(int id);

        IEnumerable<Room> GetAll();

        void Add(Room room);
        void Update(Room room);
    }
}