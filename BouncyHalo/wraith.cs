using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BouncyHalo
{
    class Phantom : IEnemy
    {
        private readonly Texture2D bigfukker;
        private readonly Texture2D thruster1;
        private readonly Texture2D thruster2;
        private readonly Texture2D lgLazor;

        public Vector2 position;
        private Vector2 tO1;
        private Vector2 tO2;

        int thrustShuffleTimer;
        int thrustShuffleTime = 75;
        bool showLeftThrust;

        float wthUpAnimTimer;
        float wthUpAnimTime = 1300f;
        bool wthGoingUp;
        
        List<Laser> lgLasers;

        float ShootTimer;
        float ShootTime = 1500f;

        int Health = 450;
        public bool IsDead;

        List<IEnemy> Targets;


        public Phantom(float x, float y, ContentManager content, List<IEnemy> targets)
        {
            Targets = targets;

            lgLasers = new List<Laser>();

            position = new Vector2(x, y);
            tO1 = new Vector2(291, 130);
            tO2 = new Vector2(289, 130);

            bigfukker = content.Load<Texture2D>("wraith");
            thruster1 = content.Load<Texture2D>("wraith-trhuster-1");
            thruster2 = content.Load<Texture2D>("wraith-trhuster-2");
            lgLazor = content.Load<Texture2D>("large-lazor");
        }
        public void draw(SpriteBatch sb)
        {
            sb.Draw(bigfukker, position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);
            //sb.Draw(thruster1, position + tO2, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
            //sb.Draw(thruster2, position + tO1, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);

            if (showLeftThrust)
                sb.Draw(thruster1, position + tO1, null);
            else
                sb.Draw(thruster2, position + tO2, null);

            foreach (var lgLaser in lgLasers)
                lgLaser.Draw(sb);

        }

        public void UpdateThrustAnimation(GameTime dt)
        {
            thrustShuffleTimer += dt.ElapsedGameTime.Milliseconds;
            while (thrustShuffleTimer >= thrustShuffleTime)
            {
                thrustShuffleTimer -= thrustShuffleTime;
                showLeftThrust = !showLeftThrust;
            }
            wthUpAnimTimer += dt.ElapsedGameTime.Milliseconds;
            if (wthUpAnimTimer >= wthUpAnimTime)
            {
                wthUpAnimTimer = 0f;
                wthGoingUp = !wthGoingUp;
            }

            position.Y += (wthGoingUp ? 0.5f : -0.5f);

        }

        public void update(GameTime dt)
        {
            UpdateThrustAnimation(dt);
            position.X -= 4f;
            foreach (var laser in lgLasers)
                laser.Update();
            lgLasers.RemoveAll(l => l.Body.X < -100 || l.IsDead);

            ShootTimer += dt.ElapsedGameTime.Milliseconds;
            if (ShootTimer >= ShootTime)
            {
                ShootTimer = 0;
                lgLasers.Add(new Laser((int)position.X + -50, (int)position.Y + 200, 60, 30, 15, 25, lgLazor, Targets));
            }

        }

        public bool IsCollided(Rectangle body)
        {
            //var topRight = new Vector2(position.X + bigfukker.Width, position.Y);
            //var bottomRight = new Vector2(position.X + bigfukker.Width, position.Y + bigfukker.Height);
            //var bottomLeft = new Vector2(position.X, position.Y + bigfukker.Height);
            //if (body.Contains(position) || body.Contains(topRight) ||
            //    body.Contains(bottomRight) || body.Contains(bottomLeft))
            //    return true;
            //return false;

            return (body.X < position.X + bigfukker.Width &&
            body.X + body.Width > position.X &&
            body.Y < position.Y + bigfukker.Height &&
            body.Y + body.Height > position.Y); 
        }

        public void DoDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                IsDead = true;
        }

        public void flicker(Color color)
        {
        }
    }

}
