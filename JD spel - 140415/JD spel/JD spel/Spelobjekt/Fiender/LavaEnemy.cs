using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class LavaEnemy : Fiende
    {
        private int skjutTimer;
        public LavaEnemy(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(249, 5, 20, 20));
            hastighet = 1;
            movement = FiendeMovement.Follow;
            liv = 30;
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
            if (skjutTimer >= 1500)
            {
                LavaSkott s = new LavaSkott(game, spriteSheet);
                s.Initialize(runningState);
                s.SkjutSkott(this, riktning);
                runningState.addObjektLista.Add(s);
                skjutTimer = 0;
            }
        }
    }
}
