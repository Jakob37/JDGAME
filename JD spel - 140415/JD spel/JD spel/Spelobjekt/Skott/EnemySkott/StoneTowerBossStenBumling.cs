using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTowerBossStenBumling : FiendeSkott
    {
        public StoneTowerBossStenBumling(Game1 game, Sprite spriteSheet, State presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(329, 36, 20, 20));
            Position = new Vector2(-100, -100);
            hastighet = 2;
            liv = 1;
            skada = 30;
        }
    }
}