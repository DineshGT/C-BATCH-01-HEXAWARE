using HospitalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DAO_Folder
{
    public interface IHospitalService
    {
        // To Get an appointment by appointment ID..
        Appointment GetAppointmentById(int appointmentId);

        // To Get all appointments for specific patient..
        List<Appointment> GetAppointmentsForPatient(int patientId);

        // To Get all appointments for a specific doctor..
        List<Appointment> GetAppointmentsForDoctor(int doctorId);

        // To Schedule a new appoinment..
        bool ScheduleAppointment(Appointment appointment);

        // For updating an existing appointment..
        bool UpdateAppointment(Appointment appointment);

        // For Canceling an appointment
        bool CancelAppointment(int appointmentId);
    }
}
