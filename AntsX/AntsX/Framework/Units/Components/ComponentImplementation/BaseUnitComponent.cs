using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AntsX.Framework.Units.Components;

namespace AntsX.Framework.Units.Components.ComponentImplementation
{
    public abstract class BaseUnitComponent
    {
        /// <summary>
        /// Initializes the component, sets up the required services
        /// </summary>
        /// <param name="componentServices">The services provided by the other components of this unit</param>
        /// <param name="gameServices">The game services</param>
        public virtual void Initialize(IRequestUnitService componentServices, IServiceProvider gameServices)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual List<Type> GetProvidedServices()
        {
            List<Type> services = new List<Type>();

            return services;
        }

        public virtual bool Enabled
        {
            get;
            set;
        }

        public abstract ComponentCategory Category
        {
            get;
        }
    }

    public enum ComponentCategory
    {
        Graphic,
        Movement,
        Misc,
    }
}
