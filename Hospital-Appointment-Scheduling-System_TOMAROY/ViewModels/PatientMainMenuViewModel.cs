using Hospital_Appointment_Scheduling_System_TOMAROY.Commands;
using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class PatientMainMenuViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private object _currentView;
        private object _currentAccount;
        private static object Account;
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
        public object AccountType { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand AppointmentSchedulingCommand { get; set; }
        public ICommand MyAppointmentCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitApplicationCommand { get; set; }
        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void AppointmentScheduling(object obj) => CurrentView = new AppointmentSchedulingViewModel();
        private void MyAppointment(object obj) => CurrentView = new MyAppointmentsViewModel();
        private void Logout(object obj)
        {
            MainViewModel.CurrentViewModel = new LoginViewModel(MainViewModel);
        }
        public PatientMainMenuViewModel(MainViewModel mainViewModel, object currentAccount)
        {
            HomeCommand = new RelayCommand(Home, (s) => true);
            AppointmentSchedulingCommand = new RelayCommand(AppointmentScheduling, (s) => true);
            MyAppointmentCommand = new RelayCommand(MyAppointment, (s) => true);
            ExitApplicationCommand = new RelayCommand(ExitApplication, (s) => true);
            LogoutCommand = new RelayCommand(Logout, (s) => true);
            _mainViewModel = mainViewModel;
            _currentAccount = currentAccount;
            Account = currentAccount;
            AccountType = currentAccount.GetType().Name;
            CurrentView = new HomeViewModel();
        }
        public static object GetAccount()
        {
            return Account;
        }
        private void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
