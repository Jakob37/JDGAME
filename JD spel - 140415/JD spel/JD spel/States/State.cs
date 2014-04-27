using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    public class State
    {
        protected Game1 game;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public List<SpelObjekt> addObjektLista;
        protected List<SpelObjekt> spelObjektLista;
        protected List<SpelObjekt> leverInteLista;

        public State(Game1 game)
        {
            this.game = game;

            addObjektLista = new List<SpelObjekt>();
            spelObjektLista = new List<SpelObjekt>();
            leverInteLista = new List<SpelObjekt>();

        }

        public virtual void Initialize()
        {
            spelObjektLista.Clear();
        }
        
        public virtual void Uppdatera(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            UppdateraListor(gameTime);
            KollaKollisioner();
        }

        private void UppdateraListor(GameTime gameTime)
        {
            //Går igenom alla spelobjekt
            foreach (SpelObjekt s in spelObjektLista)
            {
                s.Uppdatera(gameTime);
            }

            if (addObjektLista.Count > 0)
            {
                foreach (SpelObjekt s in addObjektLista)
                {
                    spelObjektLista.Add(s);
                }
            }
            addObjektLista.Clear();
        }
        private void KollaKollisioner()
        {
            //Går igenom alla objekt, och kollar om dem krockar.
            //Lägger till döda i "leverInteLista"
            for (int n = 0; n < spelObjektLista.Count - 1; n++)
            {
                for (int m = n + 1; m < spelObjektLista.Count; m++)
                {
                    SpelObjekt objekt1 = spelObjektLista[n];
                    SpelObjekt objekt2 = spelObjektLista[m];

                    if (Kollisionshantering.ObjektKolliderar(spelObjektLista[n].GetKanter(), spelObjektLista[m].GetKanter()))
                    {
                        Kollisionshantering.KrockaObjekt(objekt1, objekt2);

                        if (objekt1.liv <= 0)
                            objekt1.lever = false;

                        if (objekt2.liv <= 0)
                            objekt2.lever = false;
                    }
                }
            }
            foreach (SpelObjekt obj in spelObjektLista)
            {
                if (obj.lever == false)
                {
                    leverInteLista.Add(obj);
                }
            }

            //Tar bort döda objekt från spelObjektLista
            foreach (SpelObjekt deadObjekt in leverInteLista)
            {
                spelObjektLista.Remove(deadObjekt);
            }
            leverInteLista.Clear();
        }

        public virtual void Rita(SpriteBatch spriteBatch)
        {
            foreach (SpelObjekt s in spelObjektLista)
            {
                s.Rita(spriteBatch);
            }
        }
    }
}
