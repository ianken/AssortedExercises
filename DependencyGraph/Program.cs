using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyGraph
{
    class Program
    {
        //given a list of classes that need to be taken
        //represented as integer pairs where the first int is
        //the dependecy and the second int is the class.
        //"0" signals no dependecy.

        public class DepNode
        {
            public int ClassID;
            public List<int> Dependencies;

            public DepNode(int classID, int dep)
            {
                ClassID = classID;
                Dependencies = new List<int>();
                Dependencies.Add(dep);
            }
        }
        
        static void Main(string[] args)
        {
            int[] test = null;

            //Valid case
            int[] data = { 0, 1, 0, 2, 3, 4, 1, 3 };
            //Two depth circular reference
            int[] data1 = { 0, 1, 0, 2, 3, 4, 5, 3, 2, 5 };
            //Unscheduled dependency
            int[] data2 = { 0, 1, 0, 2, 3, 4, 5, 3 };
            //Circular reference (4>-3 and 3->4)
            int[] data3 = { 0, 1, 0, 2, 3, 4, 4, 3 };
            //Two depth circular reference
            int[] data4 = { 0, 1,
                            0, 2,
                            3, 4,
                            5, 3,
                            4, 5 };

            test = data1;
            
            List<DepNode> classes = new List<DepNode>();

            for (int i= 0; i < test.Length-1; i+=2)
            {
                var tmpNode = new DepNode(test[i + 1],test[i]);
                classes.Add(tmpNode);
            }

            var result = ValidateList(classes);
        }
      
        static bool ValidateList(List<DepNode> classes)
        {
            foreach (DepNode n in classes)
            {
                if(!ValidateClass(n,classes,0))
                    return false;
            }

            return true;
        }

        static bool ValidateClass(DepNode d, List<DepNode> classes, int depth)
        {
            foreach (int i in d.Dependencies)
            {
                if (i == 0)
                    return true;

                //circular reference detection.
                //Simpler than keeping a list of visited nodes...
                if (depth > classes.Count)
                {
                    return false;
                }

                DepNode nextDep;

                try
                {
                    nextDep = classes.Where(c => c.ClassID == i).First();
                }
                catch
                {
                    return false; // The dependent class is not in the schedule
                }

                return ValidateClass(nextDep, classes, depth+1);
            }

            return true;
        }


    }
}
