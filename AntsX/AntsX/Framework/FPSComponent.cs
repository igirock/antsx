using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace AntsX.Framework
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class FPSComponent : DrawableGameComponent
    {
        public FPSComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            this.framecount = 0;
            this.elapsedTime = 0;
        }

        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        private int framecount;
        private float elapsedTime;
        private float fps;
        private Vector2 position;
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            this.position = new Vector2(10, 10);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteFont = this.Game.Content.Load<SpriteFont>("FPSFont");
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime >= 200f)
            {
                this.fps = framecount * 5;
                framecount = 0;
                elapsedTime = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            framecount++;
            this.spriteBatch.Begin();
            this.spriteBatch.DrawString(this.spriteFont, this.fps.ToString("0.00"), this.position, Color.White);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
