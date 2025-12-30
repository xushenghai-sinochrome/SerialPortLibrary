using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AppInterfaces
{
    public class Appinterface
    {
        public string Information { get; set; }

        public static bool has_Field(object src, string name, Type TYPE)
        {
            try
            {
                if (src == null) return false;
                var propertyInfo = src.GetType().GetProperty(name);
                if (propertyInfo != null && propertyInfo.GetValue(src, null) != null)
                    return propertyInfo.GetValue(src, null).GetType() == TYPE;
            }
            catch (Exception) { }
            return false;
        }
        public static T GetField<T>(object src, string name)
        {
            try
            {
                if (src == null) return default(T);
                var propertyInfo = src.GetType().GetProperty(name);
                return (T)propertyInfo.GetValue(src, null);
            }
            catch (Exception) { }
            return default(T);
        }
        public static void SetField<T>(object src, string name, T value)
        {
            try
            {
                if (src == null) return;
                var propertyInfo = src.GetType().GetProperty(name);
                propertyInfo.SetValue(src, value, null);
            }
            catch (Exception) { }
            return;
        }
        public virtual bool hasProperty(string name, Type TYPE)
        {
            try
            {
                var propertyInfo = GetType().GetProperty(name);
                if (propertyInfo != null && propertyInfo.GetValue(this, null) != null)
                    return propertyInfo.GetValue(this, null).GetType() == TYPE;
            }
            catch(Exception){}
            return false;
        }
        public virtual T getProperty<T>(string name)
        {
            try
            {
                var propertyInfo = GetType().GetProperty(name);
                return (T)propertyInfo.GetValue(this, null);
            }
            catch (Exception) { }
            return default(T);
        }
        public virtual void setProperty<T>(string name, T value)
        {
            try
            {
                var propertyInfo = GetType().GetProperty(name);
                propertyInfo.SetValue(this, value, null);
            }
            catch (Exception) { }
            return;
        }

        public virtual void initialization(string information)
        {
            Information = information;
            initialize();
        }
        public virtual void initialize()
        {
            initData    ();
            initValue   ();
            initProperty();
            initConnect ();
        }
        public virtual void deinitialize()
        {
            deleConnect    ();
            deleProperty   ();
            deleValue      ();
            deleData       ();
        }
        public virtual void initData    () { }
        public virtual void initValue   () { }
        public virtual void initProperty() { }
        public virtual void initConnect () { }

        public virtual void deleData    () { }
        public virtual void deleValue   () { }
        public virtual void deleProperty() { }
        public virtual void deleConnect () { }

        public void From(object source)
        {
            if (source == null)
                return;
            if (object.ReferenceEquals(this, source))
                return;
            Type type = source.GetType();
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!property.CanWrite) continue;
                if (!hasProperty(property.Name, property.PropertyType)) continue;
                object value = property.GetValue(source);
                if (value == null || property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                {
                    property.SetValue(this, value);
                }
                else
                {
                    property.SetValue(this, DeepCopy(value));
                }
            }
        }

        public object Copy()
        {
            Type type = GetType();
            object target = DeepCopy(this);
            return target;
        }

        public static object DeepCopy(object source)
        {
            if (source == null) return null;
            Type type = source.GetType();
            object target = Activator.CreateInstance(type);

            // 遍历所有属性
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!property.CanWrite) continue;

                object value = property.GetValue(source);
                if (value == null || property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                {
                    property.SetValue(target, value);
                }
                else
                {
                    property.SetValue(target, DeepCopy(value));
                }
            }

            // 遍历所有字段
            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                object value = field.GetValue(source);
                if (value == null || field.FieldType.IsValueType || field.FieldType == typeof(string))
                {
                    field.SetValue(target, value);
                }
                else
                {
                    field.SetValue(target, DeepCopy(value));
                }
            }

            return target;
        }

    }
}
