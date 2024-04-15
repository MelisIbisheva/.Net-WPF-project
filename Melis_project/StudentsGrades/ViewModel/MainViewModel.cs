using StudentsGrades.Command;
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
using System.Windows.Input;

namespace StudentsGrades.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StudentModel> _students;
        public ObservableCollection<StudentModel> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private List<GradeModel> _filteredGrades;
        public List<GradeModel> FilteredGrades
        {
            get { return _filteredGrades; }
            set
            {
                _filteredGrades = value;
                OnPropertyChanged();
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
                FilterGradesCommand.Execute(null);
            }
        }

        private int _filterYear;
        public int FilterYear
        {
            get { return _filterYear; }
            set
            {
                _filterYear = value;
                OnPropertyChanged();
                FilterGradesCommand.Execute(null);
            }
        }

        public ICommand FilterGradesCommand { get; }

        public MainViewModel()
        {
            FilterGradesCommand = new RelayCommand(FilterGrades);
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());

            
        }

       

        private void FilterGrades(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(FilterSubject))
            {
                FilteredGrades = StudentGradeService.FilterGrades(FilterSubject);
            }
            else
            {
                FilteredGrades = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
