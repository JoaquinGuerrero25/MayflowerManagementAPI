using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = new Teacher();
        public decimal InstallmentPrice { get; set; }
        public decimal OverdueInstallmentPrice { get; set; }
        public DateTime InstallmentDueDate { get; set; }
        public ICollection<Grade> Grades { get; set; } = [];
        public ICollection<Payment> Payments { get; set; } = [];
        public ICollection<Student> Students { get; set; } = [];
        public ICollection<Exam> Exams { get; set; } = [];
        public ICollection<Module> Modules { get; set; } = [];
    }
}
