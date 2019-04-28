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

        Texture2D Sprite;
        int Speed;

        public Laser(int x, int y, int w, int h, int speed, Texture2D sprite)
        {
            Sprite = sprite;
            Speed = speed;
            Body = new Rectangle(x, y, w, h);
        }

        public void Update()
        {
            Body.X -= Speed;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Sprite, Body, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }

    }
}
