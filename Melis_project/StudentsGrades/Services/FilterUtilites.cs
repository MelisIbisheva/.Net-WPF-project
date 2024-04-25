using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Services
{
    public static class FilterUtilities
    {
        public static List<TProperty> FilterByProperty<TItem, TProperty>(
            IEnumerable<TItem> items,
            Func<TItem, IEnumerable<TProperty>> propertySelector,
            Func<TProperty, bool> filter)
        {
            return items
                .Where(item => propertySelector(item).Any(filter))
                .SelectMany(item => propertySelector(item).Where(filter))
                .ToList();
        }
    }
}
