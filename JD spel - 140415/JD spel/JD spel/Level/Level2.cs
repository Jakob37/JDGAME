using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level2 : Level
    {

        public Level2(Game1 game, Sprite spriteSheet, Random random1)
            : base()
        {
            spelObjektLista = new List<SpelObjekt>();

            //Boss
            FirstBoss f1 = new FirstBoss(game, spriteSheet);
            f1.Position = new Vector2(random1.Next(870), random1.Next(670));
            spelObjektLista.Add(f1);
        }

    }
}
