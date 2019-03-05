using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if(Students.Count < 5)
                throw new InvalidOperationException("Ranked gradeing requires 5 or more students");

            int gradeStep = (int)Math.Ceiling(Students.Count * 0.2);

            List<Double> orderedList = Students.OrderByDescending(g => g.AverageGrade).Select(g => g.AverageGrade).ToList();

            if (orderedList[gradeStep - 1] <= averageGrade)
                return 'A';
            else if (orderedList[(gradeStep * 2) - 1] <= averageGrade)
                return 'B';
            else if (orderedList[(gradeStep * 3) - 1] <= averageGrade)
                return 'C';
            else if (orderedList[(gradeStep * 4) - 1] <= averageGrade)
                return 'D';


            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
