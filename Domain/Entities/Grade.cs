using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Grade : BaseEntity
    {
        public decimal Score { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsFinalized { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = new Teacher();
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = new Student();
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
    }
}
