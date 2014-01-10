using System;

namespace ProjectEuler
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnderConstruction : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class TooSlow : Attribute
    {
    }
}
