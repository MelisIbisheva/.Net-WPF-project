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
using System.Xml.Linq;

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
                filteredStudents = FilterServices<StudentModel>.FilterByDifferentCriteria(filteredStudents, student => student.FacultyNumber == FilterFacultyNumber);
            }

            if (!string.IsNullOrEmpty(FilterSubject))
            {
                filteredStudents = FilterServices<StudentModel>.FilterBySubject(filteredStudents, student => student.Grades.Select(grade => grade.Subject), FilterSubject);
                foreach (var student in filteredStudents)
                {
                    // student.Grades = FilterServices<GradeModel>.FilterByDifferentCriteria(student.Grades, grade => grade.Subject == FilterSubject);
                    student.Grades = FilterServices<GradeModel>.FilterBySubject(student.Grades, grade => new List<string> { grade.Subject }, FilterSubject);
                }
            }
            if (FilterYear != 0)

            {
                filteredStudents = FilterServices<StudentModel>.FilterByYear(filteredStudents, student => student.Grades.Select(grade => grade.Year), FilterYear);
                foreach (var student in filteredStudents)
                {
                    student.Grades = FilterServices<GradeModel>.FilterByYear(student.Grades, grade => new List<int> { grade.Year }, FilterYear);

                }
              
            }
            Students = new ObservableCollection<StudentModel>(filteredStudents);
        }

        private int FindLastYearWithResults(IEnumerable<StudentModel> students)
        {
            return students.SelectMany(student => student.Grades).Max(grade => grade.Year);
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

