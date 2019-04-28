using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyHalo
{
    class Laser
    {
        public Rectangle Body;
        public bool IsDead;

        List<IEnemy> Targets;
        Texture2D Sprite;
        int Speed;
        int Damage;

        public Laser(int x, int y, int w, int h, int speed, int damage, Texture2D sprite, List<IEnemy> targets)
        {
            Targets = targets;
            Sprite = sprite;
            Speed = speed;
            Damage = damage;
            Body = new Rectangle(x, y, w, h);
        }

        public void Update()
        {
            Body.X -= Speed;
            foreach(var target in Targets)
            {
                if(target.IsCollided(Body))
                { 
                    target.DoDamage(Damage);
                    IsDead = true;
                    target.flicker (Color.Red);
                }
            }
        }
        

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Sprite, Body, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }

    }
}
