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
    class Menu
    {
        SpriteFont Font;

        Vector2 TitlePosition;
        Vector2 PressPosition;

        string Title;
        string Press;

        bool HasBeenCleared;


        public Menu(ContentManager content)
        {
            Font = content.Load<SpriteFont>("File");

            TitlePosition = new Vector2(520, 350);
            PressPosition = new Vector2(550, 650);

            Title = "PELICAN JOYRIDE";
            Press = "Press Space to begin.";
        }


        public bool Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (!HasBeenCleared)
                if (!state.IsKeyDown(Keys.Space))
                    HasBeenCleared = true;
            return HasBeenCleared && state.IsKeyDown(Keys.Space);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.DrawString(Font, Title, TitlePosition, Color.White);
            sb.DrawString(Font, Press, PressPosition, Color.White);
        }


    }
}
