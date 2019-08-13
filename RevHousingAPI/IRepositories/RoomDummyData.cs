using RHEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevHousingAPI.IRepositories
{
    public class RandomNumbers
    {
        //Generates Random Integer to create unique Random Ids
        //Note: rand.Next() returns a unique id everytime
        public Random rand;
        public RandomNumbers()
        {
            rand = new Random();
        }
        public int GenerateRandomId()
        {

            return rand.Next(9);
        }
    }

    public class RoomDummyData
    {

        //list of Provider
        public List<Room> RoomsList;
        //consturcter
        public RoomDummyData() {
            RoomsList = new List<Room>();
            RandomNumbers r = new RandomNumbers();
            for (int i = 0; i < 9; i++)
            {
                Room room = new Room()
                {
                    RoomID = r.GenerateRandomId(),
                    Type = String_Arr[r.GenerateRandomId()],
                    MaxOccupancy = r.GenerateRandomId(),
                    RoomNumber = r.GenerateRandomId().ToString() + r.GenerateRandomId(),
                    Gender = Gender_Arr[r.GenerateRandomId()  % 3],
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(r.GenerateRandomId()),
                    CurrentOccupancy = r.GenerateRandomId(),
                    IsActive = Bool_Arr[r.GenerateRandomId() % 2],
                    Description = String_Arr[r.GenerateRandomId()],
                    Location = null,
                    LocationID = r.GenerateRandomId()

                };
                RoomsList.Add(room);

            }



        }

        string[] String_Arr = new string[] { "A", "B", "C", "D","E","F", "G","H", "I" };
        bool[] Bool_Arr = new bool[] {true,false};
        string[] Gender_Arr = new string[] { "Male", "Female", "Alternative" };


    }
}
