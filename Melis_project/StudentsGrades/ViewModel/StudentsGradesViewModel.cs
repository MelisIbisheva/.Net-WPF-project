﻿using StudentsGrades.Command;
using StudentsGrades.Model;
using StudentsGrades.Services;
using StudentsGrades.View;
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
    public class StudentsGradesViewModel : INotifyPropertyChanged
    {
        private int _selectedStudentId;
        private string _selectedStudentFirstName;
        private string _selectedStudentLastName;
        private string _selectedStudentFacultyNumber;
        private string _selectedGradeSubject;
        private int _selectedGradeValue;
        private DateTime _selectedGradeDate;
        private int _selectedGradeYear;
        private ObservableCollection<StudentModel> _students;
        private int _filterYear;
        private string _filterFacultyNumber;
        private string _filterSubject;


        public StudentsGradesViewModel()
        {
            
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            BackToMainWindowCommand = new RelayCommand(BackToMainWindow);
            AddStudentGradeCommand = new RelayCommand(AddStudentGrade);
            FilterCommand = new RelayCommand(Filter);
            ClearFiltersCommand = new RelayCommand(ClearFilters);
           

        }

        public ObservableCollection<StudentModel> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public int SelectedStudentId
        {
            get { return _selectedStudentId; }
            set
            {
                _selectedStudentId = value;
                OnPropertyChanged();
            }
        }

        public string SelectedStudentFirstName
        {
            get { return _selectedStudentFirstName; }
            set
            {
                _selectedStudentFirstName = value;
                OnPropertyChanged();
            }
        }

        public string SelectedStudentLastName
        {
            get { return _selectedStudentLastName; }
            set
            {
                _selectedStudentLastName = value;
                OnPropertyChanged();
            }
        }

        public string SelectedStudentFacultyNumber
        {
            get { return _selectedStudentFacultyNumber; }
            set
            {
                _selectedStudentFacultyNumber = value;
                OnPropertyChanged();
            }
        }

        public string SelectedGradeSubject
        {
            get { return _selectedGradeSubject; }
            set
            {
                _selectedGradeSubject = value;
                OnPropertyChanged();
            }
        }

        public int SelectedGradeValue
        {
            get { return _selectedGradeValue; }
            set
            {
                _selectedGradeValue = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedGradeDate
        {
            get { return _selectedGradeDate; }
            set
            {
                _selectedGradeDate = value;
                OnPropertyChanged();
            }
        }

        public int SelectedGradeYear
        {
            get { return _selectedGradeYear; }
            set
            {
                _selectedGradeYear = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
     
        public ICommand BackToMainWindowCommand { get; }
        private void BackToMainWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        public ICommand AddStudentGradeCommand { get; }

        private void AddStudentGrade(object parameter)
        {
            var addStudentGradeWindow = new AddStudentGradeWindow();
            addStudentGradeWindow.ShowDialog();
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
        }


        public int FilterYear
        {
            get { return _filterYear; }
            set
            {
                _filterYear = value;
                OnPropertyChanged();
            }
        }

        public string FilterFacultyNumber
        {
            get { return _filterFacultyNumber; }
            set
            {
                _filterFacultyNumber = value;
                OnPropertyChanged();
            }
        }

        public string FilterSubject
        {
            get { return _filterSubject; }
            set
            {
                _filterSubject = value;
                OnPropertyChanged();
            }
        }

        public ICommand FilterCommand { get; }
        private void Filter(object parameter)
        {
            var filteredStudents = StudentGradeService.GetAllUsers();

            

            if (!string.IsNullOrEmpty(FilterFacultyNumber))
            {
                filteredStudents = filteredStudents.Where(student => student.FacultyNumber == FilterFacultyNumber).ToList();
            }

            if (!string.IsNullOrEmpty(FilterSubject))
            {
                filteredStudents = filteredStudents.Where(student => student.Grades.Any(grade => grade.Subject == FilterSubject)).ToList();
            }
            if (FilterYear != 0)
                
            {
                bool isFilterYearContained = filteredStudents.Any(student => student.Grades.Any(grade => grade.Year == FilterYear));
                if (isFilterYearContained)
                {
                    filteredStudents = filteredStudents.Where(student => student.Grades.Any(grade => grade.Year == FilterYear)).ToList();
                }
                else
                {
                    int lastYearWithResults = FindLastYearWithResults(StudentGradeService.GetAllUsers(), FilterFacultyNumber, FilterSubject);
                    
                    filteredStudents = filteredStudents.Where(student => student.Grades.Any(grade => grade.Year == lastYearWithResults)).ToList();
                }
            }

            

            Students = new ObservableCollection<StudentModel>(filteredStudents);
        }

        public ICommand ClearFiltersCommand { get; }
        private void ClearFilters(object parameter)
        {
            FilterYear = 0;
            FilterFacultyNumber = null;
            FilterSubject = null;
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
        }

        private int FindLastYearWithResults(IEnumerable<StudentModel> students, string facultyNumber = null, string subject = null)
        {
            var filteredStudents = students;

            if (!string.IsNullOrEmpty(facultyNumber))
            {
                filteredStudents = filteredStudents.Where(student => student.FacultyNumber == facultyNumber).ToList();
            }

            if (!string.IsNullOrEmpty(subject))
            {
                filteredStudents = filteredStudents.Where(student => student.Grades.Any(grade => grade.Subject == subject)).ToList();
            }

            int lastYear = filteredStudents.SelectMany(student => student.Grades).Max(grade => grade.Year);
            return lastYear;
        }
       



    }



}

