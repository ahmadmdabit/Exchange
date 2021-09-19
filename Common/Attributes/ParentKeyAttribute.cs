using System;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class ParentKeyAttribute : Attribute
    {
    }
}