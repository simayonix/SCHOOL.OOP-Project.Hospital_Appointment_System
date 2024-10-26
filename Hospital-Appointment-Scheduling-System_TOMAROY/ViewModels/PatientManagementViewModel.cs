using Hospital_Appointment_Scheduling_System_TOMAROY.Commands;
using Hospital_Appointment_Scheduling_System_TOMAROY.Models;
using Hospital_Appointment_Scheduling_System_TOMAROY.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System_TOMAROY.ViewModels
{
    public class PatientManagementViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        private Patient _selectedPatient;
        private bool _isAddPatientPanelVisible;
        private bool _isPatientInformationVisible;
        private bool _isEditButtonChecked;
        private string _id;
        private string _name;
        private string _contactNumber;
        private string _medicalHistory;
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();
        public bool IsPatientInformationVisible
        {
            get { return _isPatientInformationVisible; }
            set { _isPatientInformationVisible = value; OnPropertyChanged(nameof(IsPatientInformationVisible)); }
        }
        public bool IsAddPatientPanelVisible
        {
            get { return _isAddPatientPanelVisible; }
            set {  _isAddPatientPanelVisible = value; OnPropertyChanged(nameof(IsAddPatientPanelVisible)); }
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
        public ICommand ShowAddPatientCommand { get; set; }
        public ICommand HideAddPatientCommand { get; set; }
        public ICommand AddPatientCommand { get; set; }
        public ICommand ShowEditPatientCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
        public ICommand RemovePatientCommand { get; set; }
        public MainViewModel MainViewModel
        {
            get { return  _mainViewModel; }
            set { _mainViewModel= value; OnPropertyChanged(nameof(MainViewModel)); }
        }
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
                ShowPatientInformation();
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
        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; OnPropertyChanged(nameof(ContactNumber)); }
        }
        public string MedicalHistory
        {
            get { return _medicalHistory; }
            set { _medicalHistory = value; OnPropertyChanged(nameof(MedicalHistory)); }
        }
        public PatientManagementViewModel()
        {
            IsAddPatientPanelVisible= false;
            IsPatientInformationVisible= false;
            IsEditButtonChecked = false;
            Patients = HASS.DatabasePatients;
            //CurrentAccount = MainMenuViewModel.GetCurrentAccount();
            //MainViewModel = mainViewModel;
            ShowAddPatientCommand = new RelayCommand(ShowAddPatient, (s) => true);
            HideAddPatientCommand = new RelayCommand(HideAddPatient, (s)=> true);
            AddPatientCommand = new RelayCommand(AddPatient, (s)=> true);
            ShowEditPatientCommand = new RelayCommand(EditPatient, (s) => true);
            SaveEditCommand = new RelayCommand(SaveEditPatient, (s) => true);
            RemovePatientCommand = new RelayCommand(RemovePatient, (s) => true);
        }
        private void ShowPatientInformation()
        {
            if (SelectedPatient != null)
            {
                IsAddPatientPanelVisible = false;
                IsPatientInformationVisible = false;
                Task.Delay(200).ContinueWith(_ =>
                {
                    IsPatientInformationVisible = true;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        private void ShowAddPatient(object obj)
        {
            SelectedPatient = null;
            IsAddPatientPanelVisible = true;
            IsPatientInformationVisible = false;
        }
        private void HideAddPatient(object obj)
        {
            IsAddPatientPanelVisible = false;
        }
        private void AddPatient(object obj)
        {
            if (Name != null && ContactNumber != null && MedicalHistory != null)
            {
                Patient newPatient = new(Name, ContactNumber, MedicalHistory);
                HASS.AddPatient(newPatient);
                MessageBox.Show($"{Name} has been added to the database");
                IsAddPatientPanelVisible = false;
                Name = null;
                ID = null;
                ContactNumber = null;
                MedicalHistory = null;
            }
            else
            {
                MessageBox.Show("Please ensure you have entered the correct information.");
            }
        }
        private void EditPatient(object obj)
        {
            MessageBox.Show("Edit ENABLED!!");
        }
        private void SaveEditPatient(object obj)
        {
            IsEditButtonChecked = false;
            MessageBox.Show("Changes saved");
        }
        private void RemovePatient(object obj)
        {
            HASS.RemovePatient(SelectedPatient);
        }
    }
}
