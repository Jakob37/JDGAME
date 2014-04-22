using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    class Gubbe
    {
        //Systemvariabler
        private Game1 game;
        private Sprite spriteSheet;
        private KeyboardState tangentbord;

        //Variabler
        public Sprite gubbBild;
        public Vector2 gubbPosition;
        public Boolean gubbeLever;
        public Vector2 gubbRiktning;

        //Konstruktor, som körs när gubben skapas
        public Gubbe(Game1 game, Sprite spriteSheet)
        {
            this.game = game;

            //gubbBild = Game_.Content.Load<Texture2D>("gubbe");
            gubbPosition = new Vector2(200, 200);
            gubbeLever = true;

            this.spriteSheet = spriteSheet;
            gubbBild = spriteSheet.GetSubSprite(new Rectangle(25, 0, 15, 29));
        }

        //Funktioner

        public void Uppdatera(GameTime gameTime)
        {
            tangentbord = Keyboard.GetState();

            UppdateraGubbensPosition();
            GubbensPositionMotKanter();
        }

        public void Rita(SpriteBatch spriteBatch)
        {
            if (gubbeLever)
            {
                spriteBatch.Draw(gubbBild.Texture, gubbPosition, gubbBild.SourceRectangle, Color.White);
            }
        }

        public void UppdateraGubbensPosition()
        {
            float hastighet = 5;

            if (tangentbord.IsKeyDown(Keys.Right))
            {
                gubbRiktning = new Vector2(1, 0);
                gubbPosition.X = gubbPosition.X + hastighet;
            }
            if (tangentbord.IsKeyDown(Keys.Left))
            {
                gubbRiktning = new Vector2(-1, 0);
                gubbPosition.X = gubbPosition.X - hastighet;
            }
            if (tangentbord.IsKeyDown(Keys.Up))
            {
                gubbRiktning = new Vector2(0, -1);
                gubbPosition.Y = gubbPosition.Y - hastighet;
            }
            if (tangentbord.IsKeyDown(Keys.Down))
            {
                gubbRiktning = new Vector2(0, 1);
                gubbPosition.Y = gubbPosition.Y + hastighet;
            }
        }

        public void GubbensPositionMotKanter()
        {
            float WindowWidth = game.Window.ClientBounds.Width;
            float WindowHeight = game.Window.ClientBounds.Height;

            if (gubbPosition.X < 0)
            {
                gubbPosition.X = 0;
            }
            if (gubbPosition.X > WindowWidth - gubbBild.Width)
            {
                gubbPosition.X = WindowWidth - gubbBild.Width;
            }

            if (gubbPosition.Y < 0)
            {
                gubbPosition.Y = 0;
            }

            if (gubbPosition.Y > WindowHeight - gubbBild.Height)
            {
                gubbPosition.Y = WindowHeight - gubbBild.Height;
            }
        }

        public Rectangle GetKanter()
        {
            return new Rectangle((int)gubbPosition.X, (int)gubbPosition.Y, gubbBild.Width, gubbBild.Height);
        }
    }
}