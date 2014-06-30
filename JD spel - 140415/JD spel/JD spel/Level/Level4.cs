using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level4 : Level
    {

        public Level4(Game1 game, Sprite spriteSheet, Random random1)
            : base()
        {
            spelObjektLista = new List<SpelObjekt>();

            for (int n = 0; n < 10; n++)
            {
                FiendeMyra myra = new FiendeMyra(game, spriteSheet);
                myra.Position = new Vector2(random1.Next(870), random1.Next(670));
                myra.SetExternalRandom(random1);
                myra.SetRandomDirection();
                spelObjektLista.Add(myra);
            }

            FiendeMyrEgg egg = new FiendeMyrEgg(game, spriteSheet);
            egg.Position = new Vector2(300, 300);
            spelObjektLista.Add(egg);
        }

    }
}
