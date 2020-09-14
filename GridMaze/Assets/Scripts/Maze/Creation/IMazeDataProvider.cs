namespace GridMaze.Maze.Creation
{
    /// <summary>
    /// Возвращает готовый набор вертикальных и горизонтальных стен
    /// </summary>
    public interface IMazeDataProvider
    {
        MazeData GetMazeData();
    }
}