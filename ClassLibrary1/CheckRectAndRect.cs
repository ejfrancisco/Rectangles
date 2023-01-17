namespace GridLibrary
{
    public class CheckRectAndRect : ICheckOverlap
    {
        Rectangle _obj1;
        Rectangle _obj2;
        public CheckRectAndRect(IShape obj1, IShape obj2)
        {
            _obj1 = (Rectangle) obj1;
            _obj2 = (Rectangle) obj2;
        }


        public void CheckOverlap()
        {
            if ((_obj1.X1 >= _obj2.X1 && _obj1.X1 < _obj2.X2) ||
                (_obj1.X2 > _obj2.X1 && _obj1.X2 <= _obj2.X2))
            {
                if ((_obj1.Y1 >= _obj2.Y1 && _obj1.Y1 < _obj2.Y2) ||
                    (_obj1.Y2 > _obj2.Y1 && _obj1.Y2 <= _obj2.Y2))
                {
                    throw new ApplicationException("Overlap exception");
                }
            }
        }
    }

}