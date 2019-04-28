using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BouncyHalo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        EV environment;
        List<Banshee> banshees;
        List<wraith> bigfukkers;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            banshees = new List<Banshee>();
            bigfukkers = new List<wraith>();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(10, 50, Content);
            environment = new EV(Content);


            AddWraith();
            AddBanshee();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.update(gameTime);
            environment.update();
            foreach (var banshee in banshees)
                banshee.Update(gameTime);
            foreach (var wraith in bigfukkers)
                wraith.update(gameTime);

            bigfukkers.RemoveAll(b => b.position.X < -600);
            if (bigfukkers.Count == 0)
                AddWraith();
            banshees.RemoveAll(b => b.Body.X + b.Body.Width < -300);
            if (banshees.Count == 0)
                AddBanshee();

            base.Update(gameTime);
        }

        private void AddBanshee()
        {
            var rng = new Random();
            banshees.Add(new Banshee(1920, rng.Next(200, 1000), Content));
        }
        private void AddWraith()
        {
            var rng = new Random();
            var isTop = rng.Next(2);
            if (isTop == 0)
                bigfukkers.Add(new wraith(1900, rng.Next(0, 100), Content));
            else
                bigfukkers.Add(new wraith(1900, rng.Next(780, 880), Content));
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            environment.draw(spriteBatch);
            player.draw(spriteBatch);

            foreach (var banshee in banshees)
                banshee.Draw(spriteBatch);
            foreach (var wraith in bigfukkers)
                wraith.draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
