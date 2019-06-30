using System;
using System.Collections.Generic;

namespace Ecourse.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
        }

        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int CorrectAnswer { get; set; }
        public int ChapterId { get; set; }

        public Chapter Chapter { get; set; }
        public ICollection<Answers> Answers { get; set; }
    }
}
