using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntsX.Framework.Units
{
    public class UnitServices : IRequestUnitService
    {
        public UnitServices()
        {
            services = new Dictionary<Type, object>();
        }

        private Dictionary<Type, object> services;

        public T RequestService<T>()
        {
            return (T) this.services[typeof(T)];
        }

        public void AddService(Type type, object obj)
        {
            this.services.Add(type, obj);
        }

        public void AddService(List<Type> types, object obj)
        {
            foreach (Type t in types)
            {
                AddService(t, obj);
            }
        }

        public void ClearServices()
        {
            this.services.Clear();
        }
    }
}
