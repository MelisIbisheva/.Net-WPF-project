﻿using StudentsGrades.ViewModel;
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

namespace StudentsGrades.View
{
    /// <summary>
    /// Interaction logic for ViewStudentObjectWindow.xaml
    /// </summary>
    public partial class ViewStudentObjectWindow : Window
    {
        public ViewStudentObjectWindow()
        {
            InitializeComponent();
            DataContext = new StudentSubjectViewModel();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
