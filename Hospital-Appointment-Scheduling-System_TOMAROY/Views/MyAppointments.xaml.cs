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
    /// Interaction logic for MyAppointments.xaml
    /// </summary>
    public partial class MyAppointments : UserControl
    {
        public MyAppointments()
        {
            InitializeComponent();
        }
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoctorList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var appointment = (Appointment)obj;
            if (appointment.AppointmentID.Contains(FilterSearch.Text))
                return true;
            if (appointment.Patient.Name.Contains(FilterSearch.Text, StringComparison.OrdinalIgnoreCase))
                return true;
            if (appointment.Doctor.Name.Contains(FilterSearch.Text, StringComparison.OrdinalIgnoreCase))
                return true;
            if (appointment.Date.ToString().Contains(FilterSearch.Text))
                return true;
            if (appointment.Time.ToString().Contains(FilterSearch.Text))
                return true;
            if (appointment.Status.ToString().Contains(FilterSearch.Text))
                return true;
            return false;
        }
    }
}
