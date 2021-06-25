using System;

namespace Eleventh
{
    public interface IDeepCloneable<T> where T : IDeepCloneable<T>, new()
    {
        T DeepClone()
        {
            var clone = new T();

            Initialize(this, clone);

            return clone;
        }

        private static void Initialize<TProperty>(TProperty instance, TProperty clone)
        {
            var type = typeof(TProperty);
            foreach (var prop in type.GetProperties())
            {
                if (prop.PropertyType.IsPrimitive)
                {
                    prop.SetValue(clone, prop.GetValue(instance));
                }
                else
                {
                    prop.SetValue(clone, Activator.CreateInstance<TProperty>());
                    Initialize(prop.GetValue(instance), prop.GetValue(clone));
                }
            }

            foreach (var field in type.GetFields())
            {
                if (field.FieldType.IsPrimitive)
                {
                    field.SetValue(clone, field.GetValue(instance));
                }
                else
                {
                    field.SetValue(clone, Activator.CreateInstance<TProperty>());
                    Initialize(field.GetValue(instance), field.GetValue(clone));
                }
            }
        }
    }
}