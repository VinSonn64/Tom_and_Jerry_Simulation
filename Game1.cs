using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IntroGameLibrary.Util;

namespace TomandJerrySimulation
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        JerryAI jerryai;
        Tom tom;
        Jerry jerry;
        TomAni tomani;
        JerryAni jerryani;
        SteeringBehaviors sb;
        Cheese cheese;
        HolesManager hm;
        ScoreKeeper score;
        Collision collision;


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

           

            sb = new SteeringBehaviors(this);
            this.Components.Add(sb);

            tomani = new TomAni(this);
            this.Components.Add(tomani);

            jerryani = new JerryAni(this);
            this.Components.Add(jerryani);

            
            
            cheese = new Cheese(this);
            this.Components.Add(cheese);

            score = new ScoreKeeper(this, cheese);
            this.Components.Add(score);

            hm = new HolesManager(this);
            this.Components.Add(hm);

            jerry = new Jerry(this,jerryani);
            this.Components.Add(jerry);

            tom = new Tom(this,tomani, jerry, sb);
            this.Components.Add(tom);

            collision = new Collision(this, tom, jerry, sb, cheese, hm, score);
            this.Components.Add(collision);

            jerryai = new JerryAI(this, sb, cheese, hm, jerry, collision,tom);
            this.Components.Add(jerryai);

           
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkKhaki);
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
