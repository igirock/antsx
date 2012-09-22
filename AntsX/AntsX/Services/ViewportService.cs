using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AntsX.Services
{
    public class ViewportService : AntsX.Services.IViewportService, IGameComponent
    {
        Viewport mainScreen;
        Viewport rightSidebar;

        public delegate void ViewportChangedHandler(Viewport newViewport);
        public event ViewportChangedHandler MainViewChanged;
        public event ViewportChangedHandler RightSidebarViewChanged;

        public ViewportService(Game game)
        {
            this.game = game;
            this.game.Services.AddService(typeof(IViewportService), this);
        }

        private Game game;

        public Viewport MainView
        {
            get
            {
                return this.mainScreen;
            }
            private set
            {
                this.mainScreen = value;
                OnMainViewChanged(this.mainScreen);
            }
        }

        public Viewport RightSidebarView
        {
            get
            {
                return this.rightSidebar;
            }
            private set
            {
                this.rightSidebar = value;
                OnRightSidebarViewChanged(this.rightSidebar);
            }
        }

        private void OnMainViewChanged(Viewport newViewport)
        {
            if (MainViewChanged != null)
            {
                MainViewChanged(newViewport);
            }
        }

        private void OnRightSidebarViewChanged(Viewport newViewport)
        {
            if (RightSidebarViewChanged != null)
            {
                RightSidebarViewChanged(newViewport);
            }
        }


        public void Initialize()
        {
            int width, height;

            //DisplayMode d = this.game.GraphicsDevice.Adapter.CurrentDisplayMode;

            width = this.game.GraphicsDevice.Viewport.Width;
            height = this.game.GraphicsDevice.Viewport.Height;

            //main view
            Viewport vp = new Viewport();
            vp.X = 0;
            vp.Y = 0;
            vp.Width = width - 200;
            vp.Height = height;
            this.MainView = vp;
  
            //right sidebar
            vp = new Viewport();
            vp.X = width - 200;
            vp.Y = 0;
            vp.Width = 200;
            vp.Height = height;
            this.RightSidebarView = vp;
        }
    }
}
