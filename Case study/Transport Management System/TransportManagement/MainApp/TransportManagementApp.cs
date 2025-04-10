using System;
using System.Collections.Generic;
using Transport_Management_System.Exception_Handling;
using Transport_Management_System.Entities;
using Transport_Management_System.DAO_Interface_Implementaion;
using Transport_Management_System.MainApp;



namespace Transport_Management_System.MainApp
{
    public class TransportManagementApp
    {
        public static void Main(string[] args)
        {
            TransportService service = new TransportService();
            bool isrunning = true;

            while (isrunning)
            {
                Console.WriteLine("\n============= TRANSPORT MANAGEMENT SYSTEM ============");
                Console.WriteLine("1. <------Admin Login----->");
                Console.WriteLine("2. <----Passenger Access---->");
                Console.WriteLine("0. Exit");
                Console.Write("Select your role: ");
                string roleInput = Console.ReadLine();

                switch (roleInput)
                {
                    case "1":
                        if (AdminLogin())
                        {
                            AdminMenu(service);
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials! Access denied.");
                        }
                        break;

                    case "2":
                        PassengerMenu(service);
                        break;

                    case "0":
                        isrunning = false;
                        Console.WriteLine("Thank you! Happy Journey!!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private static bool AdminLogin()
        {
            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            return username == "Dinesh" && password == "dinesh2025";
        }

        private static void AdminMenu(TransportService service)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- ADMIN MENU ---");
                Console.WriteLine("1--->Add Vehicle");
                Console.WriteLine("2--->Update Vehicle");
                Console.WriteLine("3--->Delete Vehicle");
                Console.WriteLine("4--->Schedule Trip");
                Console.WriteLine("5--->Cancel Trip");
                Console.WriteLine("6--->Allocate Driver");
                Console.WriteLine("7--->Deallocate Driver");
                Console.WriteLine("8--->Get Bookings by Trip");
                Console.WriteLine("9--->Get Available Drivers");
                Console.WriteLine("0--->Logout");
                Console.Write("Choose an option: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            // Add Vehicle
                            Console.Write("Enter Model: ");
                            string model = Console.ReadLine();
                            Console.Write("Enter Capacity: ");
                            decimal cap = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Type: ");
                            string type = Console.ReadLine();
                            Console.Write("Enter Status: ");
                            string status = Console.ReadLine();
                            Vehicles vehicle = new Vehicles(0, model, cap, type, status);
                            Console.WriteLine(service.AddVehicle(vehicle) ? "Added Successfully!" : "Failed.");
                            break;

                        case 2:
                            // Update Vehicle
                            Console.Write("Enter Vehicle ID: ");
                            int uvId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Model: ");
                            string uModel = Console.ReadLine();
                            Console.Write("Enter Capacity: ");
                            decimal uCap = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Type: ");
                            string uType = Console.ReadLine();
                            Console.Write("Enter Status: ");
                            string uStatus = Console.ReadLine();
                            Vehicles updated = new Vehicles(uvId, uModel, uCap, uType, uStatus);
                            Console.WriteLine(service.UpdateVehicle(updated) ? "Updated Successfully!" : "Failed.");
                            break;

                        case 3:
                            Console.Write("Enter Vehicle ID to delete: ");
                            int dId = int.Parse(Console.ReadLine());
                            Console.WriteLine(service.DeleteVehicle(dId) ? "Removed Successfullyy!" : "Failed.");
                            break;

                        case 4:
                            Console.Write("Enter Vehicle ID: ");
                            int sv = int.Parse(Console.ReadLine());
                            Console.Write("Enter Route ID: ");
                            int route = int.Parse(Console.ReadLine());
                            Console.Write("Enter Departure (yyyy-mm-dd): ");
                            string dep = Console.ReadLine();
                            Console.Write("Enter Arrival (yyyy-mm-dd): ");
                            string arr = Console.ReadLine();
                            Console.WriteLine(service.ScheduleTrip(sv, route, dep, arr) ? "Scheduled Succesfully!" : "Failed.");
                            break;

                        case 5:
                            Console.Write("Enter Trip ID to cancel: ");
                            int tc = int.Parse(Console.ReadLine());
                            Console.WriteLine(service.CancelTrip(tc) ? "Cancelled!" : "Failed.");
                            break;

                        case 6:
                            Console.Write("Enter Trip ID: ");
                            int tid = int.Parse(Console.ReadLine());
                            Console.Write("Enter Driver ID: ");
                            int did = int.Parse(Console.ReadLine());

                            Console.WriteLine(service.AllocateDriver(tid, did) ? "Allocated Success!" : "Failed.");
                            break;

                        case 7:
                            Console.Write("Enter Trip ID: ");
                            int dtid = int.Parse(Console.ReadLine());
                            Console.WriteLine(service.DeallocateDriver(dtid) ? "Deallocated Success!" : "Failed.");
                            break;

                        case 8:
                            Console.Write("Enter Trip ID: ");
                            int btid = int.Parse(Console.ReadLine());
                            var bList = service.GetBookingsByTrip(btid);
                            foreach (var b in bList)
                            {
                                Console.WriteLine($"Booking ID: {b.GetBooking_id()}, Passenger: {b.GetPassenger_id()}, Status: {b.GetStatus()}");
                            }
                            break;

                        case 9:
                            var drivers = service.GetAvailableDrivers();
                            foreach (var d in drivers)
                            {
                                Console.WriteLine($"Driver ID: {d.GetDriver_id()}, Name: {d.GetFirst_name()} {d.GetLast_name()}");
                            }
                            break;

                        case 0:
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid admin option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static void PassengerMenu(TransportService service)
        {
            bool running = true;
            int currentPassengerId = -1;

            while (running)
            {
                Console.WriteLine("\n============PASSENGER MENU ==============");
                Console.WriteLine("1---> Register as Passenger");
                Console.WriteLine("2---> View Available Trips");
                Console.WriteLine("3---> Book a Trip");
                Console.WriteLine("4---> Cancel Booking");
                Console.WriteLine("5---> View My Bookings");
                Console.WriteLine("0---> Back to Main Menu");
                Console.Write("Choose an option: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter First Name: ");
                            string fname = Console.ReadLine();
                            Console.Write("Enter Gender: ");
                            string gender = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Phone Number: ");
                            string phone = Console.ReadLine();

                            Passengers newPassenger = new Passengers(0, fname, gender, age, email, phone);
                            currentPassengerId = service.RegisterPassenger(newPassenger);
                            Console.WriteLine($"Registered Successfully! Your Passenger ID: {currentPassengerId}");
                            break;

                        case 2:
                            var trips = service.GetAvailableTrips();
                            Console.WriteLine("---- Available Trips ----");
                            foreach (var t in trips)
                            {
                                Console.WriteLine($"Trip ID: {t.GetTrip_id()}, Route ID: {t.GetRoute_id()}, Departure: {t.GetDepartureDate()}, Arrival: {t.GetArrivalDate()}, Type: {t.GetTripType()}");
                            }
                            break;

                        case 3:
                            if (currentPassengerId == -1)
                            {
                                Console.WriteLine("Please register first to book a trip.");
                                break;
                            }

                            var availableTrips = service.GetAvailableTrips();
                            Console.WriteLine("---- Available Trips ----");
                            foreach (var t in availableTrips)
                            {
                                Console.WriteLine($"Trip ID: {t.GetTrip_id()}, Route ID: {t.GetRoute_id()}, Departure: {t.GetDepartureDate()}, Arrival: {t.GetArrivalDate()}, Type: {t.GetTripType()}");
                            }

                            Console.Write("Enter Trip ID to book: ");
                            int tripId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Booking Date (yyyy-MM-dd): ");
                            string bookingDate = Console.ReadLine();

                            Console.WriteLine(service.BookTrip(tripId, currentPassengerId, bookingDate) ? "Booked Successfully!" : "Booking Failed.");
                            break;

                        case 4:
                            Console.Write("Enter Booking ID to cancel: ");
                            int bid = int.Parse(Console.ReadLine());
                            Console.WriteLine(service.CancelBooking(bid) ? "Cancelled!" : "Failed.");
                            break;

                        case 5:
                            Console.Write("Enter your Passenger ID: ");
                            int pid = int.Parse(Console.ReadLine());
                            var bookings = service.GetBookingsByPassenger(pid);
                            foreach (var b in bookings)
                            {
                                Console.WriteLine($"Booking ID: {b.GetBooking_id()}, Trip ID: {b.GetTrip_id()}, Date: {b.GetBooking_date()}, Status: {b.GetStatus()}");
                            }
                            break;

                        case 0:
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
