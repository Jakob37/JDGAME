using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class FiendeMyra : Fiende
    {
        public override Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        
        private Sprite sprite;
        private Vector2 center;

        private double eggLayingChance = 0.0004;

        public FiendeMyra(Game1 game, Sprite spriteSheet, Gubbe gubbe, RunningState presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(183, 0, 30, 46));

            hastighet = 6;
            movement = FiendeMovement.Common;

            liv = 1;
            skada = 10;

            riktning = new Vector2((float)(random.NextDouble() * 2 - 1),
                (float)(random.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);

            center = new Vector2(bild.Width / 2, bild.Height / 2);
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);

            if (random.NextDouble() > 0.98)
            {
                SetRandomDirection();
            }

            if (random.NextDouble() > (1 - eggLayingChance))
            {
                LayEgg();
            }
        }

        private void LayEgg()
        {
            FiendeMyrEgg egg = new FiendeMyrEgg(game, spriteSheet, gubbe, presentState);
            egg.Position = Position;
            egg.SetExternalRandom(random);
            egg.SetRandomDirection();
            presentState.addObjektLista.Add(egg);
        }

        public override void Rita(SpriteBatch spriteBatch)
        {
            if (lever)
            {
                float degrees = (float)(GlobalFunctions.RadiansFromDir(riktning) + (Math.PI / 2));
                spriteBatch.Draw(bild.Texture, Position, bild.SourceRectangle, Color.White, degrees, center, 0.5f, SpriteEffects.None, 0.5f);
            }
        }
    }
}
