﻿using Hunter_v2.Components;
using Hunter_v2.Components.HealthComponents;
using Hunter_v2.Components.InputComponents;
using Hunter_v2.Components.MovementComponents;
using Hunter_v2.Components.PositionComponent;
using Hunter_v2.Components.WeaponComponents;
using Hunter_v2.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

// Keyworks to use for find-in-files
// MISSING - some code is known to be missing, likely for lack of understanding at the time
// BUG - known error in logic
// REMOVE - some arbitrary code added in, likely for testing purposes that should be removed once it is replaced with actual logic

namespace Hunter_v2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Hunter : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //REMOVE
        Texture2D playerSprite, blueTileTexture, greenTileTexture;
        GameActor player;
        TileImg[] tileSet;
        Tile[] map;

        public Hunter()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            //REMOVE
            player = new GameActor(new GraphicsComponent(playerSprite, spriteBatch), new InputComponent(), new PositionComponent(), new MovementComponent(), new HealthComponent(100), new RangedWeaponComponent());
            tileSet = new TileImg[]
            {
                new TileImg(0, new GraphicsComponent(blueTileTexture, spriteBatch)),
                new TileImg(1, new GraphicsComponent(blueTileTexture, spriteBatch))
            };

            map = new Tile[]
            {
                new Tile(new Vector2(0,0), tileSet[0], 0),
                new Tile(new Vector2(100,0), tileSet[1], 1)
            };


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


            //REMOVE ALL BELOW HERE
            playerSprite = Content.Load<Texture2D>("squirtle");
            player.graphicsComponent.texture = playerSprite;
            player.graphicsComponent.spriteBatch = spriteBatch;

            blueTileTexture = Content.Load<Texture2D>("BlueTile");
            tileSet[0].graphicsComponent.texture = blueTileTexture;
            tileSet[0].graphicsComponent.spriteBatch = spriteBatch;

            greenTileTexture = Content.Load<Texture2D>("GreenTile");
            tileSet[1].graphicsComponent.texture = greenTileTexture;
            tileSet[1].graphicsComponent.spriteBatch = spriteBatch;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            player.update();

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

            //REMOVE
            player.draw();
            map[0].draw();
            map[1].draw();


            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
