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


        public FiendeMyrEgg(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = new Sprite(game.Content.Load<Texture2D>("AntEnemy"));

            bild = spriteSheet.GetSubSprite(new Rectangle(260, 0, 40, 40));
            
            hastighet = 0.1f;
            movement = FiendeMovement.Common; 

            liv = 150;
            skada = 1;

            riktning = new Vector2((float)(random.NextDouble() * 2 - 1),
                (float)(random.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);

            spawnCounter = 5000 + (int)(5000 * random.NextDouble());
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
            for (int n = 0; n < 10; n++)
            {
                FiendeMyra myra = new FiendeMyra(game, spriteSheet, gubbe, presentState);
                myra.position = position;
                myra.SetExternalRandom(random);
                myra.SetRandomDirection();
                presentState.addObjektLista.Add(myra);
            }
        }

        public override void Rita(SpriteBatch spriteBatch)
        {
            if (lever)
            {
                spriteBatch.Draw(bild.Texture, position, bild.SourceRectangle, Color.White);
            } 
        }

    }
}
