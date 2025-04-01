using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = new Student();
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = new Teacher();
    }
}
