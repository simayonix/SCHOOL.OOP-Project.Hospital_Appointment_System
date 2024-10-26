using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.Models
{
    public enum Status
    {
        Upcoming, Ongoing, Completed, Cancelled, Request
    }
    public class Appointment
    {
       public string? AppointmentID { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public DateOnly? Date { get; set; } 
        public TimeOnly? Time { get; set; }
        public Status? Status { get; set; }
        public Appointment(Patient patient, Doctor doctor, DateOnly date, TimeOnly time, Status status)
        {
            Patient = patient;
            Doctor = doctor;
            Date = date;
            Time = time;
            Status = status;
            Random random = new Random();
            AppointmentID = random.Next(100000, 999999).ToString();
        }
    }
}
