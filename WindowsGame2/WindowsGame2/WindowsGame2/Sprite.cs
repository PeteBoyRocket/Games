using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame2
{
	internal class Sprite
	{
		private float _xCentreOffset;
		private float _yCentreOffset;
		private Texture2D _texture;

		public Texture2D Texture
		{
			get
			{
				return _texture;
			}
			set
			{
				_texture = value;

				_xCentreOffset = _texture.Width / 2;
				_yCentreOffset = _texture.Height / 2;
			}
		}

		public Vector2 Position { get; set; }

		public Vector2 TargetPosition { get; set; }

		public Vector2 CentrePoint
		{
			get
			{
				return new Vector2(Position.X + _xCentreOffset, Position.Y + _yCentreOffset);
			}
		}

		public Vector2 Velocity { get; set; }

		public void Update(GameTime gameTime)
		{
			var xVelocity = Velocity.X * gameTime.ElapsedGameTime.Milliseconds;

			var x = 0f;

			if (Position.X >= TargetPosition.X)
			{
				var change = Position.X - xVelocity;
				if (change < TargetPosition.X)
				{
					x = TargetPosition.X;
				}
				else
				{
					x = change;
				}
			}
			else if (Position.X < TargetPosition.X)
			{
				var change = Position.X + xVelocity;
				if (change > TargetPosition.X)
				{
					x = TargetPosition.X;
				}
				else
				{
					x = change;
				}
			}

			var yVelocity = Velocity.Y * gameTime.ElapsedGameTime.Milliseconds;
			var y = 0f;

			if (Position.Y >= TargetPosition.Y)
			{
				var change = Position.Y - yVelocity;
				if (change < TargetPosition.Y)
				{
					y = TargetPosition.Y;
				}
				else
				{
					y = change;
				}
			}
			else if (Position.Y < TargetPosition.Y)
			{
				var change = Position.Y + yVelocity;
				if (change > TargetPosition.Y)
				{
					y = TargetPosition.Y;
				}
				else
				{
					y = change;
				}
			}

			Position = new Vector2(x, y);
		}
	}
}
