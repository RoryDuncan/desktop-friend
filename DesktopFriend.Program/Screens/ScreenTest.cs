using DesktopFriend.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

namespace DesktopFriend.Program.Screens;

public class TestScreen1(DesktopFriend game) : GameScreen(game)
{
    private Texture2D background;
    private SpriteBatch _spritebatch;

    public override void Initialize()
    {
        base.Initialize();
        _spritebatch = game.provider.GetService<SpriteBatch>();
    }

    public override void LoadContent()
    {
        base.LoadContent();
        // background
        background = Content.LoadTexture("background0.png");

    }

    public override void Draw(GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.Aqua);
        _spritebatch.Begin();
        _spritebatch.Draw(background, Vector2.Zero, Color.White);
        _spritebatch.End();
    }

    public override void Update(GameTime gameTime)
    {

    }
}

public class TestScreen2(DesktopFriend game) : GameScreen(game)
{
    private Texture2D background;
    private SpriteBatch _spritebatch;

    public override void Initialize()
    {
        base.Initialize();
        _spritebatch = game.provider.GetService<SpriteBatch>();
    }

    public override void LoadContent()
    {
        base.LoadContent();
        // background
        background = Content.LoadTexture("background1.png");

    }

    public override void Draw(GameTime gameTime)
    {
        game.GraphicsDevice.Clear(Color.Aqua);
        _spritebatch.Begin();
        _spritebatch.Draw(background, Vector2.Zero, Color.White);
        _spritebatch.End();
    }

    public override void Update(GameTime gameTime)
    {

    }
}