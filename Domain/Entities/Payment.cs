using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsOverdue { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = new Student();
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = new Course();
    }
}
