using System;

namespace DI.Web.Ex09.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
        public Type BindingType { get; set; }

        public InjectAttribute(Type bindingType)
        {
            BindingType = bindingType;
        }
    }
}