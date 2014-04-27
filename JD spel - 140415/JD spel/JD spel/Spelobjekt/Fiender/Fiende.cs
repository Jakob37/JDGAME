using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    public enum FiendeMovement
    { 
        Common,
        Follow,
        Static
    }

    class Fiende : SpelObjekt
    {
        protected Gubbe gubbe;
        protected FiendeMovement movement;

        public Fiende(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, presentState)
        { 
            this.gubbe = gubbe;
            lever = true;
            
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            
            if (liv <= 0)
            {
                lever = false;
            }

            switch (movement)
            {
                case FiendeMovement.Follow:
                    {
                        FollowGubbe();
                        break;
                    }
                case FiendeMovement.Common:
                    {
                        CommonMoment();
                        break;
                    }
                case FiendeMovement.Static:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void FollowGubbe()
        {
            riktning = new Vector2(gubbe.position.X - position.X, gubbe.position.Y - position.Y);
            riktning = GlobalFunctions.ScaleDirection(riktning);
        }

        private void CommonMoment()
        {

            float WindowWidth = game.Window.ClientBounds.Width;
            float WindowHeight = game.Window.ClientBounds.Height;

            if (position.X < 0)
            {
                riktning.X *= -1;
            }
            if (position.X > WindowWidth - bild.Width)
            {
                riktning.X *= -1;
            }

            if (position.Y < 0)
            {
                riktning.Y *= -1;
            }

            if (position.Y > WindowHeight - bild.Height)
            {
                riktning.Y *= -1;
            }

        }
    }
}
