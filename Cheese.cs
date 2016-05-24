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
    class Cheese : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch CheesespriteBatch;
        public Texture2D CheeseTexture;
        public Vector2[] CheeseList;
        Texture2D Scoreboard;

         public Cheese(Game game)
            : base(game) { }

         protected override void LoadContent()
         {
             CheesespriteBatch = new SpriteBatch(GraphicsDevice);
             Scoreboard = this.Game.Content.Load<Texture2D>("ScoreBoard");
             CheeseTexture = this.Game.Content.Load<Texture2D>("Cheese");
             CheeseList = new Vector2[5];

             SetCheese();

                 base.LoadContent();
         }

         public override void Update(GameTime gameTime)
         {
            
             base.Update(gameTime);
         }

         public override void Draw(GameTime gameTime)
         {
             CheesespriteBatch.Begin();
             CheesespriteBatch.Draw(Scoreboard, new Vector2(0, 50), Color.White);
             for (int i = 0; i < CheeseList.Count();i++)
             {
                 CheesespriteBatch.Draw(CheeseTexture,CheeseList[i],Color.White);
             }
             CheesespriteBatch.End();
                 base.Draw(gameTime);
         }

        public void SetCheese()
         {
             CheeseList[0] = new Vector2(400, 450);
             CheeseList[1] = new Vector2(150, 350);
             CheeseList[2] = new Vector2(550, 250);
             CheeseList[3] = new Vector2(720, 380);
             CheeseList[4] = new Vector2(330, 150);
         }
    }
}
