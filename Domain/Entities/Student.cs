using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : User
    {
        public ICollection<Grade> Grades { get; set; } = [];
        public ICollection<Payment> Payments { get; set; } = [];
        public ICollection<Exam> Exams { get; set; } = [];
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
    }
}
