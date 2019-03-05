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

            int gradeStep = (int)Math.Ceiling(Students.Count * .02);

            List<Double> orderedList = Students.OrderByDescending(g => g.AverageGrade).Select(g => g.AverageGrade).ToList();

            if (orderedList[gradeStep - 1] < averageGrade)
                return 'A';
            else if (orderedList[(gradeStep * 2) - 1] < averageGrade)
                return 'B';
            else if (orderedList[(gradeStep * 3) - 1] < averageGrade)
                return 'C';
            else if (orderedList[(gradeStep * 4) - 1] < averageGrade)
                return 'D';


            return 'F';
        }
    }
}
