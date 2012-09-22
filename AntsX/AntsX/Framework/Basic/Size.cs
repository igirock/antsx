using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntsX.Framework.Basic
{
    public struct Size
    {
        public Size(int width, int height):this()
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }
    }
}
