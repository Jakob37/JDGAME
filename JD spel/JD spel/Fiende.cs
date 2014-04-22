using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JD_spel
{
    class Fiende
    {
        //Systemvariabler
        private Game1 game;
        private Sprite spriteSheet;

        public Sprite fiendeBild;
        public Vector2 fiendePosition;
        public Boolean fiendeLever;
        public Vector2 fiendeRiktning;
        private float hastighet;
        private Gubbe gubbe;
        public int liv;

        public Fiende(Game1 game, Sprite spriteSheet, Gubbe gubbe) 
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            fiendeBild = spriteSheet.GetSubSprite(new Rectangle(0, 0, 21, 25));
            fiendePosition = new Vector2(400, 300);
            hastighet = 1F;
            this.gubbe = gubbe;
            liv = 500;
            fiendeLever = true;
        }


        public void Uppdatera(GameTime gameTime)
        {
            fiendeRiktning = new Vector2(gubbe.gubbPosition.X - fiendePosition.X, gubbe.gubbPosition.Y - fiendePosition.Y);
            fiendeRiktning = GlobalFunctions.ScaleDirection(fiendeRiktning);
            fiendePosition += fiendeRiktning * hastighet;

            if (liv <= 0)
            {
                fiendeLever = false;
            }
        }


        public void Rita(SpriteBatch spriteBatch)
        {
            if (fiendeLever == true)
            {
                spriteBatch.Draw(fiendeBild.Texture, fiendePosition,fiendeBild.SourceRectangle, Color.White);
            }
        }

        public Rectangle GetKanter()
        {
            return new Rectangle((int)fiendePosition.X, (int)fiendePosition.Y, fiendeBild.Width, fiendeBild.Height);
        }
    }
}
