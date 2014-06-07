using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class FiendeMyrEgg : Fiende
    {
        private int spawnCounter;
        private int numberOfAnts;

        public FiendeMyrEgg(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(188, 52, 40, 40));
            
            hastighet = 0.1f;
            movement = FiendeMovement.Common; 

            liv = 80;
            skada = 1;

            riktning = new Vector2((float)(random.NextDouble() * 2 - 1),
                (float)(random.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);

            spawnCounter = 5000 + (int)(5000 * random.NextDouble());

            numberOfAnts = random.Next(5) + 5;
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);

            spawnCounter -= gameTime.ElapsedGameTime.Milliseconds;

            if (spawnCounter <= 0)
            {
                Spawn();
                liv = 0;
            }
        }

        private void Spawn()
        {
            for (int n = 0; n < numberOfAnts; n++)
            {
                FiendeMyra myra = new FiendeMyra(game, spriteSheet, gubbe, presentState);
                myra.Position = Position;
                myra.SetExternalRandom(random);
                myra.SetRandomDirection();
                presentState.addObjektLista.Add(myra);
            }
        }

        public override void Rita(SpriteBatch spriteBatch)
        {
            if (lever)
            {
                spriteBatch.Draw(bild.Texture, Position, bild.SourceRectangle, Color.White);
            } 
        }

    }
}
