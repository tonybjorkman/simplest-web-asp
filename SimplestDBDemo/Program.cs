using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentName = "Billypopey" };
                var grade = ctx.Grades.FirstOrDefault();
                if (grade is null)
                {
                    grade = new Grade() { GradeName = "GoodForMe" };
                }
                stud.Grade = grade;
                ctx.Students.Add(stud);
                ctx.SaveChanges();

                var student = ctx.Students.Single(s => s.StudentName == "Billypopey");
                Console.WriteLine($"student {student.StudentName} grade: {student.Grade.GradeName} ");
                //Console.WriteLine($"num: {grade.Students.Count()}");
                stud.StudentName += "Saved";
                stud.Grade.GradeName += "x";
                ctx.SaveChanges();
            }

        }

    }
}
