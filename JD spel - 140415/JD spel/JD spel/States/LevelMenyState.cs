using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JD_spel
{
    public class LevelMenyState : State
    {
        private Sprite spriteSheet;
        private List<Clickable> knappar;
        private SpriteFont font;

        private int textTimer;

        public LevelMenyState(Game1 game, Sprite spriteSheet)
            : base(game)
        {
            this.spriteSheet = spriteSheet;
            font = game.Content.Load<SpriteFont>("menyFont");

            knappar = new List<Clickable>();


            LevelMenyExitKnapp levelExit = new LevelMenyExitKnapp(game, spriteSheet, new Vector2(410, 550));
            levelExit.Initialize();

            Level1Knapp level1 = new Level1Knapp(game, spriteSheet, new Vector2(200, 200));
            level1.Initialize();

            Level2Knapp level2 = new Level2Knapp(game, spriteSheet, new Vector2(300, 200));
            level2.Initialize();

            Level3Knapp level3 = new Level3Knapp(game, spriteSheet, new Vector2(400, 200));
            level3.Initialize();

            Level4Knapp level4 = new Level4Knapp(game, spriteSheet, new Vector2(500, 200));
            level4.Initialize();

            Level5Knapp level5 = new Level5Knapp(game, spriteSheet, new Vector2(600, 200));
            level5.Initialize();

            Level6Knapp level6 = new Level6Knapp(game, spriteSheet, new Vector2(700, 200));
            level6.Initialize();

            knappar.Add(level1);
            knappar.Add(level2);
            knappar.Add(level3);
            knappar.Add(level4);
            knappar.Add(level5);
            knappar.Add(level6);

            knappar.Add(levelExit);

            textTimer = 0;
        }

        public override void Initialize()
        {

        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);

            foreach (Clickable knapp in knappar)
            {
                knapp.Update(gameTime);
            }

            textTimer += gameTime.ElapsedGameTime.Milliseconds;
        }

        public override void Rita(SpriteBatch spriteBatch)
        {
            base.Rita(spriteBatch);
           
            spriteBatch.DrawString(font, "Choose Level", new Vector2(200, 100), Color.DarkSlateGray);

            foreach (Clickable knapp in knappar)
            {
                knapp.Draw(spriteBatch);
            }
        }
    }
}
