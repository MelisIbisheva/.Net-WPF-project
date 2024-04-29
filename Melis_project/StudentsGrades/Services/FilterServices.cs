using System;
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
        public static List<T> FilterByStringParameter<T>(List<T> items, Func<T, IEnumerable<string>> subjectAccessor, string filterParameter)
        {
            if (string.IsNullOrEmpty(filterParameter))
            {
                return new List<T>();
            }

            return items
              .Where(item => subjectAccessor(item).Any(subject => subject.Equals(filterParameter, StringComparison.OrdinalIgnoreCase)))
               .ToList();
        }

        public static List<T> FilterByYear<T>(List<T> items, Func<T, IEnumerable<int>> yearAccessor, int filterYear)
        {
            var filtered =  items
                .Where(item => yearAccessor(item).Any(year => year == filterYear))
                .ToList();
           
            if (filtered.Count == 0)
            {
                int lastYear = GetLastYearWithResult(items, yearAccessor);
                filtered = items
                    .Where(item => yearAccessor(item).Any(year => year == lastYear))
                    .ToList();
            }
            return filtered;
        }
         private static int GetLastYearWithResult<T>(List<T> items, Func<T, IEnumerable<int>> yearAccessor)
        {
            return items.SelectMany(item => yearAccessor(item)).Max();
        }




    }
}
