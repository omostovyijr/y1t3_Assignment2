namespace Assignment_2;

public class DijkstrasPathSearch
{
    private static List<Point> GetNeighbours(string[,] map, Point currentPosition)
    {
        int width = Program.userInputWidth;
        int height = Program.userInputHeight;
        List<Point> availableNeighbours = new List<Point>();
        
        if (currentPosition.Column - 1 >= 0 && currentPosition.Column - 1 <= width - 1 && currentPosition.Row <= height - 1)
        {
            string point = map[currentPosition.Column - 1, currentPosition.Row];
            if (point != "█")
            {
                availableNeighbours.Add(new Point(currentPosition.Column - 1, currentPosition.Row));
            }
        }
        if (currentPosition.Column + 1 >= 0 && currentPosition.Column + 1 <= width - 1 && currentPosition.Row <= width - 1)
        {
            string point = map[currentPosition.Column + 1, currentPosition.Row];
            if (point != "█")
            {
                availableNeighbours.Add(new Point(currentPosition.Column + 1, currentPosition.Row));
            }
        }
        if (currentPosition.Row - 1 >= 0 && currentPosition.Row - 1 <= height - 1 && currentPosition.Column <= width - 1)
        {
            string point = map[currentPosition.Column, currentPosition.Row - 1];
            if (point != "█")
            {
                availableNeighbours.Add(new Point(currentPosition.Column, currentPosition.Row - 1));
            }
        }
        if (currentPosition.Row + 1 >= 0 && currentPosition.Row + 1 <= height - 1 && currentPosition.Column <= width - 1)
        {
            string point = map[currentPosition.Column, currentPosition.Row + 1];
            if (point != "█")
            {
                availableNeighbours.Add(new Point(currentPosition.Column, currentPosition.Row + 1));
            }
        }
        return availableNeighbours;
    }
    
    public static List<Point> GetShortestPath(string[,] map, Point start, Point goal)
    {
        List<Point> localPath = new List<Point> {start};
        Point lastPoint = goal;
        Dictionary<Point, int> costForNow = new Dictionary<Point, int>();
        Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
        Queue<Point> points = new Queue<Point>();
        points.Enqueue(start);
        costForNow.Add(start, 0);
        while (points.Count != 0)
        {
            Point current = points.Dequeue();
            List<Point> available = GetNeighbours(map, current);
            foreach (var point in available)
            {
                if (!cameFrom.ContainsKey(point))
                {
                    points.Enqueue(point);
                    cameFrom.Add(point, current);
                    if (!costForNow.ContainsKey(point))
                    {
                        costForNow.Add(point, costForNow[current] + 1);
                    }
                }
                else if (costForNow[current] + 1 < costForNow[point])
                {
                    cameFrom[point] = current;
                    costForNow[point] = costForNow[current] + 1;
                }
            }

            if (current.Equals(goal))
            {
                lastPoint = goal;
                break;
            }
        }

        var length = costForNow[lastPoint];
        for (var i = 0; i != length; i++)
        {
            localPath.Add(cameFrom[lastPoint]);
            lastPoint = cameFrom[lastPoint];
        }

        localPath.Add(goal);
        return localPath;
    }
    
}
