using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using AntsX.Framework.Units.Components.ComponentImplementation;
using Microsoft.Xna.Framework.Graphics;
using AntsX.Services;

namespace AntsX.Framework.Units
{
    public class UnitComponentManagerComponent : DrawableGameComponent
    {
        public UnitComponentManagerComponent(Game game) : base(game)
        {
            this.graphicComponents = new List<BaseDrawableUnitComponent>();
            this.movementComponents = new List<BaseUnitComponent>();
            this.miscComponents = new List<BaseUnitComponent>();
            this.unitBuilder = new UnitBuilder(game.Services);
        }

        private UnitBuilder unitBuilder;
        private List<BaseDrawableUnitComponent> graphicComponents;
        private List<BaseUnitComponent> movementComponents;
        private List<BaseUnitComponent> miscComponents;

        private SpriteBatch unitSpriteBatch;
        private Viewport mapViewport;
        private IViewportService vpService;

        public override void Initialize()
        {
            // testing
            UnitEntity e = unitBuilder.CreateUnitEntity(UnitEntityType.Cube);
            categoriseComponents(e);

            vpService = (IViewportService)this.Game.Services.GetService(typeof(IViewportService));
            vpService.MainViewChanged += new ViewportService.ViewportChangedHandler(vpService_MainViewChanged);
            this.mapViewport = vpService.MainView;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.unitSpriteBatch = new SpriteBatch(this.GraphicsDevice);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (BaseUnitComponent b in movementComponents)
            {
                b.Update(gameTime);
            }

            foreach (BaseUnitComponent b in miscComponents)
            {
                b.Update(gameTime);
            }

            foreach (BaseDrawableUnitComponent d in graphicComponents)
            {
                d.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.Game.GraphicsDevice.Viewport = this.mapViewport;
            this.unitSpriteBatch.Begin();
            foreach (BaseDrawableUnitComponent d in graphicComponents)
            {
                d.Draw(gameTime, this.unitSpriteBatch);
            }
            this.unitSpriteBatch.End();
            base.Draw(gameTime);
        }

        private void categoriseComponents(UnitEntity e)
        {
            foreach (BaseUnitComponent buc in e.Components)
            {
                switch (buc.Category)
                {
                    case ComponentCategory.Graphic:
                        BaseDrawableUnitComponent comp = buc as BaseDrawableUnitComponent;
                        if (comp == null)
                        {
                            throw new Exception("GraphicCategory Component is not a DrawableUnitComponent!");
                        }
                        this.graphicComponents.Add(comp);
                        break;
                    case ComponentCategory.Movement:
                        this.movementComponents.Add(buc);
                        break;
                    case ComponentCategory.Misc:
                        this.miscComponents.Add(buc);
                        break;
                    default: throw new Exception("Unknown category!");

                }
            }

            // just to make sure, clear all components in unitentity
            e.Components.Clear();
        }

        void vpService_MainViewChanged(Viewport newViewport)
        {
            this.mapViewport = newViewport;
        }
    }
}
