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
using System.Windows.Input;

namespace StudentsGrades.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _selectedStudentId;
        private string _selectedStudentFirstName;
        private string _selectedStudentLastName;
        private string _selectedStudentFacultyNumber;
       
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
       
 
        

       

       
        public ICommand OpenStudentGradesCommand { get; }
        public ICommand AddNewStudentCommand {  get; }
        private void OpenStudentGrades(object parameter)
        {
            
            var studentGradesWindow = new ViewStudentsGrades();
            studentGradesWindow.Show();
        }

        private void AddNewStudent(object parameter)
        {
            var addNewStudentWindow = new AddNewStudentWindow();
            addNewStudentWindow.Show();
        }

        public MainViewModel()
        {
            OpenStudentGradesCommand = new RelayCommand(OpenStudentGrades);
            Students = new ObservableCollection<StudentModel>(StudentGradeService.GetAllUsers());
            AddNewStudentCommand = new RelayCommand(AddNewStudent);

            
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
