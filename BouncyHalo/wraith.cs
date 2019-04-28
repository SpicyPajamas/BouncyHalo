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
    class wraith
    {
        Texture2D bigfukker;
        Texture2D thruster1;
        Texture2D thruster2;
        Texture2D lgLazor;
        Vector2 position;
        Vector2 tO1;
        Vector2 tO2;

        public wraith(float x, float y, ContentManager content)
        {
            position = new Vector2(x, y);
            bigfukker = content.Load<Texture2D>("wraith");
            thruster1 = content.Load<Texture2D>("wraith-trhuster-1");
            thruster2 = content.Load<Texture2D>("wraith-trhuster-2");
            lgLazor = content.Load<Texture2D>("large-lazor");
            tO1 = new Vector2(0, 0);
            tO2 = new Vector2(0, 0);


        }
            public void draw(SpriteBatch sb)
        {
            sb.Draw(bigfukker, position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);
            sb.Draw(thruster1, position + tO2, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
            sb.Draw(thruster2, position + tO1, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);

        }


        public void update(GameTime dt)
        {

            position.X -= 2f;

        }



    }

}
