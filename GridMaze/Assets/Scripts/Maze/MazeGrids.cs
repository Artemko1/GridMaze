using System;
using GridMaze.Core;
using UnityEngine;

namespace GridMaze.Maze
{
    public class MazeGrids
    {
        private readonly Tile[,] tiles = null;
        private readonly Wall[,] horizontalWalls;
        private readonly Wall[,] verticalWalls;

        public MazeGrids(Tile[,] tiles, Wall[,] horizontalWalls, Wall[,] verticalWalls)
        {
            this.tiles = tiles;
            this.horizontalWalls = horizontalWalls;
            this.verticalWalls = verticalWalls;
        }

        public Tile GetTile(int x, int z) => tiles[x, z];

        public Wall GetWallByDirection(int x, int z, Direction direction)
        {
            Wall[,] walls;
            switch (direction)
            {
                case Direction.Up:
                    walls = horizontalWalls;
                    break;
                case Direction.Down:
                    x++;
                    walls = horizontalWalls;
                    break;
                case Direction.Right:
                    z++;
                    walls = verticalWalls;
                    break;
                case Direction.Left:
                    walls = verticalWalls;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return walls[x, z];
        }

        
        /// <summary>
        /// Возвращает null, если нет Tile по direction.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

            if (x >= tiles.GetLength(0) || z >= tiles.GetLength(1) || x < 0 || z < 0)
            {
                Debug.LogError("No Tile in Direction");
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
    }
}