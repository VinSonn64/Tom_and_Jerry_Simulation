using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IntroGameLibrary.Util;

//Tom Character Class
/*
 * This Class diplays Tom
 * TomAni class will exchange his textures creating animations
 
 * */


namespace TomandJerrySimulation
{
     class Tom : Microsoft.Xna.Framework.DrawableGameComponent, IObserver
    {
 
        SpriteBatch TspriteBatch;

        TomAni tomani;
        Jerry jerry;
        SteeringBehaviors sb;

        public Texture2D CurrentTomTexture;
        public Vector2 CurrentTomLoc;
        public Vector2 TomDir;
        public float TomSpeed;

      

        public Tom(Game game, TomAni tomani, Jerry jerry, SteeringBehaviors sb) :base(game)
        {
            this.jerry = jerry;
            jerry.Attach(this);
            this.tomani = tomani; //Instance of Tom Animation class
            this.sb = sb;
        }

        protected override void LoadContent()
        {
            TspriteBatch = new SpriteBatch(GraphicsDevice);
            CurrentTomTexture = tomani.currentWalk;
            CurrentTomLoc = new Vector2(700, 350);
            TomDir = new Vector2(0, 0);
            TomSpeed = 110f;
      
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            TomDir = ScreenLock(TomDir, CurrentTomLoc,CurrentTomTexture);
            CurrentTomLoc = CurrentTomLoc + ((TomDir * TomSpeed) * (time / 1000));
            base.Update(gameTime);
        }
        //Draws Tom
        public override void Draw(GameTime gameTime)
        {
            TspriteBatch.Begin();
            TspriteBatch.Draw(CurrentTomTexture, CurrentTomLoc, Color.White);
            TspriteBatch.End();
        }  
         #region IObserver Members

        public void ObserverUpdate(Object sender, Object message)
        {
            if (message is TomandJerrySimulation.Jerry.JerryState)
            {
                TomandJerrySimulation.Jerry.JerryState p = (TomandJerrySimulation.Jerry.JerryState)message;

                if (p == Jerry.JerryState.Hiding)
                {
                    TomWalk();
                    TomDir = sb.Wander(TomDir);
                    TomSpeed = 5;
                }

                else if (p == Jerry.JerryState.Visible)
                {
                    TomRun();
                    TomDir = sb.Seek(CurrentTomLoc, jerry.CurrentJerryLoc);
                    TomSpeed = 120f;
                }

                else if (p == Jerry.JerryState.Dead)
                {
                    TomSpeed = 0;
                    TomLose();
                }

                else if (p == Jerry.JerryState.Win)
                {
                    TomSpeed = 0;
                    TomWin();
                }

            }


        }

        #endregion
        
        //This code exchanges Tom's current sprite with the animations done in TomAni. 
        //This function is used in Collision.cs
        public void TomRun()
        {
            CurrentTomTexture = tomani.currentRun;
        }

        public void TomWalk()
        {
            CurrentTomTexture = tomani.currentWalk;
        }
        public void TomWin()
        {
            CurrentTomTexture = tomani.TomWin;
        }

        public void TomLose()
        {
            CurrentTomTexture = tomani.TomLose;
        }

         //Code Keep Character on Screen
        public Vector2 ScreenLock(Vector2 CharDir, Vector2 CharLoc, Texture2D CharTexture)
        {
            if (CharLoc.X > Game.GraphicsDevice.Viewport.Width - (CharTexture.Width / 2))
            {
                CharDir.X = -CharDir.X;
            }
            if (CharLoc.X < (CharTexture.Width / 2))
                CharDir.X = -CharDir.X;

            if (CharLoc.Y > Game.GraphicsDevice.Viewport.Height - (CharTexture.Height / 2))
                CharDir.Y = -CharDir.Y;

            if (CharLoc.Y < (CharTexture.Height / 2))
                CharDir.Y = -CharDir.Y;
            return CharDir;
        }

       
     }
}
