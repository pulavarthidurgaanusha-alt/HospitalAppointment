using HospitalAppointment.Models;

namespace HospitalAppointment.Repository
{
    public interface IAppointmentRepository
    {
            IEnumerable<Appointment> GetAllAppointments();
            Appointment GetAppointmentById(int appointmentId);
            IEnumerable<Appointment> GetAppointmentsByDoctorId(int doctorId);
            IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId);
            Appointment BookAppointment(Appointment appointment);
            Appointment ChangeStatusToCompleted(int appointmentId);
            Appointment CancelledByDoctor(int appointmentId);
            Appointment CancelledByPatient(int appointmentId);
        }
    }

