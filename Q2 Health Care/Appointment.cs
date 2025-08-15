
using System;
using System.Numerics;

namespace Assignment3.Question2_Healthcare
{
    public class Appointment
    {
        public int AppointmentId { get; }
        public Patient Patient { get; }
        public Doctor Doctor { get; }
        public DateTime Date { get; }

        public Appointment(int appointmentId, Patient patient, Doctor doctor, DateTime date)
        {
            AppointmentId = appointmentId;
            Patient = patient;
            Doctor = doctor;
            Date = date;
        }

        public override string ToString() =>
            $"Appointment #{AppointmentId} on {Date:dd/MM/yyyy} - {Patient.Name} with {Doctor.Name} ({Doctor.Specialty})";
    }
}
