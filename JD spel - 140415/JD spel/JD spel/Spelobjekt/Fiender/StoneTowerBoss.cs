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
        private int antalSkottKvar;
        public StoneTowerBoss(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, gubbe, presentState)
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
                BigEnemyStone s1 = new BigEnemyStone(game, spriteSheet, presentState);
                s1.SkjutSkott(Position, riktningUp);
                presentState.addObjektLista.Add(s1);

                BigEnemyStone s2 = new BigEnemyStone(game, spriteSheet, presentState);
                s2.SkjutSkott(Position, riktningDown);
                presentState.addObjektLista.Add(s2);

                BigEnemyStone s3 = new BigEnemyStone(game, spriteSheet, presentState);
                s3.SkjutSkott(Position, riktningLeft);
                presentState.addObjektLista.Add(s3);

                BigEnemyStone s4 = new BigEnemyStone(game, spriteSheet, presentState);
                s4.SkjutSkott(Position, riktningRight);
                presentState.addObjektLista.Add(s4);

                stoneTimer = 0;
            }
            skjutTimer2 += gameTime.ElapsedGameTime.Milliseconds;
            skjutTimer3 += gameTime.ElapsedGameTime.Milliseconds;
            if (lever && skjutTimer2 >= 3000 && antalSkottKvar <= 0)
            {
                antalSkottKvar = 5;
                skjutTimer2 = 0;
            }
            if (antalSkottKvar >= 1 && skjutTimer3 >= 200)
            {
                VanligtFiendeSkott s = new VanligtFiendeSkott(game, spriteSheet, presentState);
                s.SkjutSkott(Position, riktning);
                game.levelState.addObjektLista.Add(s);
                skjutTimer3 = 0;
                antalSkottKvar -= 1;
            }
        }
    }
}