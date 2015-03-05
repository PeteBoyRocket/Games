using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame2
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private Sprite _player;
		private Vector2 targetPosition;

		public Game1()
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
			IsMouseVisible = true;

			_player = new Sprite
			{
				Position = new Vector2(0, 0),
				Velocity = 3
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

			_player.Texture = Content.Load<Texture2D>("player");
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
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			var currentMouseState = Mouse.GetState();
			Debug.WriteLine(currentMouseState);
				
			if (currentMouseState.LeftButton == ButtonState.Pressed)
			{
				targetPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
			}

			if (PlayerHasReachedPosition())
			{
				Debug.WriteLine("Reached the spot!");
				_player.Position = new Vector2(targetPosition.X, _player.Position.Y);
			}
			else if (_player.Position.X > targetPosition.X)
			{
				Debug.WriteLine("Player position is greater");
				_player.Position = new Vector2(_player.Position.X - _player.Velocity, _player.Position.Y);
			}
			else if (_player.Position.X < targetPosition.X)
			{
				Debug.WriteLine("Player position is less");
				_player.Position = new Vector2(_player.Position.X + _player.Velocity, _player.Position.Y);
			}

			base.Update(gameTime);
		}

		private bool PlayerHasReachedPosition()
		{
			if (_player.Position.X > targetPosition.X)
			{
				return _player.Position.X - targetPosition.X <= _player.Velocity;
			}

			return _player.Position.X + targetPosition.X <= _player.Velocity;
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			spriteBatch.Draw(_player.Texture, _player.Position, Color.White);

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
