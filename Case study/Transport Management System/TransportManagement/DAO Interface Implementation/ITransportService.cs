using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport_Management_System.Entities;

namespace Transport_Management_System.DAO_Interface_Implementaion
{
    public interface ITransportService
    {

        // To register a passenger 
        int RegisterPassenger(Passengers passenger);

        // To get all availabe scheduled tips..
        List<Trips> GetAvailableTrips();

        // Operations For Vehicles..
        bool AddVehicle(Vehicles vehicle);
        bool UpdateVehicle(Vehicles vehicle);
        bool DeleteVehicle(int vehicleId);

        // Operations For Trip...
        bool ScheduleTrip(int vehicleId, int routeId, string departureDate, string arrivalDate);
        bool CancelTrip(int tripId);

        // Operations For Booking..
        bool BookTrip(int tripId, int passengerId, string bookingDate);
        bool CancelBooking(int bookingId);

        // Operations For Driver allocation...
        bool AllocateDriver(int tripId, int driverId);
        bool DeallocateDriver(int tripId);

        // Retrievals
        List<Bookings> GetBookingsByPassenger(int passengerId);
        List<Bookings> GetBookingsByTrip(int tripId);
        List<Drivers> GetAvailableDrivers();

    }
}
