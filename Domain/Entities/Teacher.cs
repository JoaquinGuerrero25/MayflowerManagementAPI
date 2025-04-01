using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teacher : User
    {
        public string? RegistrationNumber { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public decimal? Salary { get; set; }
        public ICollection<Grade> Grades { get; set; } = [];
        public ICollection<Course> Courses { get; set; } = [];
        public ICollection<Exam> Exams { get; set; } = [];
        public ICollection<Module> Modules { get; set; } = [];
    }
}
