using Hospital_Appointment_Scheduling_System_TOMAROY.Commands;
using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class AppointmentSchedulingViewModel : ViewModelBase
    {
        private object _currentAccount;
        private bool _isDoctorDataGridVisible;
        private bool _isCalendarVisible;
        private Doctor _selectedDoctor;
        private string _doctorName;
        private string _date;
        private string _time;
        public ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();
        public object CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value; OnPropertyChanged(nameof(CurrentAccount));
            }
        }
        public bool IsCalendarVisible
        {
            get { return _isCalendarVisible; }
            set { _isCalendarVisible = value; OnPropertyChanged(nameof(IsCalendarVisible)); }
        }
        public bool IsDoctorDataGridVisible
        {
            get { return _isDoctorDataGridVisible; }
            set { _isDoctorDataGridVisible = value; OnPropertyChanged(nameof(IsDoctorDataGridVisible)); }
        }
        public Doctor SelectedDoctor
        {
            get { return _selectedDoctor; }
            set { _selectedDoctor = value; OnPropertyChanged(nameof(SelectedDoctor)); }
        }
        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; OnPropertyChanged(nameof(DoctorName)); }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; OnPropertyChanged(nameof(Time)); }
        }
        public ICommand ScheduleNowCommand {  get; set; }
        public ICommand ShowCalendarCommand {  get; set; }
        public ICommand ShowDoctorDataGridCommand {  get; set; }
        public AppointmentSchedulingViewModel()
        {
            Doctors = HASS.DatabaseDoctors;
            CurrentAccount = PatientMainMenuViewModel.GetAccount();
            IsCalendarVisible = true;
            IsDoctorDataGridVisible = false;
            ShowCalendarCommand = new RelayCommand(ShowCalendar, (s) => true);
            ShowDoctorDataGridCommand = new RelayCommand(ShowDoctorDataGrid, (s) => true);
            ScheduleNowCommand = new RelayCommand(ScheduleNow, (s)=>true);
        }
        private void ShowCalendar(object obj)
        {
            IsDoctorDataGridVisible = false;
            IsCalendarVisible = true;
        }
        private void ShowDoctorDataGrid(object obj)
        {
            IsDoctorDataGridVisible = true;
            IsCalendarVisible = false;
        }
        private void ScheduleNow(object obj)
        {
            MessageBox.Show("Schedule request sent");
            List<string> tempappointment = new List<string>
            {
                DoctorName,
                Date,
                Time
            };
            AppointmentManagementViewModel.NewAppointmentRequest(tempappointment, CurrentAccount);
        }
    }
}
