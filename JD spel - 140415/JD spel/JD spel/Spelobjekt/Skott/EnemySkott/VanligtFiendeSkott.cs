using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class VanligtFiendeSkott : FiendeSkott
    {
        public VanligtFiendeSkott(Game1 game, Sprite spriteSheet, RunningState presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(40, 5, 5, 5));
            Position = new Vector2(-100, -100);
            hastighet = 5;
            liv = 1;
            skada = 5;
        }
    }
}
