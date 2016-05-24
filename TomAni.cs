using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


//Tom Animation Class/////
/*
 This class holds all of Tom's sprites, loads them, and stores them in arrays.
 * the class constantly replaces the current sprite with the next sprite in the array, creating the illusion of animation.
 * Note, all animations are always changing, at all times.
*/



namespace TomandJerrySimulation
{
    class TomAni : Microsoft.Xna.Framework.DrawableGameComponent
    {

        
        public Texture2D currentWalk;
        Texture2D TomWalk1;
        Texture2D TomWalk2;
        Texture2D TomWalk3;
        Texture2D TomWalk4;
        Texture2D TomWalk5;
        Texture2D TomWalk6;
        Texture2D TomWalk7;
        Texture2D TomWalk8;
        int Walki;

        public Texture2D currentRun;
        Texture2D TomRun1;
        Texture2D TomRun2;
        Texture2D TomRun3;
        Texture2D TomRun4;
        Texture2D TomRun5;
        Texture2D TomRun6;
        int Runi;

        public Texture2D TomWin;
        public Texture2D TomLose;
        
        public Texture2D[] WalkingList = new Texture2D[8];
        public Texture2D[] RunningList = new Texture2D[6];
        float time;
        float sec;


          public TomAni(Game game) :base(game)
        {
            
        }

          protected override void LoadContent()
          {
              //Tom Walking Sprites//
              TomWalk1 = this.Game.Content.Load<Texture2D>("TomSprite");
              TomWalk2 = this.Game.Content.Load<Texture2D>("TomSprite2");
              TomWalk3 = this.Game.Content.Load<Texture2D>("TomSprite3");
              TomWalk4 = this.Game.Content.Load<Texture2D>("TomSprite4");
              TomWalk5 = this.Game.Content.Load<Texture2D>("TomSprite5");
              TomWalk6 = this.Game.Content.Load<Texture2D>("TomSprite6");
              TomWalk7 = this.Game.Content.Load<Texture2D>("TomSprite7");
              TomWalk8 = this.Game.Content.Load<Texture2D>("TomSprite8");
              ///////////////////////
              
              //Tom Walking Sprite Array//
              WalkingList[0] = TomWalk1;
              WalkingList[1] = TomWalk2;
              WalkingList[2] = TomWalk3;
              WalkingList[3] = TomWalk4;
              WalkingList[4] = TomWalk5;
              WalkingList[5] = TomWalk6;
              WalkingList[6] = TomWalk7;
              WalkingList[7] = TomWalk8;

              Walki = 0;//Walking Iterator
              ///////////////////////////

              //Tom Running Sprites//
              TomRun1 = this.Game.Content.Load<Texture2D>("TomRunSprite1");
              TomRun2 = this.Game.Content.Load<Texture2D>("TomRunSprite2");
              TomRun3 = this.Game.Content.Load<Texture2D>("TomRunSprite3");
              TomRun4 = this.Game.Content.Load<Texture2D>("TomRunSprite4");
              TomRun5 = this.Game.Content.Load<Texture2D>("TomRunSprite5");
              TomRun6 = this.Game.Content.Load<Texture2D>("TomRunSprite6");
              //////////////////////////

              //Tom Running Sprite List/////////
              RunningList[0] = TomRun1;
              RunningList[1] = TomRun2;
              RunningList[2] = TomRun3;
              RunningList[3] = TomRun4;
              RunningList[4] = TomRun5;
              RunningList[5] = TomRun6;

              Runi = 0;//Running Iterator
              ////////////////////////////////

              currentRun = RunningList[0];
              currentWalk = WalkingList[0];//Set the current sprite as the first one in the array
              sec = 0;

              TomWin = this.Game.Content.Load<Texture2D>("TomWinSprite");
              TomLose = this.Game.Content.Load<Texture2D>("TomLoseSprite");
              base.LoadContent();
          }

          public override void Update(GameTime gameTime)
          {
              time = (float)gameTime.ElapsedGameTime.Milliseconds;

              if (sec > time) //Causes a delay bewtween each sprite exchange
              {
                  TomRunning();
                  TomWalking();
                  sec = 0;
              }
              sec += time /4; //change the int to change length of delay between sprite changes
                  base.Update(gameTime);
          }


        private void TomWalking() //Loops through each Walking sprite and resets on the last sprite on array
          {
              
                    currentWalk = WalkingList[Walki];
                    Walki++;
                  if (Walki == WalkingList.Count())
                  {
                      Walki = 0;
                  }
                 
          }

        private void TomRunning()//Loops through each Running sprite and resets on the last sprite on array
        {
            
            currentRun = RunningList[Runi];
            Runi++;
            if (Runi == RunningList.Count())
            {
                Runi = 0;
            }
            
        }

    }
    
}
