using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using AntsX.Framework.Units.Components;
using Microsoft.Xna.Framework.Graphics;

namespace AntsX.Framework.Units.Components.ComponentImplementation
{
    public class GraphicComponent : BaseDrawableUnitComponent, IGraphic
    {
        public GraphicComponent()
        {
            this.destinationRectangle = new Rectangle();
            this.elapsedTimeBetweenAnim = 300;
        }

        public override void Initialize(IRequestUnitService componentServices, IServiceProvider gameServices)
        {
            

            this.unittype = componentServices.RequestService<IUnitEntityType>();

            // should be a service, 
            this.destinationRectangle.X = 50;
            this.destinationRectangle.Y = 50;

            base.Initialize(componentServices, gameServices);
        }

        // used only during initialization, make sure to null it after, so UnitEntity can be freed
        protected IUnitEntityType unittype;

        protected GraphicDefinition graphicDefinition;

        protected Rectangle destinationRectangle;
        protected int walkAnim;
        protected float elapsedTimeBetweenAnim;
        protected int elapsed;
        protected float rotate = 0;
        protected TimeSpan slower = new TimeSpan();

        public override void LoadContent()
        {
            this.graphicDefinition = UnitContentManager.LoadGraphicDefinition(this.unittype.UnitEntityType);
            //this.destinationRectangle.Width = this.graphicDefinition.SpriteSize.Width;
            //this.destinationRectangle.Height = this.graphicDefinition.SpriteSize.Height;

            this.unittype = null;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            slower += gameTime.ElapsedGameTime;
            if (slower.Seconds > 0)
            {
                rotate+= 10;
                slower = new TimeSpan();
            }
            //elapsed += gameTime.ElapsedGameTime.Milliseconds;

            //if (elapsed > elapsedTimeBetweenAnim)
            //{
            //    walkAnim++;
            //    if (walkAnim == 6)
            //    {
            //        walkAnim = 0;
            //    }
            //    elapsed = 0;
            //}

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            // world matrix is position of the object
            // view matrix is were we are looking at, in the world
            // projection ist blickwinkel
            /*
             * But remember that matrix multiplication is not commutative, you need to do this always in the S-R-T order in XNA. Scale, Rotate, Translate
             * */


            Matrix worldMatrix = /*Matrix.CreateRotationY(4.0f) *Matrix.CreateRotationX(MathHelper.ToRadians(45f)) **/Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));
            Matrix viewMatrix = Matrix.CreateLookAt(new Vector3(1.0f, 10.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.Up);
            Matrix projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), 800.0f / 600.0f, 1.0f, 100.0f); 
            //Matrix world
            //Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(90.0f),(float) (4/3.0), 1.0f, 100000.0f);
            //Matrix view = Matrix.CreateLookAt(new Vector3(1.0f, 1, -1.0f), Vector3.Zero, Vector3.Up);

            worldMatrix *= Matrix.CreateRotationX(MathHelper.ToRadians(rotate));

            foreach (ModelMesh mesh in this.graphicDefinition.Model.Meshes)
            {
                foreach (AlphaTestEffect ae in mesh.Effects)
                {
                    ae.Projection = projectionMatrix;
                    ae.View = viewMatrix;
                    ae.World = worldMatrix;
                }
                //foreach (BasicEffect be in mesh.Effects)
                //{
                //    be.Projection = projectionMatrix;
                //    be.View = viewMatrix;
                //    be.World = worldMatrix;
                //    //be.World = Matrix.CreateScale(1) * Matrix.CreateTranslation(0, 0, 0);
                //}
                
                mesh.Draw();
            }

            //spriteBatch.Draw(this.graphicDefinition.OverviewTexture2DWalk,new Vector2(this.destinationRectangle.X), this.graphicDefinition.GetSourceRectangleWalk(walkAnim), Color.White, 0, new Vector2(), 0.1f, SpriteEffects.None, 0f);
            //base.Draw(gameTime, spriteBatch);
        }

        public override ComponentCategory Category
        {
            get { return ComponentCategory.Graphic; }
        }
    }
}
