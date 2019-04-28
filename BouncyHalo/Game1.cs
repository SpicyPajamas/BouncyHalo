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
        List<Phantom> bigfukkers;
        Menu menu;
        GameEnd gameEnd;
        List<IEnemy> Enemies;

        string Text;
        int Score;
        SpriteFont Font;
        Vector2 TextPosition;

        int state;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            banshees = new List<Banshee>();
            bigfukkers = new List<Phantom>();
            Enemies = new List<IEnemy>();


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
            player = new Player(10, 50, Content, Enemies);
            environment = new EV(Content);

            menu = new Menu(Content);
            gameEnd = new GameEnd(Content);


            Text = "Score: ";
            Score = 0;
            Font = Content.Load<SpriteFont>("File");
            TextPosition = new Vector2(1500, 10);


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

            Enemies.Clear();
            Enemies.AddRange(banshees);
            Enemies.AddRange(bigfukkers);
            player.update(gameTime, Enemies);
            environment.update();

            if (state == 0)
            {
                if (menu?.Update() ?? true)
                {
                    state = 2;
                }
            }
            else if (state == 1)
            {
                foreach (var banshee in banshees)
                    banshee.Update(gameTime);
                foreach (var wraith in bigfukkers)
                    wraith.update(gameTime);

                Score += bigfukkers.FindAll(BF => BF.IsDead).Count;
                Score += banshees.FindAll(Banch => Banch.IsDead).Count;

                bigfukkers.RemoveAll(b => b.position.X < -600 || b.IsDead);
                if (bigfukkers.Count == 0)
                    AddWraith();
                banshees.RemoveAll(b => b.Body.X + b.Body.Width < -300 || b.IsDead);
                if (banshees.Count == 0)
                    AddBanshee();
            }
            else if (state == 2)
            {
                if (gameEnd?.update() ?? true)
                {
                    state = 1;
                }
            }

            base.Update(gameTime);
        }

        private void AddBanshee()
        {
            var rng = new Random();
            banshees.Add(new Banshee(1920, rng.Next(200, 1000), Content, new List<IEnemy> { player }));
        }
        private void AddWraith()
        {
            var rng = new Random();
            bigfukkers.Add(new Phantom(1900, rng.Next(0, 400), Content, new List<IEnemy> { player }));
            bigfukkers.Add(new Phantom(1900, rng.Next(500, 800), Content, new List<IEnemy> { player }));
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

            if (state == 0)
            {
                menu.Draw(spriteBatch);
            }
            else if (state == 1)
            {
                foreach (var banshee in banshees)
                    banshee.Draw(spriteBatch);
                foreach (var wraith in bigfukkers)
                    wraith.draw(spriteBatch);

                spriteBatch.DrawString(Font, Text + Score, TextPosition, Color.White);
            }
            else if (state == 2)
            {
                gameEnd.draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
