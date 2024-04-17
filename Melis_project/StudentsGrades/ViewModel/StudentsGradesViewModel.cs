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
        
       
        public StudentsGradesViewModel()
        {
            
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            BackToMainWindowCommand = new RelayCommand(BackToMainWindow);
            AddStudentGradeCommand = new RelayCommand(AddStudentGrade);
            FilterByYearCommand = new RelayCommand(FilterByYear);
            FilterByFacultyNumberCommand = new RelayCommand(FilterByFacultyNumber);
            FilterBySubjectCommand = new RelayCommand(FilterBySubject);
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
        
     
        

        
        public ICommand FilterGradesCommand { get; }
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

        private int _filterYear;
        public int FilterYear
        {
            get { return _filterYear; }
            set
            {
                _filterYear = value;
                OnPropertyChanged();
            }
        }
        public ICommand FilterByYearCommand { get; }
        private void FilterByYear(object parameter)
        {
            if (FilterYear != 0)
            {
                Students = new ObservableCollection<StudentModel>(
                    StudentGradeService.FilterStudentsAndGradesByYear(FilterYear));
            }
            else
            {
                Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            }
        }

        private string _filterFacultyNumber;
        public string FilterFacultyNumber
        {
            get { return _filterFacultyNumber; }
            set
            {
                _filterFacultyNumber = value;
                OnPropertyChanged();
                FilterByFacultyNumberCommand.Execute(null);
            }
        }

        public ICommand FilterByFacultyNumberCommand { get; }

        private void FilterByFacultyNumber(object parameter)
        {
            if (!string.IsNullOrEmpty(FilterFacultyNumber))
            {
                Students = new ObservableCollection<StudentModel>(
                    StudentGradeService.FilterStudentsAndGradesByFacultyNumber(FilterFacultyNumber));
            }
            else
            {
                Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            }
        }

        private string _filterSubject;
        public string FilterSubject
        {
            get { return _filterSubject; }
            set
            {
                _filterSubject = value;
                OnPropertyChanged();
                FilterBySubjectCommand.Execute(null);
            }
        }
        public ICommand FilterBySubjectCommand { get; }

        private void FilterBySubject(object parameter)
        {
            if (!string.IsNullOrEmpty(FilterSubject))
            {
                Students = new ObservableCollection<StudentModel>(
                    StudentGradeService.FilterBySubject(FilterSubject));
            }
            else
            {
                Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            }
        }

        public ICommand ClearFiltersCommand { get; }

        private void ClearFilters(object parameter)
        {
            FilterYear = 0;
            FilterFacultyNumber = null;
            FilterSubject = null;
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
        }

    }



}

