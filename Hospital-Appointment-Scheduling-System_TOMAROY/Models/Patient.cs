using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.Models
{
    public class Patient : Account
    {
        public string? ContactNumber { get; set; }
        public string? MedicalHistory { get; set; }
        public Patient(string name, string contactnumber, string medicalhistory) : base (name)
        {
            ContactNumber = contactnumber;
            MedicalHistory = medicalhistory;
        }
    }
}
