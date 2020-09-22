using System;
using GridMaze.Core;

namespace GridMaze.Maze
{
    public class MazeGrids
    {
        private readonly Tile[,] tiles = null;

        private readonly Line[] horizontalWallLines;
        private readonly Line[] verticalWallLines;

        public MazeGrids(Tile[,] tiles, Line[] horizontalWallLines,  Line[] verticalWallLines)
        {
            this.tiles = tiles;
            this.horizontalWallLines = horizontalWallLines;
            this.verticalWallLines = verticalWallLines;
        }

        public Tile GetTile(int x, int z) => tiles[x, z];

        public Wall GetWallByDirection(int x, int z, Direction direction)
        {
            Line[] lines;
            int lineId, wallId;
            switch (direction)
            {
                case Direction.Up:
                    lines = horizontalWallLines;
                    lineId = x;
                    wallId = z;
                    break;
                case Direction.Down:
                    lines = horizontalWallLines;
                    lineId = x + 1;
                    wallId = z;
                    break;
                case Direction.Right:
                    lines = verticalWallLines;
                    lineId = z + 1;
                    wallId = x;
                    break;
                case Direction.Left:
                    lines = verticalWallLines;
                    lineId = z;
                    wallId = x;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return lines[lineId].Walls[wallId];
        }

        public Tile GetTileInDirection(int x, int z, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    x--;
                    break;
                case Direction.Down:
                    x++;
                    break;
                case Direction.Right:
                    z++;
                    break;
                case Direction.Left:
                    z--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return tiles[x, z];
        }

        public bool IsTileInDirection(int x, int z, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    x--;
                    break;
                case Direction.Down:
                    x++;
                    break;
                case Direction.Right:
                    z++;
                    break;
                case Direction.Left:
                    z--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (x >= tiles.GetLength(0) || z >= tiles.GetLength(1) || x < 0 || z < 0)
            {
                return false;
            }

            return true;
        }

        public Line GetLineHorizontal(int x)
        {
            var lineId = x % horizontalWallLines.Length;
            return horizontalWallLines[lineId];
        }
        
        public Line GetLineVertical(int z)
        {
            var lineId = z % verticalWallLines.Length;
            return verticalWallLines[lineId];
        }
    }
}