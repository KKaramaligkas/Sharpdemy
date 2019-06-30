using System;
using System.Collections.Generic;

namespace Ecourse.Models
{
    public partial class Units
    {
        public Units()
        {
            Answers = new HashSet<Answers>();
            Chapter = new HashSet<Chapter>();
        }

        public int UnitId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Answers> Answers { get; set; }
        public ICollection<Chapter> Chapter { get; set; }
    }
}
