using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level6 : Level
    {
        public Level6(Game1 game, Sprite spriteSheet, Random random1)
            : base()
        {
            spelObjektLista = new List<SpelObjekt>();

            for (int n = 0; n < 20; n++)
            {
                LavaEnemy f1 = new LavaEnemy(game, spriteSheet);
                f1.Position = new Vector2(random1.Next(870), random1.Next(670));
                f1.SetRandomDirection(random1);
                spelObjektLista.Add(f1);
            }
        }

    }
}
