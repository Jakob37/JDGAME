using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    class FiendeTorn : Fiende
    {
        private KeyboardState keyboardState;
        private int skjutTimer;
        
        public FiendeTorn(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(50, 0, 29, 29));
            hastighet = 0;
            movement = FiendeMovement.Follow;
            liv = 100;
            skada = 1;
            immobile = true;
        }
        
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            keyboardState = Keyboard.GetState();
            Skjuta(gameTime);
        }
        
        private void Skjuta(GameTime gameTime)
        {
            skjutTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (keyboardState.IsKeyDown(Keys.LeftShift) && lever && skjutTimer >= 500)
            {
                VanligtFiendeSkott s = new VanligtFiendeSkott(game, spriteSheet, presentState);
                s.SkjutSkott(Position, riktning);
                presentState.addObjektLista.Add(s);
                skjutTimer = 0;
            }
        }
    }
}