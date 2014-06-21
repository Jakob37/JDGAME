using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class MinFiende : Fiende
    {
        private int skjutTimer;
        public MinFiende(Game1 game, Sprite spriteSheet, Gubbe gubbe, RunningState presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(117, 0, 18, 27));
            hastighet = 1.5F;
            movement = FiendeMovement.Common;

            liv = 30;
            skada = 1;

            Random random = new Random();
            riktning = new Vector2((float)(random.NextDouble() * 2 - 1),
                (float)(random.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);
        }
        
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            PlaceMine(gameTime);
        }
        
        private void PlaceMine(GameTime gameTime)
        {
            skjutTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (lever && skjutTimer >= 5000)
            {
                Mina s = new Mina(game, spriteSheet, gubbe, presentState);
                s.Position = Position;
                presentState.addObjektLista.Add(s);
                skjutTimer = 0;
            }
        }
    }
}
