using System;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class IncludeAttribute : Attribute
    {
        public string[] NavigationPropertyPath { get; set; }

        public IncludeAttribute(params string[] navigationPropertyPath)
        {
            this.NavigationPropertyPath = navigationPropertyPath;
        }
    }
}