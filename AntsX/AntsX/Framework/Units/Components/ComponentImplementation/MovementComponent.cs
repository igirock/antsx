using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using AntsX.Framework.Units.Components;

namespace AntsX.Framework.Units.Components.ComponentImplementation
{
    public class MovementComponent : BaseUnitComponent, IMovement
    {
        public MovementComponent()
        {

        }

        public override void Initialize(IRequestUnitService componentServices, IServiceProvider gameServices)
        {
            base.Initialize(componentServices, gameServices);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public bool IsMoving
        {
            get;
            private set;
        }

        public override ComponentCategory Category
        {
            get
            {
                return ComponentCategory.Movement;
            }
        }
    }
}
