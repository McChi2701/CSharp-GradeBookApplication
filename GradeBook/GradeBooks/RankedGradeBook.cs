using GradeBook.Enums;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    { 
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            return 'F';
            else
            {
                int gradeCount = 0;
                //for(int x = 0, x <= Students.Count, x++)
                foreach (var student in Students)
                {
                    if (averageGrade >= student.AverageGrade)
                    {
                        gradeCount ++;
                    }
                }

                if ((decimal)(gradeCount) >= (decimal)(0.8 * (Students.Count - 1)))
                {
                    return 'A';
                }
                else if ( (decimal)(gradeCount) >= (decimal)(0.6 * (Students.Count - 1)))
                //else if ((decimal)(gradeCount / Students.Count) >=  (decimal)(0.6))
                {
                    return 'B';
                }
                else if ((decimal)(gradeCount) >= (decimal)(0.4 * (Students.Count - 1)))
                {
                    return 'D';
                }
                else if ((decimal)(gradeCount) >= (decimal)(0.2 * (Students.Count - 1)))
                {
                    return 'E';
                }
                else
                {
                    return 'F';
                }

                //Below is answer from video -> above is my answer
                /*var threshold = (int)Math.Ceiling(Students.Count * 0.2);
                var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                if(grades[threshold-1] <= averageGrade)
                {
                    return 'A';
                }
                else if(grades[(threshold*2) - 1] <= averageGrade)
                {
                    return 'B';
                }
                else if (grades[(threshold * 3) - 1] <= averageGrade)
                {
                    return 'C';
                }
                else if (grades[(threshold * 4) - 1] <= averageGrade)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }*/
            }
        }
    }
}
