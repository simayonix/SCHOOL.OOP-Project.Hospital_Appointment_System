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

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class DoctorManagementViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private Doctor _selectedDoctor;
        private bool _isAddDoctorPanelVisible;
        private bool _isDoctorInformationVisible;
        private bool _isEditButtonChecked;
        private string _id;
        private string _name;
        private string _specialization;
        private DateOnly _availableDate;
        private string _appointments;
        public ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();
        public bool IsDoctorInformationVisible
        {
            get { return _isDoctorInformationVisible; }
            set { _isDoctorInformationVisible = value; OnPropertyChanged(nameof(IsDoctorInformationVisible)); }
        }
        public bool IsAddDoctorPanelVisible
        {
            get { return _isAddDoctorPanelVisible; }
            set { _isAddDoctorPanelVisible = value; OnPropertyChanged(nameof(IsAddDoctorPanelVisible)); }
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
        public ICommand ShowAddDoctorCommand { get; set; }
        public ICommand HideAddDoctorCommand { get; set; }
        public ICommand AddDoctorCommand { get; set; }
        public ICommand ShowEditDoctorCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
        public ICommand RemoveDoctorCommand { get; set; }
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
            set { _mainViewModel = value; OnPropertyChanged(nameof(MainViewModel)); }
        }
        public Doctor SelectedDoctor
        {
            get { return _selectedDoctor; }
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged(nameof(SelectedDoctor));
                AppointmentsToShowInformation();
                ShowDoctorInformation();
            }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        public string Specialization
        {
            get { return _specialization; }
            set { _specialization = value; OnPropertyChanged(nameof(Specialization)); }
        }
        public DateOnly AvailableDate
        {
            get { return _availableDate; }
            set { _availableDate = value; OnPropertyChanged(nameof(AvailableDate)); }
        }
        public string Appointments
        {
            get { return _appointments; }
            set { _appointments = value; OnPropertyChanged(nameof(Appointments)); }
        }
        public DoctorManagementViewModel()
        {
            IsAddDoctorPanelVisible = false;
            IsDoctorInformationVisible = false;
            IsEditButtonChecked = false;
            Doctors = HASS.DatabaseDoctors;
            //TempView();
            ShowAddDoctorCommand = new RelayCommand(ShowAddDoctor, (s) => true);
            HideAddDoctorCommand = new RelayCommand(HideAddDoctor, (s) => true);
            AddDoctorCommand = new RelayCommand(AddDoctor, (s) => true);
            ShowEditDoctorCommand = new RelayCommand(ShowEditDoctor, (s) => true);
            SaveEditCommand = new RelayCommand(SaveEditDoctor, (s) => true);
            RemoveDoctorCommand = new RelayCommand(RemoveDoctor, (s) => true);
        }
        private void ShowDoctorInformation()
        {
            if (SelectedDoctor != null)
            {
                IsAddDoctorPanelVisible = false;
                IsDoctorInformationVisible = false;
                Task.Delay(200).ContinueWith(_ =>
                {
                    IsDoctorInformationVisible = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        //private void TempView() //rework
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (Doctor doctor in Doctors)
        //    {
        //        if (doctor.ScheduledAppointments.Count > 1)
        //        {
        //            sb.Append(doctor.ScheduledAppointments[0].AppointmentID);
        //            sb.Append("...");
        //            doctor.ScheduledAppointments[0].AppointmentID = sb.ToString();
        //        }
        //    }
        //}
        private void AppointmentsToShowInformation()
        {
            StringBuilder sb = new StringBuilder();
            int x = 1;
            if (SelectedDoctor != null)
            {
                foreach (Appointment appointment in SelectedDoctor.ScheduledAppointments)
                {
                    sb.Append($"{x}. ID#: {appointment.AppointmentID} Patient: {appointment.Patient.Name}\n");
                    sb.Append($"Date: {appointment.Date} Time: {appointment.Time}\n");
                    x++;
                }
                Appointments = sb.ToString();
            }
        }
        private void ShowAddDoctor(object obj)
        {
            SelectedDoctor = null;
            IsAddDoctorPanelVisible = true;
            IsDoctorInformationVisible = false;
        }
        private void HideAddDoctor(object obj)
        {
            IsAddDoctorPanelVisible = false;
        }
        private void AddDoctor(object obj)
        {
            if (Name != null && Specialization != null)
            {
                Doctor newDoctor = new(Name, Specialization);
                HASS.AddDoctor(newDoctor);
                MessageBox.Show($"{Name} has been added to the database");
                IsAddDoctorPanelVisible = false;
                Name = null;
                Specialization = null;
            }
            else
            {
                MessageBox.Show("Please ensure you have entered the correct information.");
            }
        }
        private void ShowEditDoctor(object obj)
        {
            MessageBox.Show("Edit ENABLED!!");
            IsDoctorInformationVisible = true;
        }
        private void SaveEditDoctor(object obj)
        {
            IsEditButtonChecked = false;
            MessageBox.Show("Changes saved");
        }
        private void RemoveDoctor(object obj)
        {
            HASS.RemoveDoctor(SelectedDoctor);
            IsDoctorInformationVisible = false;
        }
    }
}
