using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD_spel
{
    class SpelarSkott : Skott
    {
        protected static int energiKostnad;
        public static int GetEnergiKostnad() { return energiKostnad; }

        public SpelarSkott(Game1 game, Sprite spriteSheet, RunningState presentState)
            : base(game, spriteSheet, presentState)
        { 
            
        }
    }
}
