using System.Drawing;

namespace GridLibrary
{
    public class ValidateOverlapFactory
    {
        public static ICheckOverlap? CreateOverlapChecker(IShape obj1, IShape obj2)
        {
            if(obj1 is Rectangle && obj2 is Rectangle)
            {
                return new CheckRectAndRect(obj1, obj2);
            }

            if (obj1 is Rectangle && obj2 is Circle)
            {
                return new CheckRectAndCircle(obj1, obj2);
            }

            if (obj1 is Circle && obj2 is Rectangle)
            {
                return new CheckCircleAndRect(obj1, obj2);
            }

            throw new ApplicationException("No checker created");
        }
    }

}