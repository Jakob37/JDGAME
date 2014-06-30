using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTowerBossSkott : FiendeSkott
    {
        public StoneTowerBossSkott(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(354, 42, 5, 5));
            Position = new Vector2(-100, -100);
            hastighet = 10;
            liv = 1;
            skada = 5;
        }
    }
}
