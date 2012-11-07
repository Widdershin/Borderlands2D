#region Using Statements

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Borderlands2D.ECS;
using Borderlands2D.ECS.Systems;
using Borderlands2D.Entities;
using Borderlands2D.Input;
using Borderlands2D.Input.InputHandlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace Borderlands2D
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Borderlands2D : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public Borderlands2D()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            var systems = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == "Borderlands2D.ECS.Systems"
                    select t;
            var entities = from t in Assembly.GetExecutingAssembly().GetTypes()
                           where t.IsClass && t.Namespace == "Borderlands2D.Entities"
                           select t;
            foreach (var system in systems)
                Activator.CreateInstance(system);
            foreach (var entity in entities)
                EntityRegistry.Register(entity);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            #if WINDOWS || LINUX || MONOMAC
                InputState.InputHandler = new KeyBoardAndMouse();
                TextureManager.RootDirectory = Path.Combine(new[] {Directory.GetCurrentDirectory(), "Content", "Sprites"});
            #endif
            base.Initialize();
        }

        /// <summary>
        /// Runs after LoadContent() has run. Add any init logic in there that depends on content being loaded
        /// </summary>
        private void PostInit()
        {
            EntityRegistry.CreateEntity<Player>(new Vector2(100, 100));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadContent(Content);
            PostInit();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
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
            InputState.Update(gameTime);
//            _player.Update(gameTime);
            SystemsRegistry.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

//            _player.Draw(_spriteBatch);
            RenderSystem.Get.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}