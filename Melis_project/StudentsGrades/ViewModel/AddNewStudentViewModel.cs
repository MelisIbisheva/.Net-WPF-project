﻿using StudentsGrades.Command;
using StudentsGrades.Model;
using StudentsGrades.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentsGrades.ViewModel
{
    public class AddNewStudentViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _facultyNumber;
        private string _message;

        public AddNewStudentViewModel() {

            AddStudentCommand = new RelayCommand(AddStudent);
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string FacultyNumber
        {
            get => _facultyNumber;
            set
            {
                _facultyNumber = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddStudentCommand { get; }
        private void AddStudent(object parameter)
        {
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(FacultyNumber))
            {
                // Check if the student already exists
                if (StudentGradeService.StudentExists(FacultyNumber))
                {
                    Message = "The student already exists!";
                }
                else
                {
                    // The student doesn't exist, add to the database
                    var student = new StudentModel
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        FacultyNumber = FacultyNumber
                    };

                    
                    StudentGradeService.AddStudent(student);
                    Message = "Student successfully added!";
                    FirstName = "";
                    LastName = "";
                    FacultyNumber = "";
                    
                }
            }
            else
            {
                Message = "Please fill in all fields to add a student!";
            }
            var mainViewModel = Application.Current.MainWindow.DataContext as MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            }

        }

        public ICommand CloseWindowCommand { get; }
        private void CloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
