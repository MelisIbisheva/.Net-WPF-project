using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using StudentsGrades.Command;
using StudentsGrades.Model;
using StudentsGrades.Services;

namespace StudentsGrades.ViewModel
{
    public class AddStudentGradeViewModel : INotifyPropertyChanged
    {
        private string _subject;
        private int _value;
        private int _year;
        private DateTime _date;
        private int _studentId;
        private string _message;
        public AddStudentGradeViewModel() {
            CloseWindowCommand = new RelayCommand(CloseWindow);
            AddGradeCommand = new RelayCommand(AddGrade);
        }

        public ICommand CloseWindowCommand { get; }
        private void CloseWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        public string Subject
        {
            get => _subject;
            set
            {
                _subject = value;
                OnPropertyChanged();
            }
        }

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public int StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
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
        public ICommand AddGradeCommand { get; }
        private void AddGrade(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Subject) || Value == 0 || Year == 0 || Date == default(DateTime) || StudentId == 0)
            {
                Message = "Please fill in all fields!";
                return;
            }
            else
            {

                var newGrade = new GradeModel
                {
                    Subject = Subject,
                    Value = Value,
                    Year = Year,
                    Date = Date,
                    StudentId = StudentId
                };

                StudentGradeService.AddGradeToStudent(StudentId, newGrade);
                Message = "Grade successfully added!";
                Subject = "";
                Value = 0;
                Year = 0;
                Date = DateTime.Now;
                StudentId = 0;
            }
             
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
