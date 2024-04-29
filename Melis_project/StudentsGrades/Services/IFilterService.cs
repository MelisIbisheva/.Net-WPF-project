using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Services
{
    /// <summary>
    /// Interface for filtering service.
    /// </summary>
    public interface IFilterService
    {
        /// <summary>
        /// Filters the data according to the provided parameter.
        /// </summary>
        /// <param name="parameter">Filter parameter (optional).</param>
        /// <remarks>
        /// When using different fields for filtering, filtering by year should be performed last.
        /// </remarks>
        void Filter(object parameter = null);
    }
}
