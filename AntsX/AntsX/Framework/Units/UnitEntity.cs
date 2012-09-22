using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntsX.Framework.Units.Components.ComponentImplementation;
using AntsX.Framework.Units.Components;

namespace AntsX.Framework.Units
{
    /// <summary>
    /// Serves as a container during (and only during) the construction of a new UnitEntity
    /// </summary>
    public class UnitEntity: IUnitEntityType
    {
        public UnitEntity()
        {
            this.Components = new List<BaseUnitComponent>();
        }

        public List<BaseUnitComponent> Components
        {
            get;
            set;
        }

        public UnitEntityType UnitEntityType
        {
            get;
            set;
        }
    }
}
