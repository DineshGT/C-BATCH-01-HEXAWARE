using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Management_System.Entities
{
    public class Bookings
    {
        // Fields
        private int Booking_id;
        private int Trip_id;
        private int Passenger_id;
        private DateTime Booking_date;
        private string? Status;

        // Default Constructor
        public Bookings() { }

        // Parameterized Constructor
        public Bookings(int booking_id, int trip_id, int passenger_id, DateTime booking_date, string status)
        {
            Booking_id = booking_id;
            Trip_id = trip_id;
            Passenger_id = passenger_id;
            Booking_date = booking_date;
            Status = status;
        }

        // Getters and Setters
        public int GetBooking_id() => Booking_id;
        public void SetBooking_id(int booking_id) => Booking_id = booking_id;

        public int GetTrip_id() => Trip_id;
        public void SetTrip_id(int trip_id) => Trip_id = trip_id;

        public int GetPassenger_id() => Passenger_id;
        public void SetPassenger_id(int passenger_id) => Passenger_id = passenger_id;

        public DateTime GetBooking_date() => Booking_date;
        public void SetBooking_date(DateTime booking_date) => Booking_date = booking_date;

        public string? GetStatus() => Status;
        public void SetStatus(string status) => Status = status;
    }
}
