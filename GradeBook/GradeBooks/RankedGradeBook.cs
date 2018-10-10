using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook
    {
        public override char GetLetterGrade(double averageGrade)
        {
             if (Student.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            return 'F';
        }
    }
}
