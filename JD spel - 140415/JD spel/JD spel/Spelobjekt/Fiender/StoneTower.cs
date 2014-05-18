﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTower : Fiende
    {
        private int skjutTimer;
        public StoneTower(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base (game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(275, 7, 39, 39));
            hastighet = 0;
            movement = FiendeMovement.Static;
            liv = 1000;
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
            Vector2 riktningUp = new Vector2(0, -1);
            Vector2 riktningDown = new Vector2(0, 1);
            Vector2 riktningLeft = new Vector2(-1, 0);
            Vector2 riktningRight = new Vector2(1, 0);
            if (skjutTimer >= 1000)
            {
                BigEnemyStone s1 = new BigEnemyStone(game, spriteSheet, presentState);
                s1.SkjutSkott(position, riktningUp);
                presentState.addObjektLista.Add(s1);

                BigEnemyStone s2 = new BigEnemyStone(game, spriteSheet, presentState);
                s2.SkjutSkott(position, riktningDown);
                presentState.addObjektLista.Add(s2);

                BigEnemyStone s3 = new BigEnemyStone(game, spriteSheet, presentState);
                s3.SkjutSkott(position, riktningLeft);
                presentState.addObjektLista.Add(s3);

                BigEnemyStone s4 = new BigEnemyStone(game, spriteSheet, presentState);
                s4.SkjutSkott(position, riktningRight);
                presentState.addObjektLista.Add(s4);

                skjutTimer = 0;
            }
        }
    }
}