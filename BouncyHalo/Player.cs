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
        float flameRotate;

        public Player(float x, float y, ContentManager content )
        {

            pelican = content.Load<Texture2D>("pelican");
            engine = content.Load<Texture2D>("engine");
            flameL = content.Load<Texture2D>("flameL");
            flameR = content.Load<Texture2D>("flameR");
            position = new Vector2(x, y);
            engineoffset = new Vector2(140, 165);
            flameLoffset = new Vector2(70,160);
            flameRoffset = new Vector2(60,160);
            flameScale = new Vector2(2, 2);
            flameRotate = 0f;
        }
        public void draw(SpriteBatch sb)
        {
            sb.Draw(pelican, position, Color.White);
            sb.Draw(flameL, position + flameLoffset, null, null, null, flameRotate, flameScale, null, SpriteEffects.FlipHorizontally, 0);
            sb.Draw(flameR, position + flameLoffset, null, null, null, flameRotate, flameScale, null, SpriteEffects.FlipHorizontally, 0);
            sb.Draw(engine, position +engineoffset, Color.White);
            
        }
        public void update()
        {
            position.Y += 1f;
        }
      


       

    }

   
}
