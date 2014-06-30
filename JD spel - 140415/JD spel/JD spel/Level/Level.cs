using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD_spel
{
    public abstract class Level
    {
        protected List<SpelObjekt> spelObjektLista;
        protected LevelKnapp levelKnapp;

        public Level()
        { }

        public void AddLevelButton(LevelKnapp levelKnapp)
        {
            this.levelKnapp = levelKnapp;
        }

        public void Initialize(RunningState state)
        {
            foreach (SpelObjekt obj in spelObjektLista)
            {
                obj.Initialize(state);
            }
        }

        public List<SpelObjekt> GetLevel()
        {
            return spelObjektLista;
        }

        public void MarkFail()
        {
            if (levelKnapp != null)
                levelKnapp.IncreaseLoseCount();
        }

        public void MarkWin()
        {
            if (levelKnapp != null)
                levelKnapp.IncreaseWinCount();        
        }
    }
}
