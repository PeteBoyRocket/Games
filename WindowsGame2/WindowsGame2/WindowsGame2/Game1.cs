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
		private Vector2 _targetPosition;

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
				Velocity = new Vector2(3, 1)
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
				_targetPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
			}

			SetPlayerPosition(currentMouseState);

			base.Update(gameTime);
		}

		private void SetPlayerPosition(MouseState currentMouseState)
		{
			var x = 0f;

			if (_player.Position.X >= _targetPosition.X)
			{
				var change = _player.Position.X - _player.Velocity.X;
				if (change < _targetPosition.X)
				{
					x = _targetPosition.X;
				}
				else
				{
					x = change;
				}
			}
			else if (_player.Position.X < _targetPosition.X)
			{
				var change = _player.Position.X + _player.Velocity.X;
				if (change > _targetPosition.X)
				{
					x = _targetPosition.X;
				}
				else
				{
					x = change;
				}
			}

			var y = 0f;

			if (_player.Position.Y >= _targetPosition.Y)
			{
				var change = _player.Position.Y - _player.Velocity.Y;
				if (change < _targetPosition.Y)
				{
					y = _targetPosition.Y;
				}
				else
				{
					y = change;
				}
			}
			else if (_player.Position.Y < _targetPosition.Y)
			{
				var change = _player.Position.Y + _player.Velocity.Y;
				if (change > _targetPosition.Y)
				{
					y = _targetPosition.Y;
				}
				else
				{
					y = change;
				}
			}

			_player.Position = new Vector2(x, y);
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
