namespace GridLibrary
{
    public class CheckRectAndCircle : ICheckOverlap
    {

        Rectangle _obj1;
        Circle _obj2;

        public CheckRectAndCircle(IShape obj1, IShape obj2)
        {
            if (obj1 is Rectangle)
            {
                _obj1 = (Rectangle)obj1;
            }
            if (obj2 is Circle)
            {
                _obj2 = (Circle)obj2;
            }

        }


        public void CheckOverlap()
        {
            //throw new NotImplementedException();
        }
    }

}