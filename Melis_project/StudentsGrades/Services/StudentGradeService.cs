﻿using Microsoft.EntityFrameworkCore;
using StudentsGrades.Database;
using StudentsGrades.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Services
{
    public class StudentGradeService
    {
        public static List<StudentModel> GetAllUsers()
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                return ctx.Students.Include(s => s.Grades).ToList();
            }
        }

        public static void AddStudent(StudentModel student)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }

        public static void AddGradeToStudent(int studentId, GradeModel grade)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                var student = ctx.Students.Include(s => s.Grades).FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    student.Grades.Add(grade);
                    ctx.SaveChanges();
                }
            }
        }

        public static bool StudentExists(string facultyNumber)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
               
                return ctx.Students.Any(s => s.FacultyNumber == facultyNumber);
            }
        }
/*
        public static List<StudentModel> FilterStudentsAndGradesByYear(int year)
        {
            return GetAllUsers()
                .Select(student =>
                {
                    student.Grades = student.Grades
                        .Where(grade => grade.Date.Year == year)
                        .ToList();
                    return student;
                })
                .Where(student => student.Grades.Any())
                .ToList();
        }

        public static List<StudentModel> FilterStudentsAndGradesByFacultyNumber(string facultyNumber)
        {
            return GetAllUsers()
                .Where(student => student.FacultyNumber == facultyNumber)
                .ToList();
        }

        public static List<StudentModel> FilterBySubject(string subject)
        {
           
            return GetAllUsers()
                .Select(student =>
                {
                    student.Grades = student.Grades
                        .Where(grade => grade.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    return student;
                })
                .Where(student => student.Grades.Any()) 
                .ToList();
        }
*/





    }

}
