using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class LavaSkott : FiendeSkott
    {
        private int skjutTimer;
        public LavaSkott(Game1 game, Sprite spriteSheet, State presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(249, 28, 5, 5));
            Position = new Vector2(-100, -100);
            hastighet = 4;
            liv = 1;
            skada = 1;
        }
        public override void OnDeath()
        {
            LavaPool s = new LavaPool(game, spriteSheet, presentState);
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
            if (skjutTimer >= 1500)
            {
                liv = 0;
            }
        }
    }
}
