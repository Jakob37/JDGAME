using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel.Spelobjekt.Skott
{
    class LavaPool : FiendeSkott
    {
        public LavaPool(Game1 game, Sprite spriteSheet, State presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(344, 3, 38, 35));
            position = new Vector2(-100, -100);
            hastighet = 0;
            liv = 1000;
            skada = 1;
        }
    }
}
