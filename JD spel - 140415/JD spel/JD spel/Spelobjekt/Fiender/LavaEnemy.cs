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
        public LavaEnemy(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(249, 5, 20, 20));
            hastighet = 1;
            movement = FiendeMovement.Follow;
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
            if (skjutTimer >= 1500)
            {
                LavaSkott s = new LavaSkott(game, spriteSheet, presentState);
                s.SkjutSkott(position, riktning);
                presentState.addObjektLista.Add(s);
                skjutTimer = 0;
            }
        }
    }
}
