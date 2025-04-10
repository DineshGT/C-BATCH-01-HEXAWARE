using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Transport_Management_System.Exception_Handling.ExceptionHandling;
using Transport_Management_System.DAO_Interface_Implementaion;
using Transport_Management_System.Entities;

namespace TransportManagementTest
{
    public class TransportManagementTest
    {
        [TestFixture]
        public class TransportManagementTests
        {
            private TransportService service;

            // This is the setup included from TransportService 
            [SetUp]
            public void Setup()
            {
                service = new TransportService();
            }



            // This is to Test Vehicles addition...

            [TestCase("TestModelX", 40, "Van", "Available")]
            [TestCase("TestModelY", 55, "Bus", "Maintenance")]
            public void AddVehicle_ShouldReturnTrue(string model, int capacity, string type, string status)
            {
                Vehicles vehicle = new Vehicles(0, model, capacity, type, status);
                bool result = service.AddVehicle(vehicle);
                Assert.IsTrue(result, "Vehicle should be added successfully.");
            }



            // This is the test for whether we can allocate drivers or not...

            [TestCase(1, 1)]
            [TestCase(2, 2)]
            public void AllocateDriver_ShouldReturnTrue(int tripId, int driverId)
            {
                bool result = service.AllocateDriver(tripId, driverId);
                Assert.IsTrue(result, $"Driver {driverId} should be allocated to Trip {tripId}.");
            }



            // This is the test for Booking is correctly work or not...

            [TestCase(1, 1, "2024-04-10")]
            [TestCase(2, 2, "2024-04-11")]
            public void BookTrip_ShouldReturnTrue(int tripId, int passengerId, string bookingDate)
            {
                bool result = service.BookTrip(tripId, passengerId, bookingDate);
                Assert.IsTrue(result, "Booking should be successful.");
            }



            // This is the Test for is vehicles present or not..
            [TestCase(-101)]
            [TestCase(9999)]
            public void DeleteVehicle_InvalidId_ShouldThrowVehicleNotFoundException(int vehicleId)
            {
                var ex = Assert.Throws<VehicleNotFoundException>(() =>
                {
                    service.DeleteVehicle(vehicleId);
                });
                Assert.That(ex.Message, Does.Contain("Vehicle"));
            }



            // This test is for if booking is not found...
            [TestCase(-1)]
            [TestCase(9999)]
            public void GetBookingsByPassenger_InvalidId_ShouldThrowBookingNotFoundException(int passengerId)
            {
                var ex = Assert.Throws<BookingNotFoundException>(() =>
                {
                    service.GetBookingsByPassenger(passengerId);
                });
                Assert.That(ex.Message, Does.Contain("bookings"));
            }

        }
    }
}
