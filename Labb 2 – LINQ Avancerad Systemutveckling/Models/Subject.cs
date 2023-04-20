using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2___LINQ_Avancerad_Systemutveckling.Models
{
    internal class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
