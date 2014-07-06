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
        #region variabler
        protected Game1 game;
        protected Sprite spriteSheet;
        public Sprite bild;

        protected float transparency;
        protected float drawLayer;

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
        public virtual float PositionX
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }
        public virtual float PositionY
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

        public Vector2 CenterOffset
        {
            get
            {
                return new Vector2(bild.Width / 2, bild.Height / 2);
            }
        }

        protected Vector2 riktning;
        public Vector2 Riktning
        {
            get 
            {
                return riktning;
            }
        }

        private double radians;
        public double Radians
        {
            get
            {
                return radians;
            }
        }

        public Boolean lever;
        public float hastighet;
        public float liv;
        public float skada;

        private const float repellingForce = 1f;

        protected Random random;
        protected RunningState runningState;
        #endregion

        public SpelObjekt(Game1 game, Sprite spriteSheet)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            transparency = 1f;

            skada = 0;
            lever = true;
            hastighet = 0;

            random = new Random();
        }

        public virtual void Initialize(RunningState runningState)
        {
            this.runningState = runningState;
        }

        public virtual void Uppdatera(GameTime gameTime)
        {
            Position += riktning * hastighet;

            if (liv <= 0)
            {
                liv = 0;
                lever = false;
            }

            if (IsOutside())
            {
                lever = false;
            }

            SetRadians();
        }

        private void SetRadians()
        {
            if (Riktning.Y > 0)
                radians = Math.Acos(Riktning.X);
            else
                radians = 2 * Math.PI - (Math.Acos(Riktning.X));

            if (Radians >= 2 * Math.PI)
                radians -= 2 * Math.PI;
        }

        public virtual void Rita(SpriteBatch spriteBatch)
        {
            if (lever)
            {
                spriteBatch.Draw(bild.Texture, position, bild.SourceRectangle, Color.White * transparency, 0.0f, CenterOffset, 1f, SpriteEffects.None, 0.5f);
            }
        }

        public Rectangle GetKanter()
        {
            return new Rectangle((int)Position.X - bild.Width / 2, (int)Position.Y - bild.Height / 2, bild.Width, bild.Height);
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

        public virtual Boolean CanDamage(SpelObjekt other)
        {
            return true;
        }

        public Boolean IsOutside()
        {
            float windowWidth = game.Window.ClientBounds.Width;
            float windowHeight = game.Window.ClientBounds.Height;

            float width = bild.Width;
            float height = bild.Height;

            float limit = 100;

            if (PositionX < -limit
                || PositionY < -limit
                || PositionX + width > windowWidth + limit
                || PositionY + height > windowHeight + limit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
