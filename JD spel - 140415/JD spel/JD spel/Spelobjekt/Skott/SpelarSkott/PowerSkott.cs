using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using JD_spel;

namespace JD_spel
{
    class PowerSkott : SpelarSkott
    {
        

        //Konstruktor. Anropas när ett skott skapas.
        public PowerSkott(Game1 game, Sprite spriteSheet, RunningState presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(40, 10, 5, 5));
            Position = new Vector2(-100, -100);
            hastighet = 3;
            liv = 1;
            skada = 30;
            energiKostnad = 8;
            range = 300;
        }
        
        
    }
}