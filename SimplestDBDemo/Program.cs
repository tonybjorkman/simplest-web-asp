using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tony.SimpleDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var ctx = new MyDbContext())
            {
                var itm = new Item() { Name = "Billypopey" };
                var grade = ctx.Grades.FirstOrDefault();
                if (grade is null)
                {
                    grade = new SubItem() { Name = "GoodForMe" };
                }
                itm.Grade = grade;
                ctx.Items.Add(itm);
                ctx.SaveChanges();

                var item = ctx.Items.Single(s => s.Name == "Billypopey");
                Console.WriteLine($"student {item.Name} grade: {item.Grade.Name} ");

                itm.Name += "Saved";
                itm.Grade.Name += "x";
                ctx.SaveChanges();
            }

        }

    }
}
