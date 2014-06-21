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

            Random random = new Random();

            LevelMenyExitKnapp levelExit = new LevelMenyExitKnapp(game, spriteSheet, new Vector2(410, 550));
            levelExit.Initialize();

            Level1 lv1 = new Level1(game, spriteSheet, random);
            Level1Knapp level1knapp = new Level1Knapp(game, spriteSheet, new Vector2(200, 200), lv1);
            level1knapp.Initialize();
            lv1.AddLevelButton(level1knapp);

            Level2 lv2 = new Level2(game, spriteSheet, random);
            Level2Knapp level2knapp = new Level2Knapp(game, spriteSheet, new Vector2(300, 200), lv2);
            level2knapp.Initialize();
            lv2.AddLevelButton(level2knapp);

            Level3 lv3 = new Level3(game, spriteSheet, random);
            Level3Knapp level3knapp = new Level3Knapp(game, spriteSheet, new Vector2(400, 200), lv3);
            level3knapp.Initialize();
            lv3.AddLevelButton(level3knapp);

            Level4 lv4 = new Level4(game, spriteSheet, random);
            Level4Knapp level4knapp = new Level4Knapp(game, spriteSheet, new Vector2(500, 200), lv4);
            level4knapp.Initialize();
            lv4.AddLevelButton(level4knapp);

            Level5 lv5 = new Level5(game, spriteSheet, random);
            Level5Knapp level5knapp = new Level5Knapp(game, spriteSheet, new Vector2(600, 200), lv5);
            level5knapp.Initialize();
            lv5.AddLevelButton(level5knapp);

            Level6 lv6 = new Level6(game, spriteSheet, random);
            Level6Knapp level6knapp = new Level6Knapp(game, spriteSheet, new Vector2(700, 200), lv6);
            level6knapp.Initialize();
            lv6.AddLevelButton(level6knapp);

            LevelTest lvTest = new LevelTest(game, spriteSheet, random);
            TestLevelKnapp levelTestknapp = new TestLevelKnapp(game, spriteSheet, new Vector2(800, 600), lvTest);
            levelTestknapp.Initialize();
            lvTest.AddLevelButton(levelTestknapp);

            knappar.Add(level1knapp);
            knappar.Add(level2knapp);
            knappar.Add(level3knapp);
            knappar.Add(level4knapp);
            knappar.Add(level5knapp);
            knappar.Add(level6knapp);
            knappar.Add(levelTestknapp);

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
