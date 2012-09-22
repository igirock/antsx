using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntsX.Framework.Units.Components
{
    public interface IComponentServiceProvider
    {
        List<Type> GetProvidedServices();
    }
}
