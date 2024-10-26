using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.Models
{
    public class HASS
    {
        public static Account Staff { get; set; } = new Account("Simon", "123");
        public static ObservableCollection<Patient> DatabasePatients { get; set; } = new ObservableCollection<Patient>
        {
            new Patient("Luffy", "09223428765", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer egestas faucibus metus a interdum. Maecenas sit amet est gravida, sollicitudin sem at, pretium quam."),
            new Patient("Zoro", "09223428765", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer egestas faucibus metus a interdum. Maecenas sit amet est gravida, sollicitudin sem at, pretium quam."),
            new Patient("Nami", "09223428765", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer egestas faucibus metus a interdum. Maecenas sit amet est gravida, sollicitudin sem at, pretium quam.")
        };
        public static ObservableCollection<Doctor> DatabaseDoctors { get; set; } = new ObservableCollection<Doctor>
        {
            new Doctor("Stephanie", "Cardiologist"),
            new Doctor("Chopper", "Neurologist"),
            new Doctor("Brook", "Orthopedic")
        };
        public static ObservableCollection<Appointment> DatabaseAppointments { get; set; } = new ObservableCollection<Appointment>
        {
            new Appointment(DatabasePatients[0], DatabaseDoctors[1], new DateOnly(2024,05,15), new TimeOnly(14,30,0), Status.Upcoming),
            new Appointment(DatabasePatients[0], DatabaseDoctors[1], new DateOnly(2024,05,20), new TimeOnly(7,40,0), Status.Upcoming),
            new Appointment(DatabasePatients[1], DatabaseDoctors[2], new DateOnly(2024,05,10), new TimeOnly(12,0,0), Status.Completed)
        };
        public static ObservableCollection<DateOnly> AvailableDates { get; set; } = new ObservableCollection<DateOnly>
        {
            new DateOnly(2024,05,26),
            new DateOnly(2024,06,01)
        };
        public static ObservableCollection<Doctor> GetDoctors()
        {
            foreach (Appointment appointment in DatabaseAppointments)
            {
                foreach (Doctor doctor in DatabaseDoctors)
                {
                    if (appointment.Doctor.Name == doctor.Name)
                    {
                        doctor.ScheduledAppointments.Add(appointment);
                    }
                }
            }
            return DatabaseDoctors;
        }
        public static void AddPatient(Patient patient)
        {
            DatabasePatients.Add(patient);
        }
        public static void RemovePatient(Patient patient)
        {
            DatabasePatients.Remove(patient);
        }
        public static void AddDoctor(Doctor doctor)
        {
            DatabaseDoctors.Add(doctor);
        }
        public static void RemoveDoctor(Doctor doctor)
        {
            DatabaseDoctors.Remove(doctor);
        }
        public static void RemoveAppointment(Appointment appointment)
        {
            DatabaseAppointments.Remove(appointment);
        }
    }
}
