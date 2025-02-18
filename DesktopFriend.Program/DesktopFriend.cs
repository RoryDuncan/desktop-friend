using System.IO;
using System.Reflection.Metadata;
using DesktopFriend.Core;
using DesktopFriend.Program.Screens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;

namespace DesktopFriend.Program;

public class DesktopFriend : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D ballTexture;
    Vector2 ballPosition;
    private readonly ServiceCollection services = new();
    public ServiceProvider provider;
    private readonly ScreenManager screenManager;


    public DesktopFriend()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
        screenManager = new ScreenManager();
        Components.Add(screenManager);

    }

    protected void RegisterServices()
    {
        services.AddSingleton(GraphicsDevice); // _graphics establishes GraphicsDevice
        services.AddSingleton<SpriteBatch>();
        services.AddSingleton(Content);
        services.AddSingleton(this);

        provider = services.BuildServiceProvider();
    }

    protected override void Initialize()
    {
        base.Initialize();
        RegisterServices();
        _spriteBatch = provider.GetService<SpriteBatch>();
        // Components.Add(ScreenManager);
        // TODO: Add your initialization logic here
        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        screenManager.LoadScreen(new TestScreen1(this), new FadeTransition(GraphicsDevice, Color.Black));
    }

    protected override void LoadContent()
    {
        // _spriteBatch = new SpriteBatch(GraphicsDevice);

        ballTexture = Content.LoadTexture("ball.png");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        var state = Mouse.GetState();
        ballPosition = state.Position.ToVector2();

        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.D1))
        {
            screenManager.LoadScreen(new TestScreen1(this), new FadeTransition(GraphicsDevice, Color.Black));

        }
        else if (keyboardState.IsKeyDown(Keys.D2))
        {
            screenManager.LoadScreen(new TestScreen2(this), new FadeTransition(GraphicsDevice, Color.Black));

        }

        // TODO: Add your update logic here
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Beige);

        // // TODO: Add your drawing code here
        // _spriteBatch.Begin();
        // _spriteBatch.Draw(ballTexture, ballPosition, new Rectangle(0, 0, ballTexture.Width, ballTexture.Height), Color.White);
        // _spriteBatch.End();

        base.Draw(gameTime);
    }
}
