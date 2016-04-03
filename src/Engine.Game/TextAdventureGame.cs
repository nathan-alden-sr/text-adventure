using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Junior.Common.Net35;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NathanAlden.TextAdventure.Engine.Objects;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Point = System.Drawing.Point;

namespace NathanAlden.TextAdventure.Engine.Game
{
    public class TextAdventureGame : Microsoft.Xna.Framework.Game
    {
        private readonly Form _form;
        private readonly GraphicsDeviceManager _graphics;
        private readonly World _world;
        private readonly WorldDirectory _worldDirectory;
        private SpriteBatch _spriteBatch;

        public TextAdventureGame(WorldDirectory worldDirectory)
        {
            _worldDirectory = worldDirectory.EnsureNotNull(nameof(worldDirectory));

            _graphics = new GraphicsDeviceManager(this);
            _world = worldDirectory.CreateWorld();
            _form = (Form)Control.FromHandle(Window.Handle);
            _form.Opacity = 0;

            Stream iconStream = worldDirectory.OpenIconStream();

            if (iconStream != null)
            {
                _form.Icon = new Icon(iconStream);
            }

            Content.RootDirectory = "Content";
            Window.Title = $"{_world.Name} - Text Adventure";
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var characterset = Content.Load<Texture2D>($@"charactersets\{_worldDirectory.Characterset}");

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = characterset.Width / 16 * _world.MaximumBoardSize.Width;
            _graphics.PreferredBackBufferHeight = characterset.Height / 16 * _world.MaximumBoardSize.Height;
            _graphics.ApplyChanges();

            Screen screen = Screen.FromControl(_form);

            _form.Location = new Point(screen.Bounds.Width / 2 - _form.Width / 2, screen.Bounds.Height / 2 - _form.Height / 2);
            _form.Opacity = 1;
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}