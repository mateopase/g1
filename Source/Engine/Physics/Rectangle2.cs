using System;

using Microsoft.Xna.Framework;

namespace Engine.Physics
{
    /// A floating point version of the Monogame Rectangle class.
    /// Borrowed from the Humper RectangleF class.
    public struct Rectangle2 : IEquatable<Rectangle2>
    {
        // Top left point
        public float X;

        // Top left point
        public float Y;

        public float Width;

        public float Height;

        public float Left => X;

        public float Right => X + Width;

        public float Top => Y;

        public float Bottom => Y + Height;

        public Vector2 Location
        {
            get { return new Vector2(X, Y); }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        public Vector2 Center => new Vector2(X + Width / 2f, Y + Height / 2f);

        public Rectangle2(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle2(Vector2 location, Vector2 size)
        {
            X = location.X;
            Y = location.Y;
            Width = size.X;
            Height = size.Y;
        }

        // Compares whether two <see cref="RectangleF"/> instances are equal.
        public static bool operator ==(Rectangle2 a, Rectangle2 b)
        {
            const float epsilon = 0.00001f;
            return Math.Abs(a.X - b.X) < epsilon
                && Math.Abs(a.Y - b.Y) < epsilon
                && Math.Abs(a.Width - b.Width) < epsilon
                && Math.Abs(a.Height - b.Height) < epsilon;
        }

        // Compares whether two <see cref="RectangleF"/> instances are not equal.
        public static bool operator !=(Rectangle2 a, Rectangle2 b)
        {
            return !(a == b);
        }

        // Gets whether or not the provided coordinates lie within the bounds of this <see cref="RectangleF"/>.
        public bool Contains(int x, int y)
        {
            return X <= x && x < X + Width && Y <= y && y < Y + Height;
        }

        public bool Contains(float x, float y)
        {
            return X <= x && x < X + Width && Y <= y && y < Y + Height;
        }

        public bool Contains(Vector2 value)
        {
            return X <= value.X && value.X < X + Width && Y <= value.Y && value.Y < Y + Height;
        }

        public bool Contains(Rectangle2 value)
        {
            return (X <= value.X) && (value.X + value.Width <= X + Width) && (Y <= value.Y) && (value.Y + value.Height <= Y + Height);
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle2 && this == (Rectangle2)obj;
        }

        public bool Equals(Rectangle2 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();
        }

        // Gets whether or not the other RectangleF intersects with this RectangleF.
        public bool Intersects(Rectangle2 value)
        {
            return value.Left < Right && Left < value.Right &&
                   value.Top < Bottom && Top < value.Bottom;
        }


        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle2"/>.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="Rectangle2"/>.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="Rectangle2"/>.</param>
        public void Offset(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle2"/>.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="Rectangle2"/>.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="Rectangle2"/>.</param>
        public void Offset(float offsetX, float offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        // Changes the Location of this RectangleF by some amount
        public void Move(Vector2 amount)
        {
            X += amount.X;
            Y += amount.Y;
        }

        public override string ToString()
        {
            return "{X:" + X + " Y:" + Y + " Width:" + Width + " Height:" + Height + "}";
        }

        /// <summary>
        /// Calculates the signed depth of intersection between two rectangles.
        /// </summary>
        /// <returns>
        /// The amount of overlap between two intersecting rectangles. These
        /// depth values can be negative depending on which wides the rectangles
        /// intersect. This allows callers to determine the correct direction
        /// to push objects in order to resolve collisions.
        /// If the rectangles are not intersecting, Vector2.Zero is returned.
        /// </returns>
        public Vector2 IntersectionDepth(Rectangle2 other)
        {
            // Calculate half sizes.
            var thisHalfWidth = Width / 2.0f;
            var thisHalfHeight = Height / 2.0f;
            var otherHalfWidth = other.Width / 2.0f;
            var otherHalfHeight = other.Height / 2.0f;

            // Calculate centers.
            var centerA = new Vector2(Left + thisHalfWidth, Top + thisHalfHeight);
            var centerB = new Vector2(other.Left + otherHalfWidth, other.Top + otherHalfHeight);

            // Calculate current and minimum-non-intersecting distances between centers.
            var distanceX = centerA.X - centerB.X;
            var distanceY = centerA.Y - centerB.Y;
            var minDistanceX = thisHalfWidth + otherHalfWidth;
            var minDistanceY = thisHalfHeight + otherHalfHeight;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
                return Vector2.Zero;

            // Calculate and return intersection depths.
            var depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
            var depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
            return new Vector2(depthX, depthY);
        }
    }
}