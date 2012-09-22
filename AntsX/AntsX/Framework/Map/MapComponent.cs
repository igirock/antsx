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
using AntsX.TMXTiledMap;
using AntsX.Framework.Map;
using AntsX.Services;


namespace AntsX.Framework.Map
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MapComponent : DrawableGameComponent
    {
        public MapComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            this.tileOffset = new Vector2(0, 0);
            this.scrollSpeed = 1;
            this.outOfMapScrollDistance = 100;
        }

        private Viewport mapViewport;
        private MapNode[,] map;
        private SpriteBatch spriteBatch;
        
        private Vector2 tileOffset;
        private float scrollSpeed;
        private int outOfMapScrollDistance;

        // services
        private IViewportService vpService;
        private IInputService inputService;
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            AntsX.TMXTiledMap.map m = loadTMXMapFromFile(@"H:\XNAGame\content\unbenannt.xml");
            createMapFromTMXMap(m);

            initViewport();

            this.inputService = (IInputService)this.Game.Services.GetService(typeof(IInputService));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            float scroll = scrollSpeed * gameTime.ElapsedGameTime.Milliseconds;

            // TODO: Add your update code here
            if (this.inputService.MapScrollLeft)
            {
                this.tileOffset.X += scroll;
            }

            if (this.inputService.MapScrollRight)
            {
                this.tileOffset.X -= scroll;
            }

            if (this.inputService.MapScrollUp)
            {
                this.tileOffset.Y += scroll;
            }

            if (this.inputService.MapScrollDown)
            {
                this.tileOffset.Y -= scroll;
            }

            this.tileOffset.X = MathHelper.Clamp(this.tileOffset.X, -(this.PixelWidth - this.mapViewport.Width + this.outOfMapScrollDistance), this.outOfMapScrollDistance);
            this.tileOffset.Y = MathHelper.Clamp(this.tileOffset.Y, -(this.PixelHeight - this.mapViewport.Height + this.outOfMapScrollDistance), this.outOfMapScrollDistance);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.Game.GraphicsDevice.Viewport = this.mapViewport;
            drawMap();

            base.Draw(gameTime);
        }


        private void initViewport()
        {
            this.vpService = (IViewportService)this.Game.Services.GetService(typeof(IViewportService));
            this.mapViewport = this.vpService.MainView;
            this.vpService.MainViewChanged += new ViewportService.ViewportChangedHandler(viewport_MainViewChanged);
        }

        private void drawMap()
        {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Opaque, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullNone);
            for (int y = 0; y < this.map.GetLength(1); y++)
            {
                for (int x = 0; x < this.map.GetLength(0); x++)
                {
                    MapNode n = this.map[y,x];
                    //spritebatch will not draw tiles offscreen!
                    spriteBatch.Draw(n.TileImage, n.TilePosition + this.tileOffset, Color.White);
                }
            }
            spriteBatch.End();
        }

        private AntsX.TMXTiledMap.map loadTMXMapFromFile(string filename)
        {
            map m = null;
            Exception e;
            if (!TMX<map>.LoadFromFile(filename, out m, out e))
            {
                throw e;
            }
            else
            {
                if (m == null)
                {
                    throw new ArgumentNullException();
                }
            }
            return m;
        }

        private void createMapFromTMXMap(AntsX.TMXTiledMap.map tmxmap)
        {
            this.Width = tmxmap.width;
            this.Height = tmxmap.height;
            this.TileHeight = tmxmap.tileheight;
            this.TileWidth = tmxmap.tilewidth;
            this.PixelWidth = this.Width * this.TileWidth;
            this.PixelHeight = this.Height * this.TileHeight;

            this.map = new MapNode[this.Height, this.Width];

            foreach (layer l in tmxmap.Items)
            {
                switch (l.name)
                {
                    case "ground":
                        if (l.width != this.Width || l.height != this.Height)
                        {
                            throw new ArgumentException("layer has not the same size");
                        }

                        int y = 0, x = 0;
                        foreach (layerDataTile dataTile in l.data.Items)
                        {
                            if (x == this.map.GetLength(0))
                            {
                                x = 0;
                                y++;
                            }

                            
                            this.map[y, x] = new MapNode() { 
                                TileImage = this.Game.Content.Load<Texture2D>(@".\map\tiles\ground32"), 
                                TilePosition = new Vector2(x * this.TileWidth, y * this.TileHeight)};

                            x++;
                        }

                        break;
                    default: throw new ArgumentException("unknown layer type");
                }
            }
        }

        void viewport_MainViewChanged(Viewport newViewport)
        {
            this.mapViewport = newViewport;
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public int TileWidth
        {
            get;
            private set;
        }

        public int TileHeight
        {
            get;
            private set;
        }

        public int PixelWidth
        {
            get;
            private set;
        }

        public int PixelHeight
        {
            get;
            private set;
        }
    }
}
