using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.Models
{
    public class Doctor : Account
    {
        public string? Specialization { get; set; }
        public ObservableCollection<Appointment>? ScheduledAppointments { get; set; } = new ObservableCollection<Appointment>();
        public ObservableCollection<DateOnly>? AvailableDates { get; set; } = new ObservableCollection<DateOnly>();
        public Doctor(string name, string specialization) : base(name)
        {
            Specialization = specialization;
        }
    }
}
