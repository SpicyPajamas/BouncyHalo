using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyHalo
{
    class GameEnd
    {
        SpriteFont Font;
        Vector2 TextPosition;
        Vector2 PressPosition;
        string Text;
        string Press;
        public GameEnd(ContentManager content)
        {
            Font = content.Load<SpriteFont>("Halo");
            Text = "You have lost, eat butts.";
            Press = "Press space to continue.";
            TextPosition = new Vector2(600, 300);
            PressPosition = new Vector2(600, 600);
        }


        public bool update()
        {
            KeyboardState state = Keyboard.GetState();
            return state.IsKeyDown(Keys.Space);
        }

        public void draw(SpriteBatch sb)
        {
            sb.DrawString(Font, Text, TextPosition, Color.White);
            sb.DrawString(Font, Press, PressPosition, Color.White);
        }
    }
}
