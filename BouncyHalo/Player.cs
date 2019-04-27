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
        
        public Player(float x, float y, ContentManager content )
        {

            pelican = content.Load<Texture2D>("pelican");
            engine = content.Load<Texture2D>("engine");
            flameL = content.Load<Texture2D>("flameL");
            flameL = content.Load<Texture2D>("flameR");
            position = new Vector2(x, y);
        }
        public void draw(SpriteBatch sb)
        {
            sb.Draw(pelican, position, Color.White);


        }


       

    }

   
}
