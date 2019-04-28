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

        Texture2D LaserSprite;
        Texture2D Ship;

        Rectangle Body;
        List<Laser> Lasers;

        float ShootTimer;
        float ShootTime = 100f;

        float UpAnimTimer;
        float UpAnimTime = 1000f;
        bool GoingUp;


        public Banshee(int x, int y, ContentManager content)
        {
            Ship = content.Load<Texture2D>("banshee");
            LaserSprite = content.Load<Texture2D>("smol-lazor-2");
            //LaserSprite = content.Load<Texture2D>("large-lazor");

            Body = new Rectangle(x, y, 128, 64);
            Lasers = new List<Laser>();
        }

        public void Update(GameTime dt)
        {
            Body.X -= 8;
            foreach (var laser in Lasers)
                laser.Update();
            Lasers.RemoveAll(l => l.Body.X < 0);

            ShootTimer += dt.ElapsedGameTime.Milliseconds;
            if (ShootTimer >= ShootTime)
            {
                ShootTimer = 0;
                Lasers.Add(new Laser(Body.X, Body.Y + 48, 16, 16, 30, LaserSprite));
            }

            UpAnimTimer += dt.ElapsedGameTime.Milliseconds;
            if (UpAnimTimer >= UpAnimTime)
            {
                UpAnimTimer = 0f;
                GoingUp = !GoingUp;
            }

            Body.Y += (GoingUp ? 3 : -3);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Ship, Body, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            foreach (var laser in Lasers)
                laser.Draw(sb);
        }

    }
}
