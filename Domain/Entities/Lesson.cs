using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool IsNew { get; set; } = true;
        public string Title { get; set; }
        public List<InCampusStudent> StudentsThatAttended { get; set; }
            = new List<InCampusStudent>();

        public Lesson(string title)
        {
            Title = title;
        }
    }
}
