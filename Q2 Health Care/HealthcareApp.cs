using System;
using System.Collections.Generic;

namespace Assignment3.Question2_Healthcare
{
    public class HealthcareApp
    {
        public void Run()
        {
            Console.WriteLine("=== Question 2: Healthcare System ===\n");

            // Sample data
            var patients = new List<Patient>
            {
                new Patient(1, "Kofi Agyei", 45),
                new Patient(2, "Else Keteku", 18)
            };

            var doctors = new List<Doctor>
            {
                new Doctor(1, "Michael Osei", "Cardiology"),
                new Doctor(2, "Esther Frimpong", "Dermatology")
            };

            var appointments = new List<Appointment>
            {
                new Appointment(1, patients[0], doctors[0], DateTime.Now.AddDays(4)),
                new Appointment(2, patients[1], doctors[1], DateTime.Now.AddDays(6))
            };

            // Display all appointments
            Console.WriteLine("Upcoming Appointments:\n");
            foreach (var appt in appointments)
            {
                Console.WriteLine(appt);
            }

            // Edge case: No appointments
            Console.WriteLine("\n=== Edge Case: No appointments available ===");
            appointments.Clear();
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments scheduled.");
            }
        }
    }
}
