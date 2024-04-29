using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades.Services
{
    public interface IFilterService
    {
         void Filter(object parameter = null);
    }
}
