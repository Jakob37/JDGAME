﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class BigEnemyStone : Skott
    {
        public BigEnemyStone(Game1 game, Sprite spriteSheet, State presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(324, 21, 13, 13));
            position = new Vector2(-100, -100);
            hastighet = 3;
            liv = 1;
            skada = 20;
        }
    }
}