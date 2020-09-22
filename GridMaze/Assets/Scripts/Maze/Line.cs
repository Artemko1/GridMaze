namespace GridMaze.Maze
{
    public class Line
    {
        public Wall[] Walls { get; private set; } //todo добавить смещение стен

        public Line(Wall[] walls)
        {
            Walls = walls;
        }
    }
}