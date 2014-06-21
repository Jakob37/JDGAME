using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTowerBossSpawnSkott : FiendeSkott
    {
        private int skjutTimer;
        public StoneTowerBossSpawnSkott(Game1 game, Sprite spriteSheet, RunningState presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(354, 42, 5, 5));
            Position = new Vector2(-100, -100);
            hastighet = 10;
            liv = 1;
            skada = 1;
        }
        public override void OnDeath()
        {
            StoneTowerBossSpawnedTower s = new StoneTowerBossSpawnedTower(game, spriteSheet, presentState);
            s.SkjutSkott(this, riktning);
            presentState.addObjektLista.Add(s);
        }
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            Explode(gameTime);
        }

        private void Explode(GameTime gameTime)
        {
            skjutTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (skjutTimer >= 350)
            {
                liv = 0;
            }
        }
    }
}

