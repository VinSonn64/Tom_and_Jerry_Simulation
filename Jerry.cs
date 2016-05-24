using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Jerry Character Class
/*
 * This Class diplays Jerry
 * JerryAni class will exchange his textures creating animations
 * */

namespace TomandJerrySimulation
{
     class Jerry : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch JspriteBatch;
        JerryAni jerryani;

        public JerryState jerryState;
        public Texture2D CurrentJerryTexture;
        public Vector2 CurrentJerryLoc;
        public Vector2 JerryDir;
        public float JerrySpeed;

        SpriteFont myFont;

        public bool ControllerOn;
        bool IsKeyDown;
        string ControllerState;
        internal InputController controller { get; private set; }
        

        public Jerry(Game game,JerryAni jerryani)
            : base(game)
        {
            this.jerryani = jerryani;//instance of Jerry Animation class
            this.controller = new InputController(game);
            observers = new List<IObserver>();
        }

        protected override void LoadContent()
        {
            JspriteBatch = new SpriteBatch(GraphicsDevice);

            CurrentJerryTexture = jerryani.currentWalk;
            JerryDir = new Vector2(0, 0);
            CurrentJerryLoc = new Vector2(405,55);
            JerrySpeed = 100f;

            ControllerOn = true;
            myFont = this.Game.Content.Load<SpriteFont>("myFont");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
       
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            CurrentJerryLoc = ScreenLock(JerryDir, CurrentJerryLoc, CurrentJerryTexture);
            CurrentJerryLoc = CurrentJerryLoc + ((JerryDir* JerrySpeed) * (time / 1000));
            switch (jerryState)
            {
                case JerryState.Hiding:
                    JerryWalk();
                    JerrySpeed = 100f;
                    break;

                case JerryState.Visible:
                    JerryRun();
                    JerrySpeed = 100f;
                    break;

                case JerryState.Win:
                    JerryWin();
                    JerrySpeed=0;
                    ControllerOn = true;
                    break;

                case JerryState.Dead:
                    JerryLose();
                    JerrySpeed = 0;
                    ControllerOn = true;
                    break;
            }

            

            this.controller.Update();
            ///////////////////////////

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                IsKeyDown = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !IsKeyDown)
            {
                if (!ControllerOn)
                { ControllerOn = true; }
                else if (ControllerOn)
                {
                    ControllerOn = false;
                }
                IsKeyDown = true;
            }

            if (ControllerOn)
            {
                JerryDir = this.controller.Direction;
                ControllerState = "Controller: On";
            }
            else
            { ControllerState = "Controller: Off"; }

            Notify();
            base.Update(gameTime);
        }

  

        public override void Draw(GameTime gameTime)
        {
            JspriteBatch.Begin();
            JspriteBatch.Draw(CurrentJerryTexture, CurrentJerryLoc, Color.White);
            JspriteBatch.DrawString(myFont, ControllerState, new Vector2(0, 450), Color.Black);
            JspriteBatch.End();
            base.Draw(gameTime);
        }

        #region ISubject Members
        List<IObserver> observers;

        public void Attach(IObserver o)
        {

            this.observers.Add(o);
        }

        public void Deatach(IObserver o)
        {

            this.observers.Remove(o);
        }

        public void Notify()
        {
            foreach (IObserver o in observers)
            {
                o.ObserverUpdate(this, this.jerryState);
            }
        }

        public void Notify(string message)
        {
            foreach (IObserver o in observers)
            {
                o.ObserverUpdate(this, message);
            }
        }

        #endregion
        public enum JerryState {Hiding, Visible, Dead, Win }
        public void JerryRun()
        {
            CurrentJerryTexture = jerryani.currentRun;
        }
        public void JerryWalk()
        {
            CurrentJerryTexture = jerryani.currentWalk;
        }
         public void JerryWin()
        {
            CurrentJerryTexture = jerryani.JerryWin;
        }
         public void JerryLose()
         {
             CurrentJerryTexture = jerryani.JerryLose;
         }
        public Vector2 ScreenLock(Vector2 CharDir, Vector2 CharLoc, Texture2D CharTexture)
        {
            if (CharLoc.X > Game.GraphicsDevice.Viewport.Width - (CharTexture.Width / 2))
            {
                CharLoc.X-=5;
            }
            if (CharLoc.X < (CharTexture.Width / 2))
                CharLoc.X+=5;

            if (CharLoc.Y > Game.GraphicsDevice.Viewport.Height - (CharTexture.Height / 2))
                CharLoc.Y -=5;

            if (CharLoc.Y < (CharTexture.Height / 2))
                CharLoc.Y +=5;
            return CharLoc;
        }
    }
}
