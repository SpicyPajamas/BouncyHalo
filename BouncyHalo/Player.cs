using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyHalo
{
    class Player : IEnemy
    {
        Texture2D pelican;
        Texture2D engine;
        Texture2D flameL;
        Texture2D flameR;
        Texture2D LaserSprite;

        Vector2 position;
        Vector2 engineoffset;
        Vector2 flameLoffset;
        Vector2 flameRoffset;
        Vector2 flameScale;
        Vector2 engineOrigin;
        Vector2 flamesOrigin;

        List<Laser> Lasers;

        float ShootTimer;
        float ShootTime = 50f;
        int flameShuffleTimer;
        int flameShuffleTime = 75;
        bool showLeftFlame;
        float engineRotation;

        public int Health = 100;
        int Damage = 20;
        public bool IsDead;

        List<IEnemy> Targets;


        public Player(float x, float y, ContentManager content, List<IEnemy> targets)
        {
            Targets = targets;

            pelican = content.Load<Texture2D>("pelican");
            engine = content.Load<Texture2D>("engine");
            flameL = content.Load<Texture2D>("flameL");
            flameR = content.Load<Texture2D>("flameR");
            LaserSprite = content.Load<Texture2D>("orange-bullet-1");

            Lasers = new List<Laser>();

            position = new Vector2(x, y);
            engineoffset = new Vector2(140 + (engine.Width * 0.5f), 120 + (engine.Height * 0.5f));
            flamesOrigin = new Vector2(engineoffset.X + flameL.Width, engineoffset.Y + flameL.Height);
            flameLoffset = new Vector2(190, 160);
            flameRoffset = new Vector2(40, 130);
            flameScale = new Vector2(2, 2);
            engineOrigin = new Vector2((engine.Width * 0.5f), (engine.Height * 0.5f));
            engineRotation = 0f;
        }

        public void draw(SpriteBatch sb)
        {
            sb.Draw(pelican, position, Color.White);

            if (showLeftFlame)
                sb.Draw(flameL, position + flameLoffset, null, Color.White, engineRotation, engineOrigin, flameScale, SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(flameR, position + flameLoffset, null, Color.White, engineRotation, engineOrigin, flameScale, SpriteEffects.FlipHorizontally, 0);

            sb.Draw(engine, position + engineoffset, null, Color.White, engineRotation, engineOrigin, Vector2.One, SpriteEffects.FlipHorizontally, 0);

            foreach (var laser in Lasers)
                laser.Draw(sb);
        }

        public void update(GameTime dt, List<IEnemy> targets)
        {
            Targets = targets;

            UpdatePosition();
            UpdateFlameAnimation(dt);


            foreach (var laser in Lasers)
                laser.Update();
            Lasers.RemoveAll(l => l.Body.X > 2020 || l.IsDead);

            ShootTimer += dt.ElapsedGameTime.Milliseconds;
            if (ShootTimer >= ShootTime)
            {
                KeyboardState state = Keyboard.GetState();
                if(state.IsKeyDown(Keys.Space))
                {
                    ShootTimer = 0;
                    Lasers.Add(new Laser((int)position.X + pelican.Width - 30, (int)position.Y + pelican.Height - 16, 16, 8, -30, Damage, LaserSprite, Targets));
                }
            }

        }

        public void UpdateFlameAnimation(GameTime dt)
        {
            flameShuffleTimer += dt.ElapsedGameTime.Milliseconds;
            while(flameShuffleTimer >= flameShuffleTime)
            {
                flameShuffleTimer -= flameShuffleTime;
                showLeftFlame = !showLeftFlame;
            }
        }

        public void UpdatePosition()
        {
            if (position.Y + pelican.Height <= 1080)
                position.Y += 1f;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                if(position.X + pelican.Width <= 1920)
                position.X += 10f;
            }
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
            {
               if (position.X >= 0)
                    position.X -= 10f;
            }
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
            {

                if (position.Y >= 0)
                    position.Y -= 10f;
                engineRotation = -0.55f;
            }
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                if (position.Y + pelican.Height <= 1080)
                    position.Y += 10f;
                engineRotation = 0.55f;
            }
            if (!(state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W)))
                engineRotation = 0;

        }

        public bool IsCollided(Rectangle body)
        {
            return (body.X < position.X + pelican.Width &&
            body.X + body.Width > position.X &&
            body.Y < position.Y + pelican.Height &&
            body.Y + body.Height > position.Y);
        }

        public void DoDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                IsDead = true;
        }

    }

   
}
