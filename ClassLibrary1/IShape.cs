using System.Drawing;

namespace GridLibrary
{
    public interface IShape
    {
        Point Position { get; set; }
        void CheckPosition(Grid grid);
    }

}