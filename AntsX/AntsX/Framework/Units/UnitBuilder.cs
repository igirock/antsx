using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntsX.Framework.Units.Components.ComponentImplementation;
using AntsX.Framework.Units.Components;

namespace AntsX.Framework.Units
{
    public enum UnitEntityType
    {
        Cube,
    }

    public class UnitBuilder
    {
        protected IServiceProvider serviceProvider;
        public UnitBuilder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public UnitEntity CreateUnitEntity(UnitEntityType type)
        {
            UnitEntity e = null;
            switch (type)
            {
                case UnitEntityType.Cube: e = buildCube(); break;
                default: throw new ArgumentException("Unknown unit entity.");
            }

            return e;
        }

        protected UnitEntity buildCube()
        {
            UnitEntity e = new UnitEntity();
            UnitServices unitservices = new UnitServices();
            unitservices.AddService(typeof(IUnitEntityType), e);

            GraphicComponent graphic = new GraphicComponent(); // get provided services
            
            // init each component
            initializeComponent(graphic, unitservices);
            graphic.LoadContent();

            e.Components.Add(graphic);
            return e;
        }

        protected void initializeComponent(BaseUnitComponent component, UnitServices unitServices)
        {
            component.Initialize(unitServices, this.serviceProvider);
        }
    }
}
