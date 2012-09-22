using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using AntsX.Framework.Units.Components.ComponentImplementation;
using Microsoft.Xna.Framework.Graphics;

namespace AntsX.Framework.Units
{
    public static class UnitContentManager
    {
        public static void Init(Game game)
        {
            contentManager = new ContentManager(game.Services, "Content\\Models");
        }

        private static ContentManager contentManager;

        public static GraphicDefinition LoadGraphicDefinition(UnitEntityType unit)
        {
            GraphicDefinition def = new GraphicDefinition();
            switch (unit)
            {
                case UnitEntityType.Cube:
                    def.Model = contentManager.Load<Model>("cubealpha");
                    break;
                //case UnitEntityType.Worker:
                //    def.OverviewTexture2DWalk = contentManager.Load<Texture2D>("AntWalk");
                //    def.OverviewTexture2DBite = contentManager.Load<Texture2D>("AntBite");
                //    def.OverviewTexture2DDeath = contentManager.Load<Texture2D>("AntDeath");
                //    def.SpriteSize = new Basic.Size(256, 256);
                //    def.WalkSprites = 6;
                //    break;
                //case UnitEntityType.Soldier:
                //    def.OverviewTexture2DWalk = contentManager.Load<Texture2D>("AntWalk");
                //    def.OverviewTexture2DBite = contentManager.Load<Texture2D>("AntBite");
                //    def.OverviewTexture2DDeath = contentManager.Load<Texture2D>("AntDeath");
                //    def.SpriteSize = new Basic.Size(256, 256);
                //    def.WalkSprites = 6;
                //    break;
                //case UnitEntityType.Breeder:
                //    def.OverviewTexture2DWalk = contentManager.Load<Texture2D>("AntWalk");
                //    def.OverviewTexture2DBite = contentManager.Load<Texture2D>("AntBite");
                //    def.OverviewTexture2DDeath = contentManager.Load<Texture2D>("AntDeath");
                //    def.SpriteSize = new Basic.Size(256, 256);
                //    def.WalkSprites = 6;
                //    break;
                default: throw new ArgumentException("Unknown/Unhandled UnitEntityType");
            }
            return def;
        }
    }
}
