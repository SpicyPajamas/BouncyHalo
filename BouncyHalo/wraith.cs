using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BouncyHalo
{
    internal class wraith
    {
        private readonly Texture2D bigfukker;
        private readonly Texture2D thruster1;
        private readonly Texture2D thruster2;
        private readonly Texture2D lgLazor;
        public Vector2 position;
        private Vector2 tO1;
        private Vector2 tO2;

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
