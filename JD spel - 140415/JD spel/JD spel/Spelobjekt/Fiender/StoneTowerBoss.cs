using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTowerBoss : Fiende
    {
        private int stoneTimer;
        private int skjutTimer2;
        private int skjutTimer3;
        private int skjutTimer4;
        private int antalSkottKvar;
        public StoneTowerBoss(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(394,4,70,70));
            hastighet = 0;
            movement = FiendeMovement.Follow;
            liv = 10000;
            skada = 1;
            immobile = true;
        }
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            Skjuta(gameTime);
        }
        private void Skjuta(GameTime gameTime)
        {
            stoneTimer += gameTime.ElapsedGameTime.Milliseconds;
            Vector2 riktningUp = new Vector2(0, -1);
            Vector2 riktningDown = new Vector2(0, 1);
            Vector2 riktningLeft = new Vector2(-1, 0);
            Vector2 riktningRight = new Vector2(1, 0);
            if (stoneTimer >= 1500)
            {
                StoneTowerBossStenBumling s1 = new StoneTowerBossStenBumling(game, spriteSheet, runningState);
                s1.Initialize(runningState);
                s1.SkjutSkott(this, riktningUp);
                runningState.addObjektLista.Add(s1);

                StoneTowerBossStenBumling s2 = new StoneTowerBossStenBumling(game, spriteSheet, runningState);
                s2.Initialize(runningState);
                s2.SkjutSkott(this, riktningDown);
                runningState.addObjektLista.Add(s2);

                StoneTowerBossStenBumling s3 = new StoneTowerBossStenBumling(game, spriteSheet, runningState);
                s3.Initialize(runningState);
                s3.SkjutSkott(this, riktningLeft);
                runningState.addObjektLista.Add(s3);

                StoneTowerBossStenBumling s4 = new StoneTowerBossStenBumling(game, spriteSheet, runningState);
                s4.Initialize(runningState);
                s4.SkjutSkott(this, riktningRight);
                runningState.addObjektLista.Add(s4);

                stoneTimer = 0;
            }
            skjutTimer2 += gameTime.ElapsedGameTime.Milliseconds;
            skjutTimer3 += gameTime.ElapsedGameTime.Milliseconds;
            skjutTimer4 += gameTime.ElapsedGameTime.Milliseconds;
            if (lever && skjutTimer2 >= 3000 && antalSkottKvar <= 0)
            {
                antalSkottKvar = 5;
                skjutTimer2 = 0;
            }
            if (antalSkottKvar >= 1 && skjutTimer3 >= 200)
            {
                StoneTowerBossSkott s = new StoneTowerBossSkott(game, spriteSheet);
                s.SkjutSkott(this, riktning);
                game.levelState.addObjektLista.Add(s);
                skjutTimer3 = 0;
                antalSkottKvar -= 1;
            }
            
            if (skjutTimer4 >= 12000)
            {
                StoneTowerBossSpawnSkott s = new StoneTowerBossSpawnSkott(game, spriteSheet);
                s.Initialize(runningState);
                s.SkjutSkott(this, riktning);
                game.levelState.addObjektLista.Add(s);               
                skjutTimer4 = 0;
            }
            
        }
    }
}