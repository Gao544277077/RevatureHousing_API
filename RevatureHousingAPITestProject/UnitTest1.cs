using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevHousingAPI.Controllers;
using RevHousingAPI.Repositories;
using RHEntities;
using System.Collections.Generic;

namespace RevatureHousingAPITestProject
{
    
    [TestClass]
    public class RoomsControllerTest
    {
        public RoomsControllerTest()
        {
            testRoom = new RoomRepository();
            roomTest = new RoomsController(testRoom);

        }
        public RoomRepository testRoom;
        public RoomsController roomTest;

        [TestMethod]
        public void NonExistantRoomTest()
        {
            var roomExists = roomTest.roomExists(1728728);
            //var testvalue = 1;

            //EmptyResult empty = new EmptyResult();
            Assert.AreEqual(false, roomExists);
        }
        [TestMethod]
        public void GetReturnsNotFound()
        {
            var getrooms = roomTest.GetRoom(8191);

            Assert.IsNotInstanceOfType(getrooms, typeof(NotFoundResult));
            //Assert.AreNotEqual(getrooms, typeof(ActionResult<IEnumerable<Room>>));
        }
        [TestMethod]
        public void GetNonExistantRoomsTest()
        {
            Room nullroom = new Room() { RoomID = 12728 };

            var getrooms = roomTest.GetRooms();

            Assert.AreNotEqual(getrooms, typeof(ActionResult<IEnumerable<Room>>));
        }
        [TestMethod]
        public void UpdateNonExistantRoomTest()
        {
            Room nullroom = new Room() { RoomID = 12728 };

            ActionResult roomUpdated = roomTest.UpdateRoom(1728728, nullroom);

            Assert.AreEqual(roomUpdated, typeof(BadRequestResult));
        }
    }
}
