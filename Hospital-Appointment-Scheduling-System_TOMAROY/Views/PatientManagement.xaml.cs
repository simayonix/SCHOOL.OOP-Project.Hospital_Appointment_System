using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PatientManagement.xaml
    /// </summary>
    public partial class PatientManagement : UserControl
    {
        public PatientManagement()
        {
            InitializeComponent();
        }
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PatientList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var patient = (Patient)obj;
            if (patient.Name.Contains(FilterSearch.Text, StringComparison.OrdinalIgnoreCase))
                return true;
            if (patient.ID.Contains(FilterSearch.Text))
                return true;
            if (patient.ContactNumber.Contains(FilterSearch.Text))
                return true;
            if (patient.MedicalHistory.Contains(FilterSearch.Text, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
