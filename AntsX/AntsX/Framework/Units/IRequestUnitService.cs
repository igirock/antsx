using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntsX.Framework.Units
{
    public interface IRequestUnitService
    {
        T RequestService<T>();
    }
}
