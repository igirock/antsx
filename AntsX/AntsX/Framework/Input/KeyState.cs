using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace AntsX.Framework.Input
{
    public class KeyState
    {
        public KeyState(Keys key)
        {
            this.Key = key;
        }

        public event Action KeyPress;

        public Keys Key
        {
            get;
            private set;
        }

        public bool IsDown
        {
            get;
            private set;
        }

        public bool IsUp
        {
            get;
            private set;
        }

        public void SetKeyboardState(KeyboardState state)
        {
            bool newDown = state.IsKeyDown(this.Key);
            bool newUp = state.IsKeyUp(this.Key);

            if (this.IsDown && newUp)
            {
                OnKeyPress();
            }

            this.IsDown = newDown;
            this.IsUp = newUp;
        }

        private void OnKeyPress()
        {
            if (KeyPress != null)
            {
                KeyPress();
            }
        }
    }
}
