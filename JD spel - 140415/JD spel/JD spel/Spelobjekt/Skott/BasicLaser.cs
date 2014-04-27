using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class BasicLaser : SpelarSkott
    {
        public BasicLaser(Game1 game, Sprite spriteSheet, State presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(180, 0, 2, 14));
            position = new Vector2(-100, -100);
            hastighet = 5;
            liv = 1;
            skada = 10F;
            energiKostnad = 1;
            range = 300;
        }
    }
}
