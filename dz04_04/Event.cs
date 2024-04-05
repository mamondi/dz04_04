using System;
using System.Linq;

namespace dz04_04
{
    public delegate void MaxAndAverageGradesEventHandler(string subjectWithMaxGrade, int maxGrade, int averageGrade);

    public class StudentGrades
    {
        private readonly string[] subjects;
        private readonly int[] grades;

        public event MaxAndAverageGradesEventHandler MaxAndAverageGradesEvent;

        public StudentGrades(string[] subjects, int[] grades)
        {
            if (subjects.Length != grades.Length)
                throw new ArgumentException("The number of subjects must match the number of grades.");

            this.subjects = subjects;
            this.grades = grades;
        }

        public void CalculateMaxAndAverageGrades()
        {
            int maxGradeIndex = Array.IndexOf(grades, grades.Max());
            int averageGrade = (int)grades.Average();

            MaxAndAverageGradesEvent?.Invoke(subjects[maxGradeIndex], grades[maxGradeIndex], averageGrade);
        }
    }
}