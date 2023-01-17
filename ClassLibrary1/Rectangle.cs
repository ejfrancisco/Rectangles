using System.Drawing;

namespace GridLibrary
{
    public class Rectangle : IShape
    {
        public Rectangle(int height, int width)
        {
            Width = width;
            Height = height;
        }

        public Rectangle(int height, int width, Point position)
        {
            Width = width;
            Height = height;
            Position = position;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public Point Position { get; set; } = new Point(0, 0);

        public int X1
        {
            get
            {
                return Position.X;
            }
        }

        public int X2
        {
            get
            {
                return Position.X + Width;
            }
        }
        public int Y1
        {
            get
            {
                return Position.Y;
            }
        }
        public int Y2
        {
            get
            {
                return Position.Y + Height;
            }
        }

        public void CheckPosition(Grid grid)
        {
            if (this.Position.X < 0 || this.Position.Y < 0)
            {
                throw new ApplicationException("Invalid coordinates");
            }

            if ((this.Position.X + this.Width > grid.Width)
                || (this.Position.Y + this.Height > grid.Height))
            {
                throw new ApplicationException("Out of bounds");
            }
        }

    }

}