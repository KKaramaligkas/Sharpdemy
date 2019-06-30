using System;
using System.Collections.Generic;

namespace Ecourse.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Questions = new HashSet<Questions>();
            TestResults = new HashSet<TestResults>();
        }

        public int ChapterId { get; set; }
        public string Title { get; set; }
        public int UnitId { get; set; }
        public string Video { get; set; }
        public string Content { get; set; }

        public Units Unit { get; set; }
        public ICollection<Questions> Questions { get; set; }
        public ICollection<TestResults> TestResults { get; set; }
    }
}
