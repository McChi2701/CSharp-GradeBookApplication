using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook
    {
        public override char LetterGrade
        {
            get
            {
                if (averageGrade.Count < 5)
                {
                    InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
                }
                return 'F';
            }
        }
    }
}
 