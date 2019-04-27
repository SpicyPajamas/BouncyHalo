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
    class EV
    {
        Texture2D Background;
        Texture2D BackgroundExtended;
        Rectangle position;
        Rectangle positionEX;

        public EV(ContentManager content)
        {
            Background = content.Load<Texture2D>("background");
            BackgroundExtended = content.Load<Texture2D>("background-extended");
            position = new Rectangle(0, 0, 1920, 1080);
            positionEX = new Rectangle(1920, 0, 1920, 1080);
        }

        public void draw(SpriteBatch sb)
        {
            sb.Draw(Background, position, Color.White);
            sb.Draw(BackgroundExtended, positionEX, Color.White);

        }
        public void update()
        {
            position.X -= 3;
            positionEX.X -= 3;
        if (position.X <= -1920)
            {
                position.X = 1920;
                Background = BackgroundExtended;
            }
        if (positionEX.X <= -1920)
            {
                positionEX.X = 1920;
            }
        }
        
    }
}
