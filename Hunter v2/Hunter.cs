using Hunter_v2.Components;
using Hunter_v2.Components.HealthComponents;
using Hunter_v2.Components.InputComponents;
using Hunter_v2.Components.MovementComponents;
using Hunter_v2.Components.PositionComponent;
using Hunter_v2.Components.SizeComponents;
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
// UNSURE - some code that is not well understood enough to know whether it is ideal or optimal

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
        List<GameActor> gameActors;
        GameActor player;
        TileImg[] tileSet;
        Tile[] map;
        Vector2 mapSize;
        int[,] mapSource;
        World world;

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
            player = new GameActor(new GraphicsComponent(playerSprite, spriteBatch), new InputComponent(), new SizeComponent(50,50), new PositionComponent(200,200), new MovementComponent(), new HealthComponent(100), new RangedWeaponComponent());
            tileSet = new TileImg[]
            {
                new TileImg(0, new GraphicsComponent(blueTileTexture, spriteBatch)),
                new TileImg(1, new GraphicsComponent(blueTileTexture, spriteBatch))
            };

            map = new Tile[]
            {
                new Tile(new SizeComponent(50,50), new PositionComponent(0,0), tileSet[0], 0),
                new Tile(new SizeComponent(50,50), new PositionComponent(150,0), tileSet[1], 1)
            };

            mapSize = new Vector2(200, 200);
            mapSource = new int[(int)mapSize.X, (int)mapSize.Y];

            for (int i = 0; i < mapSize.X; i++)
            {
                for (int j = 0; j < mapSize.Y; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        mapSource[i, j] = 0;
                    }
                    else
                    {
                        mapSource[i, j] = 1;
                    }
                }
            }
            gameActors = new List<GameActor>();
            gameActors.Add(player);

            world = new World(mapSize, tileSet, mapSource, gameActors);


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
            playerSprite = Content.Load<Texture2D>("PurpleTile");
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

            world.update();

            //REMOVE
            /*
            if (Collision.collisionCheck(player.positionComponent, player.sizeComponent, map[0].positionComponent, map[0].sizeComponent) ||
               (Collision.collisionCheck(player.positionComponent, player.sizeComponent, map[1].positionComponent, map[1].sizeComponent)))
            {
                Exit();
            }
            */

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
            world.draw();


            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
