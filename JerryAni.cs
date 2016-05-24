using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Jerry Animation Class///////
/*
 This class holds all of Jerry's sprites, loads them, and stores them in arrays.
 * the class constantly replaces the current sprite with the next sprite in the array, creating the illusion of animation.
 * Note, all animations are always changing, at all times.
*/

namespace TomandJerrySimulation
{
    class JerryAni : Microsoft.Xna.Framework.DrawableGameComponent
    {
        
        public Texture2D currentWalk;
        Texture2D JerryWalk1;
        Texture2D JerryWalk2;
        Texture2D JerryWalk3;
        Texture2D JerryWalk4;
        Texture2D JerryWalk5;
        Texture2D JerryWalk6;
        Texture2D JerryWalk7;
        Texture2D JerryWalk8;
        Texture2D JerryWalk9;
        int Walki;

        public Texture2D currentRun;
        Texture2D JerryRun1;
        Texture2D JerryRun2;
        Texture2D JerryRun3;
        Texture2D JerryRun4;
        Texture2D JerryRun5;
        Texture2D JerryRun6;
        Texture2D JerryRun7;
        Texture2D JerryRun8;
        int Runi;

        public Texture2D JerryWin;
        public Texture2D JerryLose;
        

        
        public Texture2D[] WalkingList = new Texture2D[9];
        public Texture2D[] RunningList = new Texture2D[3];
        float time;
        float sec;

          public JerryAni(Game game) :base(game)
        {
            
        }

          protected override void LoadContent()
          {
              //Jerry Walking Sprites//
              JerryWalk1 = this.Game.Content.Load<Texture2D>("JerrySprite1");
              JerryWalk2 = this.Game.Content.Load<Texture2D>("JerrySprite2");
              JerryWalk3 = this.Game.Content.Load<Texture2D>("JerrySprite3");
              JerryWalk4 = this.Game.Content.Load<Texture2D>("JerrySprite4");
              JerryWalk5 = this.Game.Content.Load<Texture2D>("JerrySprite5");
              JerryWalk6 = this.Game.Content.Load<Texture2D>("JerrySprite6");
              JerryWalk7 = this.Game.Content.Load<Texture2D>("JerrySprite7");
              JerryWalk8 = this.Game.Content.Load<Texture2D>("JerrySprite8");
              JerryWalk9 = this.Game.Content.Load<Texture2D>("JerrySprite9");
              ///////////////////////
              
              //Jerry Walking Sprite Array//
              WalkingList[0] = JerryWalk1;
              WalkingList[1] = JerryWalk2;
              WalkingList[2] = JerryWalk3;
              WalkingList[3] = JerryWalk4;
              WalkingList[4] = JerryWalk5;
              WalkingList[5] = JerryWalk6;
              WalkingList[6] = JerryWalk7;
              WalkingList[7] = JerryWalk8;
              WalkingList[8] = JerryWalk9;

              Walki = 0;//Walking Iterator
              ///////////////////////////

              //Jerry Running Sprites//
              JerryRun1 = this.Game.Content.Load<Texture2D>("JerryRunSprite1");
              JerryRun2 = this.Game.Content.Load<Texture2D>("JerryRunSprite2");
              JerryRun3 = this.Game.Content.Load<Texture2D>("JerryRunSprite3");
              JerryRun4 = this.Game.Content.Load<Texture2D>("JerryRunSprite4");
              JerryRun5 = this.Game.Content.Load<Texture2D>("JerryRunSprite5");
              JerryRun6 = this.Game.Content.Load<Texture2D>("JerryRunSprite6");
              JerryRun7 = this.Game.Content.Load<Texture2D>("JerryRunSprite7");
              JerryRun8 = this.Game.Content.Load<Texture2D>("JerryRunSprite8");
              //////////////////////////

              //Jerry Running Sprite List/////////
             
              //Only 3 of the frames of the animation needed
              RunningList[0] = JerryRun3;
              RunningList[1] = JerryRun4;
              RunningList[2] = JerryRun5;
           

              Runi = 0;//Running Iterator
              ////////////////////////////////

              currentRun = RunningList[0];//Set the current sprite as the first one in the array
              currentWalk = WalkingList[0];//Set the current sprite as the first one in the array
              sec = 0;

              JerryWin = this.Game.Content.Load<Texture2D>("JerryWinSprite");
              JerryLose = this.Game.Content.Load<Texture2D>("JerryLoseSprite");
              base.LoadContent();
          }

          public override void Update(GameTime gameTime)
          {
              time = (float)gameTime.ElapsedGameTime.Milliseconds;

              if (sec > time) //Causes a delay bewtween each sprite exchange
              {
                  JerryRunning();
                  JerryWalking();
                  sec = 0;
              }
              sec += time / 4;//change the int to change length of delay between sprite changes
                  base.Update(gameTime);
          }


          private void JerryWalking() //Loops through each Walking sprite and resets on the last sprite on array
          {
              
                    currentWalk = WalkingList[Walki];
                    Walki++;
                  if (Walki == WalkingList.Count())
                  {
                      Walki = 0;
                  }
                 
          }

          private void JerryRunning()//Loops through each Running sprite and resets on the last sprite on array
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
