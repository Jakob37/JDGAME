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
        
        
        protected Vector2 position;
        public virtual Vector2 Position { 
            get 
            { 
                return position; 
            } 
            set 
            { 
                position = value; 
            } 
        }

        public float PositionX
        {
            get
            {
                return position.X;
            }
            set
            {
                position.Y = value;
            }
        }

        public float PositionY
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }

        public Boolean immobile = false;

        public Vector2 Center { 
            get 
            { 
                return new Vector2(Position.X + bild.Width / 2, Position.Y + bild.Height / 2); 
            }
            set
            {
                Position = new Vector2(value.X - bild.Width / 2, value.Y - bild.Height / 2);
            }
        }

        public Vector2 riktning;
        public Boolean lever;
        public float hastighet;
        public float liv;
        public float skada;

        private const float repellingForce = 1f;

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
            Position += riktning * hastighet;

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
                spriteBatch.Draw(bild.Texture, Position, bild.SourceRectangle, Color.White);
            }

        }

        public Rectangle GetKanter()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, bild.Width, bild.Height);
        }

        public virtual void SkadaObjekt(float skada)
        {
            liv -= skada;
        }

        public void SetExternalRandom(Random rand)
        {
            random = rand;
        }

        public void SetRandomDirection(Random rand)
        {
            riktning = new Vector2((float)(rand.NextDouble() * 2 - 1),
                (float)(rand.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);
        }

        public void SetRandomDirection()
        {
            riktning = new Vector2((float)(random.NextDouble() * 2 - 1),
                (float)(random.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);
        }

        public void PushAwayFrom(SpelObjekt other)
        {
            // För att undvika att de hamnar på varandra.
            // Leder till division med noll annars.
            if (position == other.Position)
                PositionX += 1;

            Vector2 dirAgainstOther = GetDirection(other);
            Position -= dirAgainstOther * repellingForce;
        }

        private Vector2 GetDirection(SpelObjekt other)
        {
            Vector2 dir = new Vector2(other.Position.X - Position.X, other.Position.Y - Position.Y);
            return GlobalFunctions.ScaleDirection(dir);
        }

        public virtual void OnDeath()
        { }
    }
}
