using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using JD_spel;

namespace JD_spel
{
    class Skott
    {
        //Systemvariabler
        private Game1 game;
        private Sprite spriteSheet;

        //Skottvariabler
        public Sprite skottBild;
        public Vector2 skottPosition;
        private Vector2 riktning;
        private float hastighet;
        public Boolean lever;


        //Konstruktor. Anropas när ett skott skapas.
        public Skott(Game1 game, Sprite spriteSheet)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            skottBild = spriteSheet.GetSubSprite(new Rectangle(40,0,5,5));
            skottPosition = new Vector2(-100, -100);
            hastighet = 3;
            lever = true;
        }
        
        public void SkjutSkott(Vector2 skottPosition_, Vector2 riktning_)
        {
            skottPosition = skottPosition_;
            riktning = riktning_;
            lever = true;
        }
        
        public void Uppdatera(GameTime gameTime)
        {
            skottPosition = skottPosition + (riktning * hastighet);
        }
        
        public void Rita(SpriteBatch spriteBatch)
        {
            if (lever)
            {
                spriteBatch.Draw(skottBild.Texture, skottPosition,skottBild.SourceRectangle, Color.White);
            }
        }

        public Rectangle GetKanter()
        {
            return new Rectangle((int)skottPosition.X, (int)skottPosition.Y, skottBild.Width, skottBild.Height);
        }
    }
}