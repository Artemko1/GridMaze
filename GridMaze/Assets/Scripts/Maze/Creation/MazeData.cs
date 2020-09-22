namespace GridMaze.Maze.Creation
{
    public class MazeData
    {
        public readonly TileData[,] Tiles;
        public readonly WallDataLine[] HorizontalWallDataLines;
        public readonly WallDataLine[] VerticalWallDataLines;

        public MazeData(TileData[,] tiles, WallDataLine[] horizontalWallDataLines, WallDataLine[] verticalWallDataLines)
        {
            HorizontalWallDataLines = horizontalWallDataLines;
            VerticalWallDataLines = verticalWallDataLines;
            Tiles = tiles;
        }

    }
}