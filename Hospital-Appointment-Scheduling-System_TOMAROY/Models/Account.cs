using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public Account(string name)
        {
            Name = name;
            Random random = new Random();
            ID = random.Next(100000, 999999).ToString();
        }
        public Account(string name, string iD) : this(name)
        {
            ID = iD;
        }
    }
}
