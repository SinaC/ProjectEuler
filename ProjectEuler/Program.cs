﻿//http://www.alpertron.com.ar/ECM.HTM
//https://github.com/nayuki/Project-Euler-solutions
//https://github.com/l2y3n2/my-project-euler
//http://nayuki.eigenstate.org/page/project-euler-solutions
//http://eulersolutions.fr.yuku.com/forums/3/General?page=10#.Ut4tJtI1jqQ

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

        // TODO: use inheritance from Problem and abstract method Solve
        static public void SolveAll2(int limit = 1, bool runTooSlow = false)
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
                    try
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
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("{0}: exception {1}", type.Name, ex.ToString());
                        sw.WriteLine("{0}: exception {1}", type.Name, ex.ToString());
                    }
                    sw.Flush();
                }
            }
        }

        static public void SolveAll(bool runTooSlow = false)
        {
            using (StreamWriter sw = new StreamWriter("results.txt"))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type problemBaseType = typeof (ProblemBase);
                List<ProblemBase> problems = GetTypesInNamespace(assembly, "ProjectEuler")
                    .Where(x => x.IsSubclassOf(problemBaseType))
                    .Select(x => assembly.CreateInstance(x.FullName) as ProblemBase)
                    .OrderBy(x => x.Id).ToList();
                foreach(ProblemBase problem in problems)
                {
                    Type type = problem.GetType();
                    try
                    {
                        MethodInfo solve = type.GetMethod("Solve");
                        UnderConstruction underConstruction = Attribute.GetCustomAttribute(solve, typeof(UnderConstruction)) as UnderConstruction;
                        TooSlow tooSlow = Attribute.GetCustomAttribute(solve, typeof(TooSlow)) as TooSlow;
                        if (underConstruction == null && (tooSlow == null || runTooSlow))
                        {
                            string result;
                            TimeSpan begin = Process.GetCurrentProcess().TotalProcessorTime;
                            if (solve.GetParameters().Length > 0)
                            {
                                string parameter = Path.Combine(@"D:\GitHub\ProjectEuler\Datas", String.Format("{0}.txt", type.Name.ToLower()));
                                result = solve.Invoke(problem, new object[] { parameter }).ToString();
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
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0}: exception {1}", type.Name, ex);
                        sw.WriteLine("{0}: exception {1}", type.Name, ex);
                    }
                    sw.Flush();
                }
            }
        }

        static void Main(string[] args)
        {
            //Problem96 problem = new Problem96();
            //ulong result = problem.Solve(@"D:\GitHub\ProjectEuler\Datas\Problem96.txt");
            ProblemBase problem = new Problem216();
            string result = problem.Solve();
            //SolveAll();
        }
    }
}
