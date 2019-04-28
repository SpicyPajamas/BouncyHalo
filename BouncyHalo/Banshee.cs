using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyHalo
{
    class Banshee
    {

        Texture2D Laser;
        Texture2D Ship;

        Rectangle Body;
        Rectangle LaserBody;

        float ShootTimer;
        float ShootTime = 100f;


        public Banshee(int x, int y, ContentManager content)
        {
            Ship = content.Load<Texture2D>("banshee");
            Laser = content.Load<Texture2D>("smol-lazor-2");

            Body = new Rectangle(x, y, 128, 64);
            LaserBody = new Rectangle(x, y, 16, 16);
        }

        public void Update(GameTime dt)
        {
            Body.X -= 8;
            LaserBody.X -= 30;

            ShootTimer += dt.ElapsedGameTime.Milliseconds;
            if(ShootTimer >= ShootTime)
            {
                ShootTimer = 0;
                LaserBody.X = Body.X - 16;
                LaserBody.Y = Body.Y + 48;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Ship, Body, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            sb.Draw(Laser, LaserBody, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }

    }
}
