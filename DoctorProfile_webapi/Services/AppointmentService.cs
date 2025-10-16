using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using HospitalAppointment.Repository;
using NuGet.Protocol.Core.Types;
using static HospitalAppointment.Services.AppointmentService;

namespace HospitalAppointment.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly INotificationService _notificationService;

        public AppointmentService(IAppointmentRepository repository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            var appointments = _repository.GetAllAppointments();
            if (appointments == null || !appointments.Any())
                throw new AppointmentNotFoundException();
            return appointments;
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            var appointment = _repository.GetAppointmentById(appointmentId);
            if (appointment == null)
                throw new AppointmentNotFoundException($"Appointment with ID {appointmentId} not found.");
            return appointment;
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            var appointments = _repository.GetAppointmentsByDoctorId(doctorId);
            if (appointments == null || !appointments.Any())
                throw new AppointmentNotFoundException($"No appointments found for Doctor ID {doctorId}.");
            return appointments;
        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            var appointments = _repository.GetAppointmentsByPatientId(patientId);
            if (appointments == null || !appointments.Any())
                throw new AppointmentNotFoundException($"No appointments found for Patient ID {patientId}.");
            return appointments;
        }

        public Appointment BookAppointment(Appointment appointment)
        {
            var booked = _repository.BookAppointment(appointment);
            _notificationService.CreateNotificationOnAppointmentBooked(booked.AppointmentId);
            return booked;
        }

    
        

        public Appointment ChangeStatusToCompleted(int appointmentId)
        {
            var appointment = _repository.ChangeStatusToCompleted(appointmentId);
            if (appointment == null)
                throw new AppointmentNotFoundException();

            // Notification excluded as per your current scope
            return appointment;
        }





        public Appointment CancelledByDoctor(int appointmentId)
        {
            var appointment = _repository.CancelledByDoctor(appointmentId);
            if (appointment == null)
                throw new AppointmentNotFoundException();
            if (appointment.Status != Appointment.AppointmentStatus.Booked)
            {
                throw new InvalidAppointmentStatusException("Only a 'Booked' appointment can be marked as completed.");
            }

            _notificationService.CreateNotificationOnAppointmentCancelledByDoctor(appointment.AppointmentId);
            return appointment;
        }

        public Appointment CancelledByPatient(int appointmentId)
        {
            var appointment = _repository.CancelledByPatient(appointmentId);
            if (appointment == null)
                throw new AppointmentNotFoundException();
            if (appointment.Status != Appointment.AppointmentStatus.Booked)
            {
                throw new InvalidAppointmentStatusException("Only a 'Booked' appointment can be marked as completed.");
            }

            _notificationService.CreateNotificationOnAppointmentCancelledByPatient(appointment.AppointmentId);
            return appointment;
        }
    }
}
