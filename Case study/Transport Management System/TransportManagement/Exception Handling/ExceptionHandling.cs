using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Management_System.Exception_Handling
{
    public class ExceptionHandling
    {
        // To handle if vehicle is not there in the database..
        public class VehicleNotFoundException : Exception
        {
            public VehicleNotFoundException() : base("Vehicle not found with the specified ID.") { }

            public VehicleNotFoundException(string message) : base(message) { }
        }


        // To handle if no booking is there... with given details..
        public class BookingNotFoundException : Exception
        {
            public BookingNotFoundException() : base("Booking not found with the specified details.") { }

            public BookingNotFoundException(string message) : base(message) { }
        }

        // To handle if Tripscheduling trip fails..
        public class TripSchedulingException : Exception
        {
            public TripSchedulingException(string message = "Failed to schedule trip.") : base(message) { }
        }


        // To handle if Trip booking failed..
        public class TripBookingException : Exception
        {
            public TripBookingException(string message = "Failed to book the trip.") : base(message) { }
        }

        // To handle if respective driver is not there..
        public class DriverNotAvailableException : Exception
        {
            public DriverNotAvailableException(string message = "Driver not available.") : base(message) { }
        }

        // To handle if No driver is currently assigned to given trip..
        public class DriverNotAssignedException : Exception
        {
            public DriverNotAssignedException(string message = "No driver is currently assigned to this trip.") : base(message) { }
        }

        // To handle if Database connection occurs...

        public class DatabaseConnectionException : Exception
        {
            public DatabaseConnectionException(string message = "Unable to connect to the database.") : base(message) { }
        }


    }
}
