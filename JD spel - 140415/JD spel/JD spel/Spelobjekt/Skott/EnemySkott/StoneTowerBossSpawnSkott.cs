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
        public StoneTowerBossSpawnSkott(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
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
            //FiendeTorn torn = new FiendeTorn(game, spriteSheet);
            //torn.Initialize(runningState);
            //torn.Position = position;
            //runningState.addObjektLista.Add(torn);

            StoneTowerBossSpawnedTower s = new StoneTowerBossSpawnedTower(game, spriteSheet);
            s.Initialize(runningState);
            s.SkjutSkott(this, riktning);
            runningState.addObjektLista.Add(s);
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

