namespace GridMaze.Maze.Creation
{
    public class MazeData
    {
        public readonly TileData[,] Tiles;
        public readonly WallData[,] HorizontalWallDatas;
        public readonly WallData[,] VerticalWallDatas;

        public MazeData(TileData[,] tiles, WallData[,] horizontalWallDatas, WallData[,] verticalWallDatas)
        {
            HorizontalWallDatas = horizontalWallDatas;
            VerticalWallDatas = verticalWallDatas;
            Tiles = tiles;
        }

    }
}