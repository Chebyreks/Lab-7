using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lab6.Core;
using Lab6.Objects;
using Lab6.Utils;
using Lab6.Systems;

namespace Lab6
{


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Entity> _entities;
        Texture2D texture1;
        Texture2D texture2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            Collision.CreateGrid(1280);
            _entities.Add(new CollidableObject("Shaurma1", new Vector2(0, 0), new Vector2(4, 4), texture1));
            _entities.Add(new CollidableObject("Shaurma2", new Vector2(500, 350), new Vector2(-4, -4), texture2));
            _entities.Add(new InvisibleObject("WallSouth", new Vector2(0, 720), new Vector2(1080, 100)));
            _entities.Add(new InvisibleObject("WallWest", new Vector2(-100, 0), new Vector2(100, 720)));
            _entities.Add(new InvisibleObject("WallNorth", new Vector2(0, -100), new Vector2(1080, 100)));
            _entities.Add(new InvisibleObject("WallEast", new Vector2(1080, 0), new Vector2(100, 720)));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _entities = new List<Entity>();

            texture1 = Content.Load<Texture2D>("shaurma1");
            texture2 = Content.Load<Texture2D>("shaurma2");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            foreach (Entity entity in _entities)
            {
                entity.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Entity entity in _entities)
            {
                entity.Draw(ref _spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
