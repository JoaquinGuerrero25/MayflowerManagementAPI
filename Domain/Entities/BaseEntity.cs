using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; } = new DateTime();
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string CreateBy { get; set; } = string.Empty;
        public string? UpdateBy { get; set; }
        public string? DeleteBy { get; set; }
    }
}
