using System;
using System.Data.SqlClient;
using Transport_Management_System.Entities;
using Utilities;
using static Transport_Management_System.Exception_Handling.ExceptionHandling;


namespace Transport_Management_System.DAO_Interface_Implementaion
{
    public class TransportService
    {

        // To register a passenger and to return his/her id

        public int RegisterPassenger(Passengers passenger)
        {
            using (var connection = DataBaseConnector.GetConnection())
            {
                string query = "Insert Into Passengers (First_name, Gender, Age, Email, Phone_number) OUTPUT INSERTED.Passenger_id VALUES (@FirstName, @Gender, @Age, @Email, @PhoneNumber)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", passenger.GetFirst_name());
                    command.Parameters.AddWithValue("@Gender", passenger.GetGender());
                    command.Parameters.AddWithValue("@Age", passenger.GetAge());
                    command.Parameters.AddWithValue("@Email", passenger.GetEmail());
                    command.Parameters.AddWithValue("@PhoneNumber", passenger.GetPhone_number());

                    return (int)command.ExecuteScalar();
                }
            }
        }

        // To get all available scheduled trips..

        public List<Trips> GetAvailableTrips()
        {
            List<Trips> trips = new List<Trips>();

            using (var connection = DataBaseConnector.GetConnection())
            {
                string query = "Select * From Trips where Status = 'Completed'";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trips.Add(new Trips(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetDateTime(3),
                            reader.GetDateTime(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetInt32(7)
                        ));
                    }
                }
            }

            return trips;
        }




        //To Add Vehilce..

        public bool AddVehicle(Vehicles vehicle)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Insert Into Vehicles (Model, Capacity, Type, Status) " +
                                   "VALUES (@Model_name, @Capacity, @Type, @Status)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Model_name", vehicle.GetModel_name());
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.GetCapacity());
                    cmd.Parameters.AddWithValue("@Type", vehicle.GetType());
                    cmd.Parameters.AddWithValue("@Status", vehicle.GetStatus());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding vehicle: " + ex.Message);
                return false;
            }
        }

        // To update a Vehicle...

        public bool UpdateVehicle(Vehicles vehicle)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Update Vehicles set Model = @Model_name, Capacity = @Capacity, " +
                                   "Type = @Type, Status = @Status WHERE Vehicle_id = @Vehicle_id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Model_name", vehicle.GetModel_name());
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.GetCapacity());
                    cmd.Parameters.AddWithValue("@Type", vehicle.GetType());
                    cmd.Parameters.AddWithValue("@Status", vehicle.GetStatus());
                    cmd.Parameters.AddWithValue("@Vehicle_id", vehicle.GetVehicle_id());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (VehicleNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating vehicle: " + ex.Message);
                return false;
            }
        }

        //To Delete a vehicle..
        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Delete From Vehicles where Vehicle_id = @Vehicle_id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Vehicle_id", vehicleId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (VehicleNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting vehicle: " + ex.Message);
                return false;
            }
        }

        //To Schedule trip...

        public bool ScheduleTrip(int vehicleId, int routeId, string departureDate, string arrivalDate)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Insert Into Trips (Vehicle_id, Route_id, DepartureDate, ArrivalDate, Status, TripType, MaxPassengers) " +
                                   "VALUES (@Vehicle_id, @Route_id, @DepartureDate, @ArrivalDate, 'Scheduled', 'Freight', 0)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Vehicle_id", vehicleId);
                    cmd.Parameters.AddWithValue("@Route_id", routeId);
                    cmd.Parameters.AddWithValue("@DepartureDate", DateTime.Parse(departureDate));
                    cmd.Parameters.AddWithValue("@ArrivalDate", DateTime.Parse(arrivalDate));

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (TripSchedulingException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error scheduling trip: " + ex.Message);
                return false;
            }
        }

        // To cancel a Trip...

        public bool CancelTrip(int tripId)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Update Trips set Status = 'Cancelled' where Trip_id = @Trip_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Trip_id", tripId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cancelling trip: " + ex.Message);
                return false;
            }
        }

        // To Book a Trip..

        public bool BookTrip(int tripId, int passengerId, string bookingDate)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Insert Into Bookings (Trip_id, Passenger_id, Booking_date, Status) " +
                                   "VALUES (@Trip_id, @Passenger_id, @Booking_date, 'Confirmed')";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Trip_id", tripId);
                    cmd.Parameters.AddWithValue("@Passenger_id", passengerId);
                    cmd.Parameters.AddWithValue("@Booking_date", DateTime.Parse(bookingDate));

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (TripBookingException t)
            {
                throw t;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error booking trip: " + ex.Message);
                return false;
            }
        }


        // To cancel the booked trip..

        public bool CancelBooking(int bookingId)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Update Bookings SET Status = 'Cancelled' where Booking_id = @Booking_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Booking_id", bookingId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (BookingNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cancelling booking: " + ex.Message);
                return false;
            }
        }


        // To Allocator a Driver..

        public bool AllocateDriver(int tripId, int driverId)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "INSERT INTO TripDrivers (Trip_id, Driver_id) VALUES (@Trip_id, @Driver_id)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Trip_id", tripId);
                    cmd.Parameters.AddWithValue("@Driver_id", driverId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (DriverNotAvailableException d)
            {
                throw d;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error allocating driver: " + ex.Message);
                return false;
            }

        }


        // To Deallocate a allocated driver..

        public bool DeallocateDriver(int tripId)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Delete from TripDrivers where Trip_id = @Trip_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Trip_id", tripId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (DriverNotAssignedException d)
            {
                throw d;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deallocating driver: " + ex.Message);
                return false;
            }
        }

        // To get bookings by passenger..

        public List<Bookings> GetBookingsByPassenger(int passengerId)
        {
            List<Bookings> bookings = new List<Bookings>();

            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Select * From Bookings where Passenger_id = @Passenger_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Passenger_id", passengerId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bookings.Add(new Bookings(
                            (int)reader["Booking_id"],
                            (int)reader["Trip_id"],
                            (int)reader["Passenger_id"],
                            (DateTime)reader["Booking_date"],
                            reader["Status"].ToString()
                        ));
                    }
                }
            }
            catch (BookingNotFoundException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving bookings: " + ex.Message);
            }

            return bookings;
        }



        // To get bookings by trip..

        public List<Bookings> GetBookingsByTrip(int tripId)
        {
            List<Bookings> bookings = new List<Bookings>();

            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Select * From Bookings Where Trip_id = @Trip_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Trip_id", tripId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bookings.Add(new Bookings(
                            (int)reader["Booking_id"],
                            (int)reader["Trip_id"],
                            (int)reader["Passenger_id"],
                            (DateTime)reader["Booking_date"],
                            reader["Status"].ToString()
                        ));
                    }
                }
            }
            catch (BookingNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving bookings by trip: " + ex.Message);
            }

            return bookings;
        }


        // To Get all available drivers..

        public List<Drivers> GetAvailableDrivers()
        {
            List<Drivers> drivers = new List<Drivers>();

            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Select * From Drivers where Driver_id NOT IN " +
                                                           "(Select Driver_id From TripDrivers)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        drivers.Add(new Drivers(
                            (int)reader["Driver_id"],
                            reader["First_name"].ToString(),
                            reader["Last_name"].ToString(),
                            reader["License_number"].ToString(),
                            reader["Phone_number"].ToString(),
                            reader["Email"].ToString(),
                            (int)reader["Experience_years"]
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving available drivers: " + ex.Message);
            }

            return drivers;
        }
    }

}
