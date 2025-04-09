using HospitalManagementSystem.Entities;
using System.Data.SqlClient;
using HospitalManagementSystem.Exception_Handling;
using HospitalManagementSystem.Utility_Services;
using static HospitalManagementSystem.Exception_Handling.ExceptionHandling;

namespace HospitalManagementSystem.DAO_Folder
{
    public class HospitalServiceImpl : IHospitalService
    {
        private SqlConnection conn;

        public HospitalServiceImpl()
        {
            conn = DataBaseConnector.GetConnection(); 
        }

        // using Select query we are going to read the datas in the table..
        // To get appointment by the ID..
        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = null;

            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Select * From Appointment where appointmentId = @appointmentId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                appointment = new Appointment
                                {
                                    AppointmentId = (int)reader["appointmentId"],
                                    PatientId = (int)reader["patientId"],
                                    DoctorId = (int)reader["doctorId"],
                                    AppointmentDate = (DateTime)reader["appointmentDate"],
                                    Description = reader["description"].ToString()
                                };
                            }
                            else
                            {
                                throw new PatientNumberNotFoundException($"No appointment found with this ID: {appointmentId}");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return appointment;
        }


        // To get the appoinment for patients..
        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Select * From Appointment where patientId = @patientId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", patientId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Appointment appointment = new Appointment
                                {
                                    AppointmentId = (int)reader["appointmentId"],
                                    PatientId = (int)reader["patientId"],
                                    DoctorId = (int)reader["doctorId"],
                                    AppointmentDate = (DateTime)reader["appointmentDate"],
                                    Description = reader["description"].ToString()
                                };

                                appointments.Add(appointment);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return appointments;
        }

        // To get appointments for Doctor..
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Select * From Appointment where doctorId = @doctorId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@doctorId", doctorId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Appointment appointment = new Appointment
                                {
                                    AppointmentId = (int)reader["appointmentId"],
                                    PatientId = (int)reader["patientId"],
                                    DoctorId = (int)reader["doctorId"],
                                    AppointmentDate = (DateTime)reader["appointmentDate"],
                                    Description = reader["description"].ToString()
                                };

                                appointments.Add(appointment);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }

            return appointments;
        }

        //using Insert query we are going to insert values in the table..
        // To schedule an appointment..
        public bool ScheduleAppointment(Appointment appointment)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = @"Insert into Appointment (patientId, doctorId, appointmentDate, description)
                             Values (@patientId, @doctorId, @appointmentDate, @description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                        cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                        cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                        cmd.Parameters.AddWithValue("@description", appointment.Description);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }

        //To update an appointment using update query..

        public bool UpdateAppointment(Appointment appointment)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = @"Update Appointment Set patientId = @patientId,
                                 doctorId = @doctorId, appointmentDate = @appointmentDate, description = @description
                                           where appointmentId = @appointmentId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
                        cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
                        cmd.Parameters.AddWithValue("@appointmentDate", appointment.AppointmentDate);
                        cmd.Parameters.AddWithValue("@description", appointment.Description);
                        cmd.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);

                        int result = cmd.ExecuteNonQuery();// will return count one row one coulmn like that..
                        return result > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }

        //To cancel an appointment using ID of appointment..
        public bool CancelAppointment(int appointmentId)
        {
            try
            {
                using (SqlConnection conn = DataBaseConnector.GetConnection())
                {
                    string query = "Delete From Appointment Where appointmentId = @appointmentId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return false;
            }
        }
    }
}
