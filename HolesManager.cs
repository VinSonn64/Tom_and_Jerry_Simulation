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
    class HolesManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch HoleSpriteBatch;
        public Texture2D HoleTexture;
        public Vector2[] HoleList;

         public HolesManager(Game game)
            : base(game) { }

         protected override void LoadContent()
         {
             HoleSpriteBatch = new SpriteBatch(GraphicsDevice);
             HoleTexture = this.Game.Content.Load<Texture2D>("mouse hole");
             
             HoleList = new Vector2[5];

             HoleList[0] = new Vector2(200, 50);
             HoleList[1] = new Vector2(400, 50);
             HoleList[2] = new Vector2(600, 50);
             HoleList[3] = new Vector2(300, 450);
             HoleList[4] = new Vector2(550, 450);

                 base.LoadContent();
         }

         public override void Update(GameTime gameTime)
         {
            
             base.Update(gameTime);
         }

         public override void Draw(GameTime gameTime)
         {
             HoleSpriteBatch.Begin();
             for (int i = 0; i < HoleList.Count();i++)
             {
                 HoleSpriteBatch.Draw(HoleTexture,HoleList[i],Color.White);
             }
             HoleSpriteBatch.End();
                 base.Draw(gameTime);
         }
    }
}

    
