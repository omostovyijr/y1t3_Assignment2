namespace Assignment_2
{
    public struct Point
    {
        public int Column { get; }
        public int Row { get; }
        //public int Cost { get; }

        public Point(int column, int row)
        //public Point(int column, int row, string cost = "0")
        {
            Column = column;
            Row = row;
            //Cost = Int16.Parse(cost);
        }
    }
}
