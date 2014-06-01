using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    //Klass dar jag placerat matematik som senare kunde komma tankas att behovas av ett flertal klasser
    public class GlobalFunctions
    {
        private static Random rand = new Random();

        //Skalar en Vector2 sa att absolutbeloppet av dess x och y blir 1, anvands framst for att se till7
        //att riktningen inte andrar absolutbelopp nar man andrar riktningen.
        public static Vector2 ScaleDirection(Vector2 dir)
        {
            Vector2 inVector = dir;

            double x = dir.X;
            double y = dir.Y;

            double scaleFactor = Math.Pow(x, 2) + Math.Pow(y, 2);

            dir.X = (float)Math.Sqrt(Math.Pow(x, 2) / scaleFactor);
            dir.Y = (float)Math.Sqrt(Math.Pow(y, 2) / scaleFactor);

            if (x < 0)
                dir.X = dir.X * -1;

            if (y < 0)
                dir.Y = dir.Y * -1;

            return dir;
        }

        //Anvands vid cirkular rorelse, for att kunna hantera den abrupta overgangen mellan 360 grader och 0 grader.
        public static double DeltaRadians(double rad1, double rad2)
        {
            double delta;

            double diff = Math.Abs(rad2 - rad1);

            if (diff <= Math.PI)
                delta = rad2 - rad1;
            else if (rad2 - rad1 < -Math.PI)
                delta = (rad2 - rad1) + 2 * Math.PI;
            else //(rad2 - rad1 > Math.PI) ar resten tror jag :)
                delta = (rad2 - rad1) - 2 * Math.PI;

            return delta;
        }

        //Omvandlar ett radianvarde till en Vector2
        public static Vector2 DirFromRadians(double radians)
        {
            Vector2 newDir = Vector2.Zero;

            newDir.X = (float)(Math.Cos(radians));
            newDir.Y = (float)(Math.Sin(radians));

            return newDir;
        }

        //Omvandlar en skalad Vector2 till radianer
        public static double RadiansFromDir(Vector2 dir)
        {
            double dirRadians;

            if (dir.Y > 0)
                dirRadians = Math.Acos(dir.X);
            else
                dirRadians = 2 * Math.PI - (Math.Acos(dir.X));

            if (dirRadians > 2 * Math.PI)
                dirRadians -= 2 * Math.PI;

            return dirRadians;
        }

        //Skapar riktning inom spridningsintervall angivet kring initialriktning.
        public static Vector2 SpreadDir(Vector2 dir, double spread)
        {
            double dirRadians = GlobalFunctions.RadiansFromDir(dir);
            dirRadians += ((rand.NextDouble() * spread) - spread / 2);

            Vector2 newDir = DirFromRadians(dirRadians);

            return newDir;
        }

        //Varies values randomly around a given value.
        //Can for example be used in differing weapons characteristics.
        public static float VaryValue(float initialVal, double percentVar)
        {
            if (percentVar > 1) { percentVar = 1; }
            if (percentVar < 0) { percentVar = 0; }

            float changedVal = initialVal + 2 * (float)percentVar * initialVal * (float)(rand.NextDouble() - 0.5);
            return changedVal;
        }

        
        /*
        public static GameObjectVertical ReturnClosestObject(GameObjectVertical object1, float range, List<GameObjectVertical> objects)
        {
            GameObjectVertical tempTarget = null;
            float tempDistance = range;

            foreach (GameObjectVertical obj in objects)
            {
                if (GlobalFunctions.ObjectDistance(object1, obj) < tempDistance
                     && GlobalFunctions.ObjectDistance(object1, obj) < range)
                {
                    tempTarget = obj;
                    tempDistance = GlobalFunctions.ObjectDistance(object1, tempTarget);
                }
            }

            return tempTarget;
        }

        public static GameObjectVertical ReturnClosestObject(GameObjectVertical object1, float range, List<GameObjectVertical> objects, string kind)
        {
            GameObjectVertical tempTarget = null;
            float tempDistance = range;

            foreach (GameObjectVertical obj in objects)
            {
                if (obj.ObjectClass.ToLower() == kind.ToLower() && GlobalFunctions.ObjectDistance(object1, obj) < tempDistance
                     && GlobalFunctions.ObjectDistance(object1, obj) < range)
                {
                    tempTarget = obj;
                    tempDistance = GlobalFunctions.ObjectDistance(object1, tempTarget);
                }
            }

            return tempTarget;
        }

        public static GameObjectVertical ReturnClosestObject(GameObjectVertical object1, float range, List<GameObjectVertical> objects, List<string> kinds)
        {
            GameObjectVertical tempTarget = null;
            float tempDistance = range;

            foreach (GameObjectVertical obj in objects)
            {
                for (int i = 0; i < kinds.Count; i++)
                {
                    if (obj.ObjectClass.ToLower() == kinds[i].ToLower() && GlobalFunctions.ObjectDistance(object1, obj) < tempDistance
                         && GlobalFunctions.ObjectDistance(object1, obj) < range)
                    {
                        tempTarget = obj;
                        tempDistance = GlobalFunctions.ObjectDistance(object1, tempTarget);
                    }
                }
            }

            return tempTarget;
        }

        //Calculates distance between two GameObjectVerticals
        public static float ObjectDistance(GameObjectVertical obj1, GameObjectVertical obj2)
        {
            float distance = Vector2.Distance(obj1.Position, obj2.Position);

            //float distance = (float)Math.Sqrt(Math.Pow((obj1.PositionX - obj2.PositionX), 2) + Math.Pow((obj1.PositionY - obj2.PositionY), 2));

            return distance;
        }
    */
    }
}