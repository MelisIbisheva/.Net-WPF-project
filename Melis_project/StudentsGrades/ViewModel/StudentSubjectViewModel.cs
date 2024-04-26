using StudentsGrades.Command;
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
    public class StudentSubjectViewModel : INotifyPropertyChanged
    {
        private int _filterYear;
        private string _filterFacultyNumber;
        private ObservableCollection<StudentModel> _students;
         
        public ICommand FilterCommand { get; }
        public StudentSubjectViewModel()
        {
           
            FilterCommand = new RelayCommand(Filter);
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            FilterCommand = new RelayCommand(Filter);
            BackToMainWindowCommand = new RelayCommand(BackToMainWindow);
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

        private ObservableCollection<string> _uniqueSubjects;
        public ObservableCollection<string> UniqueSubjects
        {
            get { return _uniqueSubjects; }
            set
            {
                _uniqueSubjects = value;
                OnPropertyChanged();
            }
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
        private void Filter(object parameter)
        {
            var filteredStudents = StudentGradeService.GetAllUsers();
            if (!string.IsNullOrEmpty(FilterFacultyNumber))
            {
                filteredStudents = FilterServices<StudentModel>.FilterByDifferentCriteria(filteredStudents, student => student.FacultyNumber == FilterFacultyNumber);
            }
            if (FilterYear != 0)
            {
                filteredStudents = FilterServices<StudentModel>.FilterByYear(filteredStudents, student => student.Grades.Select(grade => grade.Year), FilterYear);
            }

            
            var uniqueSubjects = filteredStudents
                .SelectMany(student => student.Grades)
                .Where(grade => grade.Year == FilterYear)
                .Select(grade => grade.Subject)
                .Distinct()
                .ToList();

            UniqueSubjects = new ObservableCollection<string>(uniqueSubjects);

            Students = new ObservableCollection<StudentModel>(filteredStudents);
        }

        public ICommand ClearFiltersCommand { get; }
        private void ClearFilters(object parameter)
        {
            FilterYear = 0;
            FilterFacultyNumber = null;         
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            UniqueSubjects = null;

        }
        public ICommand BackToMainWindowCommand { get; }
        private void BackToMainWindow(object parameter)
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
