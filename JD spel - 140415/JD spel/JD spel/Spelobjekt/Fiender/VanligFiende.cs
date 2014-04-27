using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JD_spel
{
    class VanligFiende : Fiende
    {
        public VanligFiende(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            bild = spriteSheet.GetSubSprite(new Rectangle(0, 0, 21, 25));
            hastighet = 2F;
            movement = FiendeMovement.Common;
            
            liv = 50;
            skada = 1;

            riktning = new Vector2((float)(random.NextDouble() * 2 - 1),
                (float)(random.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);
        }
    }
}