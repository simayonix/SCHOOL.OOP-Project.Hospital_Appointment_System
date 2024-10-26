using Hospital_Appointment_Scheduling_System_TOMAROY.Commands;
using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using Hospital_Appointment_Scheduling_System_TOMAROY.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private Account _staff;
        private object _currentView;
        private object _currentAccount;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value; OnPropertyChanged(nameof(CurrentView));
            }
        }
        public MainViewModel MainViewModel
        {
            get => _mainViewModel;
            set
            {
                _mainViewModel = value; OnPropertyChanged(nameof(MainViewModel));
            }
        }
        public object CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value; OnPropertyChanged(nameof(CurrentAccount));
            }
        }
        public Account Staff
        {
            get { return _staff; }
            set { _staff = value; OnPropertyChanged(nameof(Staff)); }
        }
        public object AccountType { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand PatientManagementCommand { get; set; }
        public ICommand DoctorManagementCommand { get; set; }
        public ICommand AppointmentManagementCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitApplicationCommand { get; set; }
        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void PatientManagement(object obj) => CurrentView = new PatientManagementViewModel();
        private void DoctorManagement(object obj) => CurrentView = new DoctorManagementViewModel();
        private void AppointmentManagement(object obj) => CurrentView = new AppointmentManagementViewModel();
        private void Logout(object obj)
        {
            MainViewModel.CurrentViewModel = new LoginViewModel(MainViewModel);
        }
        private void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }
        public MainMenuViewModel(MainViewModel mainViewModel, object currentAccount)
        {
            HomeCommand = new RelayCommand(Home, (s) => true);
            PatientManagementCommand = new RelayCommand(PatientManagement, (s) => true);
            DoctorManagementCommand = new RelayCommand(DoctorManagement, (s) => true);
            AppointmentManagementCommand = new RelayCommand(AppointmentManagement, (s) => true);
            LogoutCommand = new RelayCommand(Logout, (s) => true);
            ExitApplicationCommand = new RelayCommand(ExitApplication, (s) => true);
            Staff = HASS.Staff;
            _mainViewModel = mainViewModel;
            _currentAccount = currentAccount;
            AccountType = currentAccount.GetType().Name;
            CurrentView = new HomeViewModel();
        }
        //public static object GetCurrentAccount()
        //{
        //    return CurrentAccount;
        //}
    }
}
