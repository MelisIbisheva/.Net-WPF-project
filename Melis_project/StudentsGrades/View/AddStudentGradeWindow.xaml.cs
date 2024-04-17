using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentsGrades.ViewModel;

namespace StudentsGrades.View
{
    /// <summary>
    /// Interaction logic for AddStudentGradeWindow.xaml
    /// </summary>
    public partial class AddStudentGradeWindow : Window
    {
        public AddStudentGradeWindow()
        {
            InitializeComponent();
            DataContext = new AddStudentGradeViewModel();
        }
    }
}
