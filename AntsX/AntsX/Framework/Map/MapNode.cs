using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AntsX.Framework.Map
{
    public class MapNode
    {
        public MapNode()
        {

        }

        public Texture2D TileImage
        {
            get;
            set;
        }

        public Vector2 TilePosition
        {
            get;
            set;
        }

    }
}
