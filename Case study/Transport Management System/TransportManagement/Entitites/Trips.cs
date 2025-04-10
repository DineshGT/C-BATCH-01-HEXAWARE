using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_Management_System.Entities
{
    public class Trips
    {
        // Fields
        private int Trip_id;
        private int Vehicle_id;
        private int Route_id;
        private DateTime DepartureDate;
        private DateTime ArrivalDate;
        private string? Status;
        private string? TripType;
        private int MaxPassengers;

        // Default Constructor
        public Trips() { }

        // Parameterized Constructor
        public Trips(int trip_id, int vehicle_id, int route_id, DateTime departureDate,
                     DateTime arrivalDate, string status, string tripType, int maxPassengers)
        {
            Trip_id = trip_id;
            Vehicle_id = vehicle_id;
            Route_id = route_id;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Status = status;
            TripType = tripType;
            MaxPassengers = maxPassengers;
        }

        // Getters and Setters
        public int GetTrip_id() => Trip_id;
        public void SetTrip_id(int trip_id) => Trip_id = trip_id;

        public int GetVehicle_id() => Vehicle_id;
        public void SetVehicle_id(int vehicle_id) => Vehicle_id = vehicle_id;

        public int GetRoute_id() => Route_id;
        public void SetRoute_id(int route_id) => Route_id = route_id;

        public DateTime GetDepartureDate() => DepartureDate;
        public void SetDepartureDate(DateTime departureDate) => DepartureDate = departureDate;

        public DateTime GetArrivalDate() => ArrivalDate;
        public void SetArrivalDate(DateTime arrivalDate) => ArrivalDate = arrivalDate;

        public string? GetStatus() => Status;
        public void SetStatus(string status) => Status = status;

        public string? GetTripType() => TripType;
        public void SetTripType(string tripType) => TripType = tripType;

        public int GetMaxPassengers() => MaxPassengers;
        public void SetMaxPassengers(int maxPassengers) => MaxPassengers = maxPassengers;
    }
}
