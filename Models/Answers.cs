using System;
using System.Collections.Generic;

namespace Ecourse.Models
{
    public partial class Answers
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public bool IsCorrect { get; set; }
        public int Score { get; set; }
        public bool IsRevision { get; set; }

        public Questions Question { get; set; }
        public Units Unit { get; set; }
        public Users User { get; set; }
    }
}
