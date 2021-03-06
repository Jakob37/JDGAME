﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    public abstract class RunningState : State
    {
        public List<SpelObjekt> addObjektLista;
        protected List<SpelObjekt> spelObjektLista;
        protected List<SpelObjekt> leverInteLista;

        public RunningState(Game1 game)
            : base(game)
        {
            addObjektLista = new List<SpelObjekt>();
            spelObjektLista = new List<SpelObjekt>();
            leverInteLista = new List<SpelObjekt>();

        }

        public override void Initialize()
        {
            base.Initialize();

            spelObjektLista.Clear();
            game.Player1.Initialize(this);
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);

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
                    obj.OnDeath();
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

        public override void Rita(SpriteBatch spriteBatch)
        {
            base.Rita(spriteBatch);

            foreach (SpelObjekt s in spelObjektLista)
            {
                s.Rita(spriteBatch);
            }
        }
    }
}
