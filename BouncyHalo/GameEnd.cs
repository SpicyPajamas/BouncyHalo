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
        bool HasBeenCleared;

        public GameEnd(ContentManager content)
        {
            Font = content.Load<SpriteFont>("File");
            Text = "You have lost, eat butts.";
            Press = "Press space to continue.";
            TextPosition = new Vector2(500, 350);
            PressPosition = new Vector2(500, 650);
        }


        public bool update()
        {
            KeyboardState state = Keyboard.GetState();
            if (!HasBeenCleared)
                if (!state.IsKeyDown(Keys.Space))
                    HasBeenCleared = true;
            return HasBeenCleared && state.IsKeyDown(Keys.Space);
        }

        public void draw(SpriteBatch sb)
        {
            sb.DrawString(Font, Text, TextPosition, Color.White);
            sb.DrawString(Font, Press, PressPosition, Color.White);
        }
    }
}
