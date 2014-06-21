using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Mina : Fiende
    {
        public Mina(Game1 game, Sprite spriteSheet, Gubbe gubbe, RunningState presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(85, 4, 27, 22));
            movement = FiendeMovement.Static;
            immobile = true;

            liv = 1;
            skada = 10;
        }
    }
}
