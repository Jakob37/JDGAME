﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JD_spel
{
    class BasicLaser : SpelarSkott
    {
        public BasicLaser(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(180, 0, 2, 14));
            Position = new Vector2(-100, -100);
            hastighet = 5;
            liv = 1;
            skada = 5F;
            energiKostnad = 2;
            range = 300;
        }
    }
}
