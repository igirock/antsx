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
using AntsX.Services;


namespace AntsX.Framework.Input
{
    public delegate void InputActionHandler();
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputComponent : Microsoft.Xna.Framework.GameComponent, IInputService
    {
        public InputComponent(Game game)
            : base(game)
        {
            this.keyHandlers = new Dictionary<Keys, KeyState>();
            // TODO: Construct any child components here
            this.Game.Services.AddService(typeof(IInputService), this);
        }

        private Dictionary<Keys, KeyState> keyHandlers;

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            KeyboardState state = Keyboard.GetState();

            this.MapScrollLeft = state.IsKeyDown(Keys.A);
            this.MapScrollDown = state.IsKeyDown(Keys.S);
            this.MapScrollRight = state.IsKeyDown(Keys.D);
            this.MapScrollUp = state.IsKeyDown(Keys.W);

            foreach (KeyState keyState in this.keyHandlers.Values)
            {
                keyState.SetKeyboardState(state);
            }

            base.Update(gameTime);
        }

        public void AddKeyPressedHandler(Keys key, Action keyHandler)
        {
            if (!keyHandlers.ContainsKey(key))
            {
                KeyState keystate = new KeyState(key);
                keystate.KeyPress += keyHandler;

                this.keyHandlers.Add(key, keystate);
            }
            else
            {
                KeyState keystate = this.keyHandlers[key];
                keystate.KeyPress += keyHandler;
            }
        }

        public bool MapScrollLeft
        {
            get;
            private set;
        }

        public bool MapScrollRight
        {
            get;
            private set;
        }

        public bool MapScrollUp
        {
            get;
            private set;
        }

        public bool MapScrollDown
        {
            get;
            private set;
        }
    }
}
