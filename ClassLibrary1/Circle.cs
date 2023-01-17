using System.Drawing;

namespace GridLibrary
{
    public class Circle: IShape
    {
        public Circle(int radius)
        {
            Radius = radius;    
        }

        public Circle(int radius, Point position)
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

      
        public void CheckPosition(Grid grid)
        {
            //throw new NotImplementedException();
        }
    }

}