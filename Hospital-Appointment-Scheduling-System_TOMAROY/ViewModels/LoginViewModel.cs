using Hospital_Appointment_Scheduling_System_TOMAROY.Commands;
using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private ObservableCollection<Patient> _patients;
        private Account _staff;
        private object _loginAccount;
        public LoginViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            Patients = HASS.DatabasePatients;
            Staff = HASS.Staff;
            LoginCommand = new RelayCommand(Login, (s) => true);
            ExitApplicationCommand = new RelayCommand(ExitApplication, (s) => true);
        }
        public string LoginUsername { get; set; }
        public string LoginPassword { get; set; }
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
            set { _mainViewModel = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set { _patients = value; OnPropertyChanged(); }
        }
        public Account Staff
        {
            get { return _staff; }
            set { _staff = value; OnPropertyChanged(nameof(Staff)); }
        }
        public object LoginAccount
        {
            get { return _loginAccount; }
            set
            {
                _loginAccount = value; OnPropertyChanged(nameof(LoginAccount));
            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand ExitApplicationCommand { get; set; }
        private void Login(object obj)
        {
            if (LoginCheck())
            {
                MessageBox.Show($"Welcome {LoginUsername}!");
                if (LoginAccount.GetType().Name == "Patient")
                {
                    MainViewModel.CurrentViewModel = new PatientMainMenuViewModel(MainViewModel, LoginAccount);

                }
                else
                {
                    MainViewModel.CurrentViewModel = new MainMenuViewModel(MainViewModel, LoginAccount);
                }
            }
            else
            {
                MessageBox.Show("Account does not exist!");
            }
        }

        private bool LoginCheck()
        {
            if (Staff.Name == LoginUsername && Staff.ID == LoginPassword)
            {
                _loginAccount = Staff;
                return true;
            }
            foreach (var patient in Patients)
            {
                if (patient.Name == LoginUsername && patient.ID == LoginPassword)
                {
                    _loginAccount = patient;
                    return true;
                }
            }
            return false;
        }
        private void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
