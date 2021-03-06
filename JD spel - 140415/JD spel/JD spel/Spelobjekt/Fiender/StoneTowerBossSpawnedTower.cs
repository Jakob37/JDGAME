﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTowerBossSpawnedTower : Fiende
    {
        private int skjutTimer;
        public StoneTowerBossSpawnedTower(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(370, 48, 20, 20));
            Position = new Vector2(-100, -100);
            movement = FiendeMovement.Follow;
            hastighet = 0;
            liv = 100;
            skada = 1;
        }
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            Skjuta(gameTime);
        }
        private void Skjuta(GameTime gameTime)
        {
            skjutTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (skjutTimer >= 3000)
            {
                StoneTowerBossSkott s = new StoneTowerBossSkott(game, spriteSheet);
                s.SkjutSkott(this, riktning);
                game.levelState.addObjektLista.Add(s);
                skjutTimer = 0;
            }
        }

    }
}
