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
    class Player
    {
        Texture2D pelican;
        Texture2D engine;
        Texture2D flameL;
        Texture2D flameR;
        Vector2 position;
        Vector2 engineoffset;
        Vector2 flameLoffset;
        Vector2 flameRoffset;
        Vector2 flameScale;

        int flameShuffleTimer;
        int flameShuffleTime = 75;
        bool showLeftFlame;
        Vector2 engineOrigin;
        Vector2 flamesOrigin;
        float engineRotation;

        public Player(float x, float y, ContentManager content)
        {

            pelican = content.Load<Texture2D>("pelican");
            engine = content.Load<Texture2D>("engine");
            flameL = content.Load<Texture2D>("flameL");
            flameR = content.Load<Texture2D>("flameR");
            position = new Vector2(x, y);
            engineoffset = new Vector2(120, 135);
            flameLoffset = new Vector2(50, 130);
            flameRoffset = new Vector2(40, 130);
            flameScale = new Vector2(2, 2);
            engineRotation = 0f;
            engineOrigin = new Vector2(engine.Width / 2, engine.Height / 2);
        }

        public void draw(SpriteBatch sb)
        {
            sb.Draw(pelican, position, Color.White);

            if (showLeftFlame)
                sb.Draw(flameL, position + flameLoffset, null, Color.White, engineRotation, engineOrigin, flameScale, SpriteEffects.FlipHorizontally, 0);
            else
                sb.Draw(flameR, position + flameLoffset, null, Color.White, engineRotation, engineOrigin, flameScale, SpriteEffects.FlipHorizontally, 0);

            sb.Draw(engine, position + engineoffset, null, Color.White, engineRotation, engineOrigin, Vector2.One, SpriteEffects.FlipHorizontally, 0);
        }

        public void update(GameTime dt)
        {
            UpdatePosition();
            UpdateFlameAnimation(dt);

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
                engineRotation = -0.785f;
            }
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                if (position.Y + pelican.Height <= 1080)
                    position.Y += 10f;
                engineRotation = 0.785f;
            }
            if (!(state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W)))
                engineRotation = 0;
            
        }




    }

   
}
