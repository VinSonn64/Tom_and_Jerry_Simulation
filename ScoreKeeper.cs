using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TomandJerrySimulation
{
    class ScoreKeeper : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Vector2[] Score;
        
        SpriteFont myFont;
        SpriteBatch scoreSpritebatch;
        Cheese cheese;
        public string endgameMessage;
        public int finalscore;

        public ScoreKeeper(Game game, Cheese cheese) : base(game)
        { this.cheese=cheese;}

        protected override void LoadContent()
        {
            scoreSpritebatch = new SpriteBatch(GraphicsDevice);
            myFont = this.Game.Content.Load<SpriteFont>("myFont");
            
            finalscore = 0;
            endgameMessage = "";
            Score = new Vector2[cheese.CheeseList.Count()];
            Score[0] = new Vector2(10, 50);
            Score[1] = new Vector2(10, 80);
            Score[2] = new Vector2(10, 110);
            Score[3] = new Vector2(10, 140);
            Score[4] = new Vector2(10, 170);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            scoreSpritebatch.Begin();
            scoreSpritebatch.DrawString(myFont, "Score: " + finalscore, new Vector2(0, 30), Color.Black);
            scoreSpritebatch.DrawString(myFont, "Use Keyboard Arrows or GamepadStick to Move.", new Vector2(200, 0), Color.Black);
            scoreSpritebatch.DrawString(myFont, "Grab all the Cheese and Hide in the Holes to avoid Tom.", new Vector2(170, 20), Color.Black);
            scoreSpritebatch.DrawString(myFont, endgameMessage, new Vector2(300, 300), Color.Black);
            scoreSpritebatch.End();
            base.Draw(gameTime);
        }
    }
}
