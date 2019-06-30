using System;
using System.Collections.Generic;

namespace Ecourse.Models
{
    public partial class TestResults
    {
        public int TestId { get; set; }
        public double Score { get; set; }
        public DateTime Date { get; set; }
        public int ChapterId { get; set; }
        public int UnitId { get; set; }

        public Chapter Chapter { get; set; }
        public Units Unit { get; set; }
    }
}
