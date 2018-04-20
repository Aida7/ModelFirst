using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentGroupContainer())
            {
                var transaction = context.Database.BeginTransaction();

                try
                {
                    context.StudentSet.Add(new Student { Name = "Andrey",GroupId=1 });
                    context.SaveChanges();
                    context.GroupSet.Add(new Group { Name = "SDB-12" });
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
