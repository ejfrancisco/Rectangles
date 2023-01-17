using System.Drawing;

namespace GridLibrary
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Grid(int heigth, int width)
        {
            if (heigth < 5 || heigth > 25 || width < 5 || width > 25)
            {
                throw new ApplicationException("Grid must not be less 5 or greater than 25.");
            }

            Height = heigth;
            Width = width;
            Shapes = new List<IShape>();
        }


        public List<IShape> Shapes { get; set; }

        public void Add(IShape shape)
        {
            shape.CheckPosition(this);
            this.Shapes.ForEach(x => {
                var checker = ValidateOverlapFactory.CreateOverlapChecker(shape, x);
                checker?.CheckOverlap();
            });

            Shapes.Add(shape);
        }

        public void Remove(Point position)
        {
            var itemsToDelete = new List<IShape>();

            Shapes.ForEach(shape =>
            {
                Rectangle rect = (Rectangle)shape;
                if (position.X >= rect.X1 && position.X <= rect.X2 &&
                    position.Y >= rect.Y1 && position.Y <= rect.Y2)
                {
                    itemsToDelete.Add(rect);
                }
            });

            itemsToDelete.ForEach(z => Shapes.Remove(z));
        }
    }
}
