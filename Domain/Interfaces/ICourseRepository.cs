using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        IEnumerable<Course> GetCourseByTeacher(Guid id);
    }
}
