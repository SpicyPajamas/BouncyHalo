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
    class Banshee : IEnemy
    {

        Texture2D LaserSprite;
        Texture2D Ship;

        public Rectangle Body;
        List<Laser> Lasers;

        float ShootTimer;
        float ShootTime = 150f;

        float UpAnimTimer;
        float UpAnimTime = 1000f;
        bool GoingUp;

        int Health = 100;
        bool IsDead;

        List<IEnemy> Targets;

        public Banshee(int x, int y, ContentManager content, List<IEnemy> targets)
        {
            Targets = targets;

            Ship = content.Load<Texture2D>("banshee");
            LaserSprite = content.Load<Texture2D>("smol-lazor-2");

            Body = new Rectangle(x, y, 128, 64);
            Lasers = new List<Laser>();
        }

        public void Update(GameTime dt)
        {
            Body.X -= 8;
            foreach (var laser in Lasers)
                laser.Update();
            Lasers.RemoveAll(l => l.Body.X < -100);

            ShootTimer += dt.ElapsedGameTime.Milliseconds;
            if (ShootTimer >= ShootTime)
            {
                ShootTimer = 0;
                Lasers.Add(new Laser(Body.X, Body.Y + 48, 16, 16, 18, 5, LaserSprite, Targets));
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

        public bool IsCollided(Rectangle body)
        {
            return Body.Intersects(body);
        }

        public void DoDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                IsDead = true;
        }
    }
}
