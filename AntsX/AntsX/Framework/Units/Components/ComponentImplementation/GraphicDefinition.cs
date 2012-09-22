using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using AntsX.Framework.Basic;

namespace AntsX.Framework.Units.Components.ComponentImplementation
{
    public class GraphicDefinition
    {
        public GraphicDefinition()
        {
            
        }

        public Texture2D OverviewTexture2DWalk
        {
            get;
            set;
        }

        public Texture2D OverviewTexture2DBite
        {
            get;
            set;
        }

        public Texture2D OverviewTexture2DDeath
        {
            get;
            set;
        }

        public Size SpriteSize
        {
            get;
            set;
        }

        public int WalkSprites
        {
            get;
            set;
        }

        public Model Model
        {
            get;
            set;
        }

        public Rectangle GetSourceRectangleWalk(int index)
        {
            if (index < this.WalkSprites)
            {
                switch (index)
                {
                    case 0: return new Rectangle(0, 0, 256, 256);
                    case 1: return new Rectangle(256, 0, 256, 256);
                    case 2: return new Rectangle(512, 0, 256, 256);
                    case 3: return new Rectangle(0, 256, 256, 256);
                    case 4: return new Rectangle(256, 256, 256, 256);
                    case 5: return new Rectangle(512, 256, 256, 256);
                    default: throw new IndexOutOfRangeException();
                }
            }
            else throw new IndexOutOfRangeException();
        }
    }
}
