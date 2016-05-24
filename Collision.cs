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
    class Collision : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch Cspritebatch;
        private Game game;
        private Tom tom;
        private Jerry jerry;
        private SteeringBehaviors sb;
        private SpriteFont myFont;
        private Cheese cheese;
        private HolesManager hm;
        ScoreKeeper score;


        public Rectangle TomBounds;
        public Rectangle JerryBounds;
        public Rectangle[] CheeseBounds;
        public Rectangle[] HoleBounds;



        public Collision(Game game, Tom tom, Jerry jerry, SteeringBehaviors sb, Cheese cheese, HolesManager hm, ScoreKeeper score)
            : base(game)
        {
            // TODO: Complete member initialization
            this.game = game;
            this.tom = tom;
            this.jerry = jerry;
            this.sb = sb;
            this.cheese = cheese;
            this.hm = hm;
            this.score = score;
        }

        protected override void LoadContent()
        {
            HoleBounds = new Rectangle[hm.HoleList.Count()];
            CheeseBounds = new Rectangle[cheese.CheeseList.Count()];

            for (int i = 0; i < hm.HoleList.Count(); i++)
            {
                HoleBounds[i] = new Rectangle((int)hm.HoleList[i].X, (int)hm.HoleList[i].Y, hm.HoleTexture.Width, hm.HoleTexture.Height);
            }

            for (int i = 0; i < cheese.CheeseList.Count(); i++)
            {
                CheeseBounds[i] = new Rectangle((int)cheese.CheeseList[i].X, (int)cheese.CheeseList[i].Y, cheese.CheeseTexture.Width, cheese.CheeseTexture.Height);
            }
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput();
            TomBounds = new Rectangle((int)tom.CurrentTomLoc.X, (int)tom.CurrentTomLoc.Y, tom.CurrentTomTexture.Width, tom.CurrentTomTexture.Height);
            JerryBounds = new Rectangle((int)jerry.CurrentJerryLoc.X, (int)jerry.CurrentJerryLoc.Y, jerry.CurrentJerryTexture.Width, jerry.CurrentJerryTexture.Height);
            jerry.jerryState = CheckHoles();

            

            for (int i = 0; i < cheese.CheeseList.Count(); i++)
            {
                if (JerryBounds.Intersects(CheeseBounds[i]))
                {
                    CheeseBounds[i].X = 1000;
                    CheeseBounds[i].Y = 1000;
                    cheese.CheeseList[i].X = score.Score[i].X;
                    cheese.CheeseList[i].Y = score.Score[i].Y;
                    score.finalscore++;
                }
            }

            if (TomBounds.Intersects(JerryBounds) && jerry.jerryState != Jerry.JerryState.Hiding)
            {
                score.endgameMessage = "He caught you! Press R to Restart.";
                jerry.jerryState = Jerry.JerryState.Dead;
            }

            else if(score.finalscore==cheese.CheeseList.Count())
            {
                score.endgameMessage = "You Won! Press R to Restart.";
                jerry.jerryState = Jerry.JerryState.Win;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);
        }

    public Jerry.JerryState CheckHoles()
{
        int holecounter = 0;
    for (int i = 0; i < hm.HoleList.Count();i++)
    {
        if (JerryBounds.Intersects(HoleBounds[i]))
            holecounter++;
    }
        if (holecounter>0)
            return  Jerry.JerryState.Hiding;
        else
            return Jerry.JerryState.Visible;
}

    private void HandleInput()
    {
        //Moves DigDug once a button is pressed
        if (Keyboard.GetState().IsKeyDown(Keys.R))
        {
            jerry.CurrentJerryLoc = new Vector2(405, 55);
            tom.CurrentTomLoc = new Vector2(500, 150);
            cheese.SetCheese();
            for (int i = 0; i < cheese.CheeseList.Count(); i++)
            {
                CheeseBounds[i] = new Rectangle((int)cheese.CheeseList[i].X, (int)cheese.CheeseList[i].Y, cheese.CheeseTexture.Width, cheese.CheeseTexture.Height);
            }
            score.finalscore = 0;
            score.endgameMessage = "";
            jerry.ControllerOn = true;
        }
    }

    }

}

    