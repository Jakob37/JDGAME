﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class BigStoneSkott : SpelarSkott
    {
        private List<SpelObjekt> oneTimeDamageLista;

        public BigStoneSkott(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(324, 21, 13, 13));
            position = new Vector2(-100, -100);
            hastighet = 2;
            liv = 10000;
            skada = 100;
            energiKostnad = 50;
            range = 400;
            oneTimeDamageLista = new List<SpelObjekt>();
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            
            
        }
        
        public override bool CanDamage(SpelObjekt other)
        {
            if (!oneTimeDamageLista.Contains(other))
            {
                oneTimeDamageLista.Add(other);
                return true;
            }
            else
            {
                return false;
            }
        }
         
    }
}