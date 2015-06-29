using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SpaceBUTT
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Spawn spawn = new Spawn();
        Collision collision = new Collision();
        Crosshair cross = new Crosshair();
        Player player = new Player();
        HUD hud = new HUD();
        Effect effect;
        Skybox skybox = new Skybox();
        int spawnEnemyTimer = 0;
        int spawnTimer = 0;
        int spawnTime = 10;
        int spawnEnemyTime = 50;
    
        
        public Matrix View;
        public Matrix Projection;      
        public GraphicsDevice device;
         
        Vector3 cameraPosition = new Vector3(0.0f, 1000.0f, 5000.0f);
        Vector3 cameraView = Vector3.Zero;
     
        float aspectRatio;


       
           

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
           
            base.Initialize();
        }


  
        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
             
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), aspectRatio, 1.0f, 100000.0f);
            View = Matrix.CreateLookAt(cameraPosition, cameraView, Vector3.Up);
            effect = Content.Load<Effect>("effects");
            hud.LoadContent(Content);
            player.LoadContent(Content);
            cross.LoadContent(Content);
            skybox.LoadContent(Content, effect);
        }


        protected override void UnloadContent()
        {     
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState stat = Keyboard.GetState();
            if (stat.IsKeyDown(Keys.Escape))          
                this.Exit();

            if (stat.IsKeyDown(Keys.D1))    
                spawnEnemyTime = 100;
            if (stat.IsKeyDown(Keys.D2))
                spawnEnemyTime = 50;
            if (stat.IsKeyDown(Keys.D3))
                spawnEnemyTime = 10;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
    

            if (spawnTimer > spawnTime)
              {
                  spawnTimer = 0;
                  spawn.LoadContent1(Content);    
              }
            if (spawnEnemyTimer > spawnEnemyTime)
            {
                spawnEnemyTimer = 0;
                spawn.LoadContent2(Content);
            }

            collision.Update(gameTime,player,spawn,hud);
            player.Update(gameTime, Content, spawn.asteroid,spawn.enemies);
            cross.Update(gameTime);
            spawn.Update(gameTime,Content,player.modelPosition);
            hud.Update(gameTime, player.modelPosition, spawn.asteroid.Count()+spawn.enemies.Count());

            spawnTimer++;
            spawnEnemyTimer++;
            View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);

          base.Update(gameTime);
        }
      

        protected override void Draw(GameTime gameTime)
        {
           
           // GraphicsDevice.Clear(Color.Black);
            //device.Clear(ClearOptions.Target | ClearOptions.DepthBuffer, Color.DarkSlateBlue, 1.0f, 0);

            skybox.Draw(Projection, View, device);
            
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            player.Draw(Projection, View);
            cross.Draw(Projection,View);            
            spawn.Draw(Projection, View);
            hud.Draw(spriteBatch);
           
            base.Draw(gameTime);
        }
       
    }
}
