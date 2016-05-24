using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Stores the AI Behaviors//

//Still need to add the logic for each AI behavior
///////////////////////////////////////////////
namespace TomandJerrySimulation
{
    class SteeringBehaviors:Microsoft.Xna.Framework.DrawableGameComponent
    {
        float time;
        float sec;
        float speed;
        Random rn = new Random();
        //Enums for States
         enum behavior_type
        {
            none = 0x00000,
            seek = 0x00002,
            wander = 0x00004,
            flee=0x00006,
        };
        //Constructor
        public SteeringBehaviors(Game game) :base(game)
        {
            
        }
        public override void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            base.Update(gameTime);
        }

        //Wander Function can take a Character's location and move it about in a wndering fashion
        public Vector2 Wander(Vector2 CharDir)
        {
            if (sec > time) //Causes a delay bewtween each sprite exchange
            {
                CharDir = new Vector2(rn.Next(-10, 10), rn.Next(-10, 10));
                sec = 0;
            }
            sec += time / 150;//change the int to change length of delay between sprite changes
            
            //Add Logic Here
            return CharDir;
        }
        //Seek Function has a Character Location travel to a Target Location
        public Vector2 Seek(Vector2 source, Vector2 target)
        {

        
            float  x, y;

            y = target.Y - source.Y;
            x = target.X - source.X;

            float z = (float)Math.Sqrt((x * x)) + (float)Math.Sqrt((y * y));
            x = x / z;
            y = y / z;
            return new Vector2(x,y);
        
        }







        //Flee Function has a Character Location flee from a Target Location
        public Vector2 Flee(Vector2 CharDir, Vector2 Target)
        {
            //Add Logic Here
            CharDir.X = Target.X;
            CharDir.Y = Target.Y;
            return CharDir;
        }
      
 
    }
}
