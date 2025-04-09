using System;
using HospitalManagementSystem.DAO_Folder;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Exception_Handling;
using HospitalManagementSystem.Main_Method;
using HospitalManagementSystem.Utility_Services;
using static HospitalManagementSystem.Exception_Handling.ExceptionHandling;

namespace HospitalManagementSystem.Main_Method
{
    public class Mainmethod
    {

        static void Main(string[] args)
        {
            IHospitalService service = new HospitalServiceImpl();
            bool exit = false;

            Console.WriteLine("======= Welcome to Hospital Management System =======");

            while (!exit)
            {
                Console.WriteLine("\nSelect your role:");
                Console.WriteLine("1. Patient");
                Console.WriteLine("2. Doctor");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                string role = Console.ReadLine();

                switch (role)
                {
                    case "1":
                        PatientMenu(service);
                        break;
                    case "2":
                        DoctorMenu(service);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void PatientMenu(IHospitalService service)
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine("\n\n========= Patient Menu =========\n");
                Console.WriteLine("1. View My Appointments");
                Console.WriteLine("2. Schedule My Appointment");
                Console.WriteLine("3. Cancel My Appointment");
                Console.WriteLine("0. Back to Main Page");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter your Patient ID: ");
                        int patientId = Convert.ToInt32((Console.ReadLine()));

                        List<Appointment> patientAppointments = service.GetAppointmentsForPatient(patientId);
                        foreach(var i in patientAppointments)
                        {
                            Console.WriteLine(i);
                        }
                        break;
                    case "2":
                        Console.Write("Enter your Patient ID: ");
                        int spid = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Doctor ID: ");
                        int sdocid = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Appointment Date & Time (yyyy-mm-dd hh:mm): ");
                        DateTime sdate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Description: ");
                        string sdesc = Console.ReadLine();

                        Appointment newAppt = new Appointment(0, spid, sdocid, sdate, sdesc);
                        bool scheduled = service.ScheduleAppointment(newAppt);
                        Console.WriteLine(scheduled ? "Appointment scheduled successfully." : "Failed to schedule.");
                        break;

                    case "3":
                        Console.Write("Enter Appointment ID to cancel: ");
                        int cid = Convert.ToInt32(Console.ReadLine());

                        bool cancelled = service.CancelAppointment(cid);
                        Console.WriteLine(cancelled ? "Appointment cancelled." : "Cancellation failed.");
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void DoctorMenu(IHospitalService service)
        {
            bool back = true;
            Console.Write("Enter Password To Login: ");
            string pass = Console.ReadLine();
            if(pass == "DOCDINESH2025")
            {
                back = false;
                Console.WriteLine("===========Welcome To Admin Menu!===========");
            }
            else
            {
                Console.WriteLine("Invalid Authentication.. Try again");

            }




                while (!back)
                {
                    Console.WriteLine("\n\n===== Doctor Menu =====\n");
                    Console.WriteLine("1. View My Appointments");
                    Console.WriteLine("2. Update My Appointment");
                    Console.WriteLine("0. Back Main Page");
                    Console.Write("Choose an option: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Write("Enter your Doctor ID: ");
                            int did = int.Parse(Console.ReadLine());

                            List<Appointment> docAppointments = service.GetAppointmentsForDoctor(did);

                            docAppointments.ForEach(a => Console.WriteLine(a));
                            break;
                        case "2":
                            Console.Write("Enter Appointment ID to update: ");
                            int aid = int.Parse(Console.ReadLine());

                            try
                            {
                                Appointment existing = service.GetAppointmentById(aid);
                                Console.WriteLine("Current Appointment: " + existing);

                                Console.Write("Enter new Patient ID: ");
                                int upid = int.Parse(Console.ReadLine());

                                Console.Write("Enter new Doctor ID: ");
                                int udocid = int.Parse(Console.ReadLine());

                                Console.Write("Enter new Appointment Date (yyyy-MM-dd HH:mm): ");
                                DateTime udate = DateTime.Parse(Console.ReadLine());

                                Console.Write("Enter new Description: ");
                                string udesc = Console.ReadLine();

                                Appointment updated = new Appointment(aid, upid, udocid, udate, udesc);
                                bool updatedResult = service.UpdateAppointment(updated);

                                Console.WriteLine(updatedResult ? "Appointment updated successfully." : "Update failed.");
                            }
                            catch (PatientNumberNotFoundException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }

                            break;
                        case "0":
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
        }
    }
}
