using System;
using System.IO;
using System.Reflection;

namespace ProjectEuler
{
    public abstract class Problem
    {
        public int Id { get; private set; }

        protected Problem(int id)
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

        private string Path
        {
            get { return System.IO.Path.Combine(@"D:\GitHub\ProjectEuler\Datas", String.Format("Problem{0}.txt", Id)); }
        }
    }
}