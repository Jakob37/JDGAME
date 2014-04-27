using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Kollisionshantering
    {
        //Kollar om två rektanglar krockar
        public static Boolean ObjektKolliderar(Rectangle obj1Kanter, Rectangle obj2Kanter)
        {
            if (obj1Kanter.Intersects(obj2Kanter))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Kollar skada
        public static void KrockaObjekt(SpelObjekt objekt1, SpelObjekt objekt2)
        {
            if ((objekt1 is Fiende && objekt2 is Gubbe) || (objekt1 is Gubbe && objekt2 is Fiende))
            {
                objekt1.SkadaObjekt(objekt2.skada);
                objekt2.SkadaObjekt(objekt1.skada);
                //objekt1.liv -= objekt2.skada;
                //objekt2.liv -= objekt1.skada;
            }
            else if ((objekt1 is Fiende && objekt2 is SpelarSkott) || (objekt1 is SpelarSkott && objekt2 is Fiende))
            {
                objekt1.SkadaObjekt(objekt2.skada);
                objekt2.SkadaObjekt(objekt1.skada);
                
                //objekt1.liv -= objekt2.skada;
                //objekt2.liv -= objekt1.skada;
            }
            else if ((objekt1 is Gubbe && objekt2 is FiendeSkott) || (objekt1 is FiendeSkott && objekt2 is Gubbe))
            {
                objekt1.SkadaObjekt(objekt2.skada);
                objekt2.SkadaObjekt(objekt1.skada);
                
                //objekt1.liv -= objekt2.skada;
                //objekt2.liv -= objekt1.skada;
            }
        }

    }
}
