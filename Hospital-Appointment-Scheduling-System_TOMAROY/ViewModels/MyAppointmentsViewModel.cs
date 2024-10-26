using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class MyAppointmentsViewModel : ViewModelBase
    {
        private object _currentAccount;
        private Appointment _selectedAppointment;
        private bool _isAppointmentInformationVisible;
        public ObservableCollection<Appointment> MyAppointments { get; set; } = new ObservableCollection<Appointment>();
        public object CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value; OnPropertyChanged(nameof(CurrentAccount));
            }
        }
        public Appointment SelectedAppointment
        {
            get { return _selectedAppointment; }
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
                ShowAppointmentInformation();
            }
        }
        public bool IsAppointmentInformationVisible
        {
            get { return _isAppointmentInformationVisible; }
            set { _isAppointmentInformationVisible = value; OnPropertyChanged(nameof(IsAppointmentInformationVisible)); }
        }
        public MyAppointmentsViewModel()
        {
            CurrentAccount = PatientMainMenuViewModel.GetAccount();
            IsAppointmentInformationVisible = false;
            AssignMyAppointments();
        }
        private void AssignMyAppointments()
        {
            ObservableCollection<Appointment> tempAppointments = HASS.DatabaseAppointments;
            foreach (Appointment appointment in tempAppointments)
            {
                if (appointment.Patient == CurrentAccount)
                {
                    MyAppointments.Add(appointment);
                }
            }
        }
        private void ShowAppointmentInformation()
        {
            if (SelectedAppointment != null)
            {
                IsAppointmentInformationVisible = false;
                Task.Delay(200).ContinueWith(_ =>
                {
                    IsAppointmentInformationVisible = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
}
