using Hospital_Appointment_Scheduling_System_TOMAROY.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Security.Principal;
using Hospital_Appointment_Scheduling_System_TOMAROY.Models;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private LoginViewModel _loginViewModel;
        private MainMenuViewModel _mainMenuViewModel;
        private PatientMainMenuViewModel _patientMainMenuViewModel;
        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
                if (_currentViewModel is LoginViewModel loginViewModel)
                {
                    LoginViewModel = loginViewModel;
                }
                if (_currentViewModel is MainMenuViewModel mainMenuViewModel)
                {
                    MainMenuViewModel = mainMenuViewModel;
                }
                if (_currentViewModel is PatientMainMenuViewModel patientMainMenuViewModel)
                {
                    PatientMainMenuViewModel = patientMainMenuViewModel;
                }
            }
        }
        public LoginViewModel LoginViewModel
        {
            get { return _loginViewModel; }
            set
            {
                _loginViewModel = value; OnPropertyChanged(nameof(LoginViewModel));
            }
        }
        public MainMenuViewModel MainMenuViewModel
        {
            get { return _mainMenuViewModel; }
            set
            {
                _mainMenuViewModel = value; OnPropertyChanged(nameof(MainMenuViewModel));
            }
        }
        public PatientMainMenuViewModel PatientMainMenuViewModel
        {
            get { return _patientMainMenuViewModel; }
            set
            {
                _patientMainMenuViewModel = value; OnPropertyChanged(nameof(PatientMainMenuViewModel));
            }
        }
        public ObservableCollection<Doctor> Doctors { get; set; } = new ObservableCollection<Doctor>();
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();
        public MainViewModel()
        {
            Doctors = HASS.GetDoctors();
            Patients = HASS.DatabasePatients;
            CurrentViewModel = new LoginViewModel(this);
        }
    }
}
