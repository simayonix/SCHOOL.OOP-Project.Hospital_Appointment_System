using Hospital_Appointment_Scheduling_System_TOMAROY.Commands;
using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class AppointmentManagementViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private Appointment _selectedAppointment;
        private Appointment _selectedNewAppointment;
        private bool _isAppointmentInformationVisible;
        private bool _isNewAppointmentsVisible;
        private bool _isAppointmentsVisible;
        private bool _isEditButtonChecked;
        private string _id;
        public static ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();
        public ObservableCollection<Appointment> Appointments { get; set; } = new ObservableCollection<Appointment>();
        public static ObservableCollection<Appointment> TemporaryAppointments { get; set; } = new ObservableCollection<Appointment>();
        public bool IsAppointmentInformationVisible
        {
            get { return _isAppointmentInformationVisible; }
            set { _isAppointmentInformationVisible = value; OnPropertyChanged(nameof(IsAppointmentInformationVisible)); }
        }
        public bool IsEditButtonChecked
        {
            get { return _isEditButtonChecked; }
            set
            {
                _isEditButtonChecked = value;
                OnPropertyChanged(nameof(IsEditButtonChecked));
            }
        }
        public bool IsAppointmentsVisible
        {
            get { return _isAppointmentsVisible; }
            set { _isAppointmentsVisible = value; OnPropertyChanged(nameof(IsAppointmentsVisible)); }
        }
        public bool IsNewAppointmentsVisible
        {
            get { return _isNewAppointmentsVisible; }
            set { _isNewAppointmentsVisible = value; OnPropertyChanged(nameof(IsNewAppointmentsVisible)); }
        }
        public ICommand ShowEditAppointmentCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
        public ICommand RemoveAppointmentCommand { get; set; }
        public ICommand ShowNewAppointmentCommand { get; set; }
        public ICommand HideNewAppointmentCommand { get; set; }
        public ICommand ApproveAppointmentCommand { get; set; }
        public ICommand DenyAppointmentCommand { get; set; }
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
            set { _mainViewModel = value; OnPropertyChanged(nameof(MainViewModel)); }
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
        public Appointment SelectedNewAppointment
        {
            get { return _selectedNewAppointment; }
            set
            {
                _selectedNewAppointment = value;
                OnPropertyChanged(nameof(SelectedNewAppointment));
                ShowAppointmentInformation();
            }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        public AppointmentManagementViewModel()
        {
            IsAppointmentInformationVisible = false;
            IsAppointmentsVisible = true;
            IsNewAppointmentsVisible = false;
            IsEditButtonChecked = false;
            Appointments = HASS.DatabaseAppointments;
            Doctors = HASS.DatabaseDoctors;
            ShowEditAppointmentCommand = new RelayCommand(ShowEditAppointment, (s) => true);
            SaveEditCommand = new RelayCommand(SaveEditAppointment, (s) => true);
            RemoveAppointmentCommand = new RelayCommand(RemoveAppointment, (s) => true);
            ShowNewAppointmentCommand = new RelayCommand(ShowNewAppointment, (s) => true);
            HideNewAppointmentCommand = new RelayCommand(HideNewAppointment, (s) => true);
            ApproveAppointmentCommand = new RelayCommand(ApproveAppointment, (s) => true);
            DenyAppointmentCommand = new RelayCommand(DenyAppointment, (s) => true);
        }

        private void DenyAppointment(object obj)
        {
            TemporaryAppointments.Remove(SelectedNewAppointment);
        }

        private void HideNewAppointment(object obj)
        {
            IsNewAppointmentsVisible = false;
            IsAppointmentsVisible = true;
        }

        private void ShowNewAppointment(object obj)
        {
            IsAppointmentsVisible = false;
            IsNewAppointmentsVisible = true;
            if (TemporaryAppointments.Count > 0)
            {
                MessageBox.Show("Pending Appointment Request for Approval");
            }
        }

        private void ApproveAppointment(object obj)
        {
            SelectedAppointment.Status = Status.Upcoming;
            Appointments.Add(SelectedNewAppointment);
            MessageBox.Show("Approved appointment");
            TemporaryAppointments.Remove(SelectedNewAppointment);
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
        private void ShowEditAppointment(object obj)
        {
            MessageBox.Show("Edit ENABLED!!");
            IsAppointmentInformationVisible = true;
        }
        private void SaveEditAppointment(object obj)
        {
            IsEditButtonChecked = false;
            MessageBox.Show("Changes saved");
        }
        private void RemoveAppointment(object obj)
        {
            HASS.RemoveAppointment(SelectedAppointment);
            IsAppointmentInformationVisible = false;
        }
        public static void NewAppointmentRequest(List<string> tempappointment, object patient)
        {
            Doctors = HASS.DatabaseDoctors;
            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Name == tempappointment[0])
                {
                    Doctor tempdoctor = doctor;
                    Appointment newAppointment = new((Patient)patient, tempdoctor, DateOnly.Parse(tempappointment[1]), TimeOnly.Parse(tempappointment[2]), Status.Request);
                    TemporaryAppointments.Add(newAppointment);
                }
            }
        }
    }
}
 