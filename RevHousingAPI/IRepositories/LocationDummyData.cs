using RHEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevHousingAPI.IRepositories
{

    public class LocationDummyData
    {

        //list of Provider
        public List<Location> LocationsList;
        //consturcter
        public LocationDummyData()
        {
            LocationsList = new List<Location>();
            RandomNumbers r = new RandomNumbers();
            for (int i = 0; i < 9; i++)
            {
                Location location = new Location()
                {
                    ProviderID = r.GenerateRandomId(),
                    Address = String_Arr[r.GenerateRandomId()],
                    City = String_Arr[r.GenerateRandomId()],
                    State = String_Arr[r.GenerateRandomId()],
                    ZipCode = String_Arr[r.GenerateRandomId()],
                    TrainingCenter= String_Arr[r.GenerateRandomId()],
                    Provider = null,
                    LocationID = r.GenerateRandomId()

                };
                LocationsList.Add(location);

            }



        }

        string[] String_Arr = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
        bool[] Bool_Arr = new bool[] { true, false };
 


    }
}
