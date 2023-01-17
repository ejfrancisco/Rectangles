using System.Drawing;

namespace GridLibrary
{
    public class Triangle: IShape
    {
        public Triangle(int radius)
        {
            Radius = radius;    
        }

        public Triangle(int radius, Point position)
        {
            Radius= radius;
            Position = position;
        }

        public int Radius { get; set; }
        public Point Position { get; set; } = new Point(0, 0);

        public int X1 { 
            get { 
                return Position.X - Radius; 
            } 
        }

        public int X2
        {
            get
            {
                return Position.X + Radius;
            }
        }
        public int Y1
        {
            get
            {
                return Position.Y- Radius;
            }
        }
        public int Y2
        {
            get
            {
                return Position.Y + Radius;
            }
        }

        public void ValidateOverlaps(IShape obj)
        {
            var obj2 = obj as Rectangle;
            if (obj2 != null)
            {
                if ((this.X1 >= obj2.X1 && this.X1 < obj2.X2) ||
                       (this.X2 > obj2.X1 && this.X2 <= obj2.X2))
                {
                    if ((this.Y1 >= obj2.Y1 && this.Y1 < obj2.Y2) ||
                        (this.Y2 > obj2.Y1 && this.Y2 <= obj2.Y2))
                    {
                        throw new ApplicationException("Overlap exception");
                    }
                }
            }
        }

        public void CheckPosition(Grid grid)
        {
            //throw new NotImplementedException();
        }
    }

}