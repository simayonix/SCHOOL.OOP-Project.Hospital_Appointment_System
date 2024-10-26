using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.Views
{
    /// <summary>
    /// Interaction logic for DoctorManagement.xaml
    /// </summary>
    public partial class DoctorManagement : UserControl
    {
        public DoctorManagement()
        {
            InitializeComponent();
        }
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoctorList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var doctor = (Doctor)obj;
            if (doctor.Name.Contains(FilterSearch.Text, StringComparison.OrdinalIgnoreCase))
                return true;
            if (doctor.ID.Contains(FilterSearch.Text))
                return true;
            if (doctor.Specialization.Contains(FilterSearch.Text))
                return true;
            foreach (var item in doctor.ScheduledAppointments)
            {
                if (item.AppointmentID == FilterSearch.Text)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
