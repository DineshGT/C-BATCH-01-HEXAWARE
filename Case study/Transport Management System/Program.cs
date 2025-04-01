using System;

namespace TransportManagementSystem
{
    public class classTMS
    {
        //vehicles class starts
        public class Vehicles
        {
            //fields
            private int Vehicle_id { get; set; }
            private string ? Model_name { get; set; }
            private decimal Capacity { get; set; }
            private string ? Type { get; set; }
            private string ? Status { get; set; }

            //parameterized constructor

            Vehicles(int vehicle_id, string model, decimal capacity, string type, string status)
            {
                Vehicle_id = vehicle_id;
                Model_name = model;
                Capacity = capacity;
                Type = type;
                Status = status;
            }

        }

        //routes class starts
        public class Routes
        {
            //fields

            private int Route_id { get; set; }
            private string? StartDestination { get; set; }
            private string ? EndDestination { get; set; }
            private decimal Distance { get; set; }

            Routes(int routeid, string start_destination, string end_destination, decimal distance)
            {
                Route_id = routeid;
                StartDestination = start_destination;
                EndDestination = end_destination;
                Distance = distance;

            }

            

        }

        public class Trips
        {
            private int TripID { get; set; }
            private int VehicleID { get; set; }
            private int RouteID { get; set; }
            private DateTime DepartureDate { get; set; }
            private DateTime ArrivalDate { get; set; }
            private string? Status { get; set; }
            private string? TripType { get; set; } = "Freight";
            private int MaxPassengers { get; set; }

            public Trips(int tripID, int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate, string status, string tripType, int maxPassengers)
            {
                TripID = tripID;
                VehicleID = vehicleID;
                RouteID = routeID;
                DepartureDate = departureDate;
                ArrivalDate = arrivalDate;
                Status = status;
                TripType = tripType;
                MaxPassengers = maxPassengers;
            }
        }

        public class Passengers
        {
            private int PassengerID { get; set; }
            private string? FirstName { get; set; }
            private string? Gender { get; set; }
            private int Age { get; set; }
            private string? Email { get; set; }
            private string? PhoneNumber { get; set; }

            public Passengers(int passengerID, string firstName, string gender, int age, string email, string phoneNumber)
            {
                PassengerID = passengerID;
                FirstName = firstName;
                Gender = gender;
                Age = age;
                Email = email;
                PhoneNumber = phoneNumber;
            }
        }

        public class Bookings
        {
            private int BookingID { get; set; }
            private int TripID { get; set; }
            private int PassengerID { get; set; }
            private DateTime BookingDate { get; set; }
            private string? Status { get; set; }

            public Bookings(int bookingID, int tripID, int passengerID, DateTime bookingDate, string status)
            {
                BookingID = bookingID;
                TripID = tripID;
                PassengerID = passengerID;
                BookingDate = bookingDate;
                Status = status;
            }
        }


        public static void Main(string[] args)
        {

            Console.WriteLine("Program starts here");


        }
    }
}
