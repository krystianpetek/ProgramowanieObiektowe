using System;

namespace CS_MSDN_Inheritance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WorkItem item = new WorkItem("Fix Bugs", "Fix all bugs in my code branch", new TimeSpan(3, 4, 0, 0));
            ChangeRequest change = new ChangeRequest("Change Base Class Design", "Add members to the class", new TimeSpan(4, 0, 0), 1);

            Console.WriteLine(item.ToString());
            change.Update("Change the Design of the Base Class", new TimeSpan(4, 0, 0));

            Console.WriteLine(change.ToString());
        }
    }
}