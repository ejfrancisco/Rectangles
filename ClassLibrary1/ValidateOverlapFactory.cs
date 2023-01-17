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

            throw new ApplicationException("No checker created");
        }
    }

}