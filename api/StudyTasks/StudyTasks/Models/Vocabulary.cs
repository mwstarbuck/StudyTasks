using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyTasks.Models
{
    public class Vocabulary
    {
        public Guid Id { get; set; }
        public string Word { get; set; }
        public int GradeLevel { get; set; }
    }
}
