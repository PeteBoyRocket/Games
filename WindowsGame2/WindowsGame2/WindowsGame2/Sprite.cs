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

		public Vector2 CentrePoint
		{
			get
			{
				return new Vector2(Position.X - _xCentreOffset, Position.Y - _yCentreOffset);
			}
		}

		public Vector2 Velocity { get; set; }
	}
}
