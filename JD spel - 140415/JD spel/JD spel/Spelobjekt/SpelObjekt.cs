using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JD_spel
{
    public class SpelObjekt
    {
        protected Game1 game;
        protected Sprite spriteSheet;
        public Sprite bild;
        public Vector2 position;
        public Vector2 riktning;
        public Boolean lever;
        public float hastighet;
        public float liv;
        public float skada;

        protected Random random;
        protected State presentState;


        public SpelObjekt(Game1 game, Sprite spriteSheet, State presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            skada = 0;
            lever = true;
            hastighet = 0;

            random = new Random();
            this.presentState = presentState;
        }

        public virtual void Uppdatera(GameTime gameTime)
        {
            position += riktning * hastighet;


            if (liv <= 0)
            {
                liv = 0;
                lever = false;
            }
        }

        public virtual void Rita(SpriteBatch spriteBatch) 
        {
            if (lever)
            {
                spriteBatch.Draw(bild.Texture, position, bild.SourceRectangle, Color.White);
            } 
        
        }

        public Rectangle GetKanter()
        {
            return new Rectangle((int)position.X, (int)position.Y, bild.Width, bild.Height);
        }

        public virtual void SkadaObjekt(float skada)
        {
            liv -= skada;
        }

        public void SetRandomDirection(Random rand)
        {
            riktning = new Vector2((float)(rand.NextDouble() * 2 - 1),
                (float)(rand.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);
        }
    }
}
