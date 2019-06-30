using System;
using System.Collections.Generic;

namespace Ecourse.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Questions = new HashSet<Questions>();
        }

        public int ChapterId { get; set; }
        public string Title { get; set; }
        public int UnitId { get; set; }
        public int ChapterFormat { get; set; }
        public string Content { get; set; }

        public Units Unit { get; set; }
        public ICollection<Questions> Questions { get; set; }
    }
}
