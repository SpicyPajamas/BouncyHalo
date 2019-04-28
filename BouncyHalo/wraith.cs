using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyHalo
{
    class wraith
    {
        Texture2D wraith;
        Texture2D thruster;
        Texture2D largeLazor;
        Vector2 position;
        Vector2 thrusterOffset;


        public void draw(SpriteBatch sb)
        {
            sb.Draw(wraith, position, Color.White);


            sb.Draw(thruster, position + thrusterOffset, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);
        }

        public void update(GameTime dt)
        {
            UpdatePosition();
            UpdateFlameAnimation(dt);

        }

        public void UpdateFlameAnimation(GameTime dt)
        {
            flameShuffleTimer += dt.ElapsedGameTime.Milliseconds;
            while (flameShuffleTimer >= flameShuffleTime)
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
                if (position.X + pelican.Width <= 1920)
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
