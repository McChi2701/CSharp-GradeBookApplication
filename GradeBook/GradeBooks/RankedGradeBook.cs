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
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            else
            {
                // My code using foreach but my calc for their ranking sucks balls and doesn't work..but it should
                /*int gradeCount = 0;
                foreach (var student in Students)
                {
                    if (averageGrade >= student.AverageGrade)
                    {
                        gradeCount ++;
                    }
                }
                gradeCount++;
                gradeCount = (gradeCount / Students.Count);
                if (gradeCount >= 0.8)
                {
                    return 'A';
                }
                else if (gradeCount >= 0.6)
                {
                    return 'B';
                }
                else if (gradeCount >= 0.4)
                {
                    return 'D';
                }
                else if (gradeCount >= 0.2)
                {
                    return 'E';
                }
                else
                {
                    return 'F';
                }*/

                //Below is answer from video -> above is my answer
                var threshold = (int)Math.Ceiling(Students.Count * 0.2);
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
                }
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
