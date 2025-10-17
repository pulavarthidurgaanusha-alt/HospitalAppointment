using HospitalAppointment.Models;

namespace HospitalAppointment.Services
{
    public interface IAppointmentService
    {
            IEnumerable<Appointment> GetAppointments();
            Appointment GetAppointmentById(int appointmentId);
            IEnumerable<Appointment> GetAppointmentsByDoctorId(int doctorId);
            IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId);
            Appointment BookAppointment(Appointment appointment);
            Appointment ChangeStatusToCompleted(int appointmentId);
            Appointment CancelledByDoctor(int appointmentId);
            Appointment CancelledByPatient(int appointmentId);
        }
    }

