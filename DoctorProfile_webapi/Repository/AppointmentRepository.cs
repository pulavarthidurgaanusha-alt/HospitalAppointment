using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using static HospitalAppointment.Repository.AppointmentRepository;

namespace HospitalAppointment.Repository
{

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly Appointment_BookingContext _context;

        public AppointmentRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointment.ToList();
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _context.Appointment.FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _context.Appointment.Where(a => a.DoctorId == doctorId).ToList();
        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _context.Appointment.Where(a => a.PatientId == patientId).ToList();
        }

        public Appointment BookAppointment(Appointment appointment)
        {
            // Find the availability slot for the appointment
            var availability = _context.Availability.FirstOrDefault(a => a.AvailabilityId == appointment.AvailabilityId);

            // Check if the slot exists and is available
            if (availability == null || availability.Status == Availability.AvailabilityStatus.Unavailable)
            {

                throw new SlotUnavailableException();
            }

            // Change the availability status to Unavailable
            availability.Status = Availability.AvailabilityStatus.Unavailable;
            _context.Availability.Update(availability);

            // Add the new appointment
            _context.Appointment.Add(appointment);

            // Save both changes (availability update and new appointment) in a single transaction
            _context.SaveChanges();
            return appointment;
        }

        Appointment IAppointmentRepository.ChangeStatusToCompleted(int appointmentId)
        {
            throw new NotImplementedException();
        }

        Appointment IAppointmentRepository.CancelledByDoctor(int appointmentId)
        {
            throw new NotImplementedException();
        }

        Appointment IAppointmentRepository.CancelledByPatient(int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
