using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CisiCsharpDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ITaskSet> tasks = new List<ITaskSet>();

            tasks.Add(new Tasks.ForCycleTaskSet());

            foreach(ITaskSet taskSet in tasks)
            {
                taskSet.Open();

                taskSet.Run();

                taskSet.Close();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
