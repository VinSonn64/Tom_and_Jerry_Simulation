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
    class JerryAI : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Jerry jerry;
        SteeringBehaviors sb;
        Cheese cheese;
        HolesManager holes;
        Collision collision;
        Tom tom;
        double DistTom, DistHole, DistCheese;
        Vector2 BestHole, BestCheese;

        public JerryAI(Game game, SteeringBehaviors sb, Cheese cheese, HolesManager holes, Jerry jerry, Collision collision, Tom tom)
            : base(game)
        {
            this.sb = sb;
            this.cheese = cheese;
            this.holes = holes;
            this.jerry = jerry;
            this.collision = collision;
            this.tom = tom;
        }

        protected override void LoadContent()
        {
            DistCheese = Math.Sqrt(((jerry.CurrentJerryLoc.X - collision.CheeseBounds[0].X) * (jerry.CurrentJerryLoc.X - collision.CheeseBounds[0].X)) + ((jerry.CurrentJerryLoc.Y - collision.CheeseBounds[0].Y) * (jerry.CurrentJerryLoc.Y - collision.CheeseBounds[0].Y)));
            BestCheese = cheese.CheeseList[0];
            DistHole = Math.Sqrt(((jerry.CurrentJerryLoc.X - holes.HoleList[0].X) * (jerry.CurrentJerryLoc.X - holes.HoleList[0].X)) + ((jerry.CurrentJerryLoc.Y - holes.HoleList[0].Y) * (jerry.CurrentJerryLoc.Y - holes.HoleList[0].Y)));
            BestHole = holes.HoleList[0];
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {


            if (jerry.ControllerOn == false)
            {
                jerry.JerrySpeed = 160;
                BestCheese = FindClosestCheese(jerry.CurrentJerryLoc);
                BestHole = FindClosestHole(jerry.CurrentJerryLoc);

                DistTom = FindDist(jerry.CurrentJerryLoc, tom.CurrentTomLoc);
                DistCheese = FindDist(jerry.CurrentJerryLoc, BestCheese);
                DistHole = FindDist(jerry.CurrentJerryLoc, BestHole);

                if (DistCheese < DistTom)
                {
                    jerry.JerryDir = sb.Seek(jerry.CurrentJerryLoc, BestCheese);
                }
                else if (DistCheese > DistTom)
                {
                    jerry.JerryDir = sb.Seek(jerry.CurrentJerryLoc, BestHole);
                }
                DistCheese = 100000;
            }
            base.Update(gameTime);
        }

        Vector2 FindClosestCheese(Vector2 JerryPos)
        {

            double CurrentCheese;
            double CurrentCheeseTom;
            for (int i = 0; i < cheese.CheeseList.Count(); i++)
            {
                CurrentCheese = Math.Sqrt(((JerryPos.X - collision.CheeseBounds[i].X) * (JerryPos.X - collision.CheeseBounds[i].X)) + ((JerryPos.Y - collision.CheeseBounds[i].Y) * (JerryPos.Y - collision.CheeseBounds[i].Y)));
                CurrentCheeseTom = Math.Sqrt(((tom.CurrentTomLoc.X - collision.CheeseBounds[i].X) * (tom.CurrentTomLoc.X - collision.CheeseBounds[i].X)) + ((tom.CurrentTomLoc.Y - collision.CheeseBounds[i].Y) * (tom.CurrentTomLoc.Y - collision.CheeseBounds[i].Y)));
                if (DistCheese > CurrentCheese)// && CurrentCheese< CurrentCheeseTom)
                {
                    
                    DistCheese = CurrentCheese;
                    BestCheese = cheese.CheeseList[i];
                }

            }

            return BestCheese;
        }


        Vector2 FindClosestHole(Vector2 JerryPos)
        {

            double CurrentHole;
            for (int i = 0; i < holes.HoleList.Count(); i++)
            {
                CurrentHole = FindDist(JerryPos, holes.HoleList[i]);
                if (DistHole > CurrentHole)
                {

                    DistHole = CurrentHole;
                    BestHole = holes.HoleList[i];
                }

            }

            return BestHole;
        }

        double FindDist(Vector2 JerryPos, Vector2 TomPos)
        {
            double Distance;
            Distance = Math.Sqrt(((JerryPos.X - TomPos.X) * (JerryPos.X - TomPos.X)) + ((JerryPos.Y - TomPos.Y) * (JerryPos.Y - TomPos.Y)));
            return Distance;
        }

    }
}
