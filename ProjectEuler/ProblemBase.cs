using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ProjectEuler
{
    public abstract class ProblemBase
    {
        public int Id { get; private set; }

        protected ProblemBase(int id)
        {
            Id = id;
        }

        public abstract string Solve();

        public bool IsUnderConstruction
        {
            get
            {
                MethodInfo info = GetType().GetMethod("Solve");
                return (Attribute.GetCustomAttribute(info, typeof(UnderConstruction)) as UnderConstruction) != null;
            }
        }

        public bool IsTooSlow
        {
            get
            {
                MethodInfo info = GetType().GetMethod("Solve");
                return (Attribute.GetCustomAttribute(info, typeof(TooSlow)) as TooSlow) != null;
            }
        }

        protected string Data
        {
            get
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        protected IEnumerable<string> Lines
        {
            get { return Data.Split('\n'); }
        }

        private string Path
        {
            get { return System.IO.Path.Combine(@"D:\GitHub\ProjectEuler\Datas", String.Format("Problem{0}.txt", Id)); }
        }
    }
}