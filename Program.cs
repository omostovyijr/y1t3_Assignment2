using Assignment_2;

class Program
{
    public static int userInputWidth = 140;
    public static int userInputHeight = 35;
    
    public static void Main(string[] args)
    {
        var generator = new MapGenerator(new MapGeneratorOptions()
        {
            Height = userInputHeight,
            Width = userInputWidth,
            Seed = 5,
            //AddTraffic = true,
            //TrafficSeed = 1234
        });

        string[,] map = generator.Generate();

        Point start = new Point(5, 0);
        Point end = new Point(135, 16);

        List<Point> path = DijkstrasPathSearch.GetShortestPath(map, start, end);

        new MapPrinter().Print(map, start, end, path);
    }
}