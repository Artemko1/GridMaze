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
        
        private readonly Wall[] selectedVerticalWallLine; // Длина равна высоте лабиринта
        private readonly Wall[] selectedHorizontalWallLine; // Длина равна ширине лабиринта

        public MazeGrids(Tile[,] tiles, Wall[,] horizontalWalls, Wall[,] verticalWalls)
        {
            this.tiles = tiles;
            this.horizontalWalls = horizontalWalls;
            this.verticalWalls = verticalWalls;
            selectedVerticalWallLine = new Wall[verticalWalls.GetLength(0)]; // должно быть 2
            selectedHorizontalWallLine = new Wall[horizontalWalls.GetLength(1)]; // должно быть 7
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

        public Wall[] GetLineHorizontal(int x)
        {
            var line = x % horizontalWalls.GetLength(0);
            for (var i = 0; i < selectedHorizontalWallLine.Length; i++)
            {
                selectedHorizontalWallLine[i] = horizontalWalls[line, i];
            }

            return selectedHorizontalWallLine;
        }

        public Wall[] GetLineVertical(int z)
        {
            var column = z % verticalWalls.GetLength(1);
            for (var i = 0; i < selectedVerticalWallLine.Length; i++)
            {
                selectedVerticalWallLine[i] = verticalWalls[i, column];
            }

            return selectedVerticalWallLine;
        }
    }
}