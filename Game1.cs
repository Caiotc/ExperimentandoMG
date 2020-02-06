using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Experimentando
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D target_Sprite;
        Texture2D crosshairs_Sprite;
        Texture2D background_Sprite;

        SpriteFont gameFont;

        Vector2 targetPosition = new Vector2(300,300);
        const int targetRadius = 45;
        string scoreInfo = "Jogo de teste | Score = {0}";
        

        MouseState mouseState;
        bool mRelease = true;
        float mTargetDist;
        int score = 0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
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

            target_Sprite = Content.Load<Texture2D>("target");
            crosshairs_Sprite = Content.Load<Texture2D>("crosshairs");
            background_Sprite = Content.Load<Texture2D>("sky");
            gameFont = Content.Load<SpriteFont>("galleryFont");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            mouseState = Mouse.GetState();
            mTargetDist = Vector2.Distance(targetPosition, new Vector2(mouseState.X, mouseState.Y));

            if (mouseState.LeftButton == ButtonState.Pressed && mRelease == true)
            {
                
                if(mTargetDist < targetRadius)
                {
                    score++;
                    Random rand = new Random();
                    targetPosition.X = rand.Next(targetRadius, graphics.PreferredBackBufferWidth - targetRadius) ;
                    targetPosition.Y = rand.Next(targetRadius, graphics.PreferredBackBufferHeight - targetRadius);
                 }
                mRelease = false;
            } 
            if(mouseState.LeftButton == ButtonState.Released)
            {
                mRelease = true;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background_Sprite,new Vector2( 0,0),Color.White);
            spriteBatch.Draw(target_Sprite, new Vector2(targetPosition.X - targetRadius,targetPosition.Y - targetRadius), Color.White);
            spriteBatch.DrawString(gameFont, string.Format(scoreInfo,score.ToString()), new Vector2(0, 0), Color.Black);            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
