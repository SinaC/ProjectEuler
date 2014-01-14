//http://www.alpertron.com.ar/ECM.HTM
//https://github.com/nayuki/Project-Euler-solutions

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ProjectEuler
{
    class Program
    {
        static private IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal));
        }

        static public void SolveAll(int limit = 1, bool runTooSlow = false)
        {
            using (StreamWriter sw = new StreamWriter("results.txt"))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                List<Type> types = GetTypesInNamespace(assembly, "ProjectEuler")
                    .Where(x => x.Name.StartsWith("Problem") && x.GetMethods().Any(y => y.Name == "Solve"))
                    .Select(x => new
                        {
                            number = Convert.ToInt32(x.Name.Substring(7)),
                            type = x
                        })
                    .Where(x => x.number >= limit)
                    .OrderBy(x => x.number)
                    .Select(x => x.type).ToList();
                foreach (Type type in types)
                {
                    object problem = assembly.CreateInstance(type.FullName);
                    MethodInfo solve = type.GetMethod("Solve");
                    UnderConstruction underConstruction = Attribute.GetCustomAttribute(solve, typeof (UnderConstruction)) as UnderConstruction;
                    TooSlow tooSlow = Attribute.GetCustomAttribute(solve, typeof (TooSlow)) as TooSlow;
                    if (underConstruction == null && (tooSlow == null || runTooSlow))
                    {
                        string result;
                        TimeSpan begin = Process.GetCurrentProcess().TotalProcessorTime;
                        if (solve.GetParameters().Length > 0)
                        {
                            string parameter = Path.Combine(@"D:\GitHub\ProjectEuler\Datas", String.Format("{0}.txt", type.Name.ToLower()));
                            result = solve.Invoke(problem, new object[] {parameter}).ToString();
                        }
                        else
                            result = solve.Invoke(problem, null).ToString();
                        TimeSpan end = Process.GetCurrentProcess().TotalProcessorTime;
                        Console.WriteLine("{0}: {1:0}ms -> {2}", type.Name, (end - begin).TotalMilliseconds, result);
                        sw.WriteLine("{0}: {1:0}ms -> {2}", type.Name, (end - begin).TotalMilliseconds, result);
                    }
                    else
                    {
                        Console.WriteLine("{0}: {1}", type.Name, underConstruction == null ? "too slow" : "under construction");
                        sw.WriteLine("{0}: {1}", type.Name, underConstruction == null ? "too slow" : "under construction");
                    }
                    sw.Flush();
                }
            }
        }

        static void Main(string[] args)
        {
            Problem358 problem = new Problem358();
            ulong result = problem.Solve();
            //SolveAll(runTooSlow:true);
        }
    }
}
