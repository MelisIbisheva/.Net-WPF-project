﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Services
{
    public class FilterServices<T>
    {
        public static List<T> FilterByDifferentCriteria(IEnumerable<T> data, Func<T, bool> filterCriteria)
        {
            return data.Where(filterCriteria).ToList();
        }
        public static List<T> FilterBySubject<T>(List<T> items, Func<T, IEnumerable<string>> subjectAccessor, string filterSubject)
        {
            if (string.IsNullOrEmpty(filterSubject))
            {
                return new List<T>();
            }

            return items
              .Where(item => subjectAccessor(item).Any(subject => subject.Equals(filterSubject, StringComparison.OrdinalIgnoreCase)))
               .ToList();
        }

        public static List<T> FilterByYear<T>(List<T> items, Func<T, IEnumerable<int>> yearAccessor, int filterYear)
        {
            return items
                .Where(item => yearAccessor(item).Any(year => year == filterYear))
                .ToList();
        }




    }
}