using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StoneTowerBossSpawnedTower : FiendeSkott
    {
        private int skjutTimer;
        public StoneTowerBossSpawnedTower(Game1 game, Sprite spriteSheet, RunningState presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(370, 48, 20, 20));
            Position = new Vector2(-100, -100);
            //movement = FiendeMovement.Follow;
            hastighet = 0;
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
            if (skjutTimer >= 3000)
            {
                StoneTowerBossSkott s = new StoneTowerBossSkott(game, spriteSheet, presentState);
                s.SkjutSkott(this, riktning);
                game.levelState.addObjektLista.Add(s);
                skjutTimer = 0;
            }
        }

    }
}
