using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AntsX.Framework.Units.Components.ComponentImplementation
{
    public abstract class BaseDrawableUnitComponent : BaseUnitComponent
    {
        public BaseDrawableUnitComponent()
        {

        }

        public virtual void LoadContent()
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public virtual bool Visible
        {
            get;
            set;
        }

        public override abstract ComponentCategory Category
        {
            get;
        }
    }
}
