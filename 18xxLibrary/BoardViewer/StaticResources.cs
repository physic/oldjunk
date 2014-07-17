using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;

namespace BoardViewer
{
    public class StaticResourceHolder<T> : ResourceDictionary where T : StaticResourceHolder<T>
    {
        private static readonly T instance = Activator.CreateInstance<T>();

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        protected StaticResourceHolder()
        {
            foreach (FieldInfo info in typeof(T).GetFields())
            {
                this.Add(info.Name, info.GetValue(this));
            }
        }
    }
}
