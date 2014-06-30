using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level3 : Level
    {

        public Level3(Game1 game, Sprite spriteSheet, Random random1)
            : base()
        {
            spelObjektLista = new List<SpelObjekt>();

            for (int n = 0; n < 50; n++)
            {
                VanligFiende f1 = new VanligFiende(game, spriteSheet);
                f1.Position = new Vector2(random1.Next(870), random1.Next(670));
                f1.SetRandomDirection(random1);
                spelObjektLista.Add(f1);
            }
        }

    }
}
