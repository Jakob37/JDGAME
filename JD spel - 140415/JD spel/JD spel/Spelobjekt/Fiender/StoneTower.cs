using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTower : Fiende
    {
        private int skjutTimer;
        public StoneTower(Game1 game, Sprite spriteSheet)
            : base (game, spriteSheet)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(275, 7, 39, 39));
            hastighet = 0;
            movement = FiendeMovement.Static;
            liv = 200;
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
            skjutTimer += gameTime.ElapsedGameTime.Milliseconds;
            Vector2 riktningUp = new Vector2(0, -1);
            Vector2 riktningDown = new Vector2(0, 1);
            Vector2 riktningLeft = new Vector2(-1, 0);
            Vector2 riktningRight = new Vector2(1, 0);
            if (skjutTimer >= 1000)
            {
                BigEnemyStone s1 = new BigEnemyStone(game, spriteSheet);
                s1.SkjutSkott(this, riktningUp);
                runningState.addObjektLista.Add(s1);

                BigEnemyStone s2 = new BigEnemyStone(game, spriteSheet);
                s2.SkjutSkott(this, riktningDown);
                runningState.addObjektLista.Add(s2);

                BigEnemyStone s3 = new BigEnemyStone(game, spriteSheet);
                s3.SkjutSkott(this, riktningLeft);
                runningState.addObjektLista.Add(s3);

                BigEnemyStone s4 = new BigEnemyStone(game, spriteSheet);
                s4.SkjutSkott(this, riktningRight);
                runningState.addObjektLista.Add(s4);

                skjutTimer = 0;
            }
        }
    }
}
