using System;
//теж чисто чатгпт
namespace dz04_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] subjects = { "Math", "Physics", "Chemistry", "Biology" };
            int[] grades = { 90, 85, 75, 80 };

            StudentGrades student = new StudentGrades(subjects, grades);
            student.MaxAndAverageGradesEvent += (subjectWithMaxGrade, maxGrade, averageGrade) =>
            {
                Console.WriteLine($"Subject with the highest grade: {subjectWithMaxGrade}");
                Console.WriteLine($"Max Grade: {maxGrade}");
                Console.WriteLine($"Average Grade: {averageGrade}");
            };

            student.CalculateMaxAndAverageGrades();
        }
    }
}