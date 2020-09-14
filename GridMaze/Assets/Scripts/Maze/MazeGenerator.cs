using GridMaze.Maze.Creation;
using UnityEngine;

namespace GridMaze.Maze
{
    public class MazeGenerator : MonoBehaviour
    {
        [SerializeField] private float cellWidth = 0;
        [SerializeField] private float wallWidth = 0;

        public MazeGrids GenerateMaze(MazeData mazeData)
        {
            var tr = transform;
            var tileDatas = mazeData.Tiles;
            var offset = GetWallOffset();

            var tiles = new Tile[tileDatas.GetLength(0), tileDatas.GetLength(1)];
            for (var row = 0; row < tileDatas.GetLength(0); row++)
            {
                for (var column = 0; column < tileDatas.GetLength(1); column++)
                {
                    // Ряды идут вниз по X, а линии вправо по Z
                    tiles[row, column] = Tile.Create(tileDatas[row, column], row, column,
                        tr.position + new Vector3(row * offset, 0,
                            +column * offset), tr);
                }
            }

            var horizontalWalls = new Wall[mazeData.HorizontalWallDatas.GetLength(0),
                mazeData.HorizontalWallDatas.GetLength(1)];
            for (var line = 0; line < mazeData.HorizontalWallDatas.GetLength(0); line++)
            {
                for (var wall = 0; wall < mazeData.HorizontalWallDatas.GetLength(1); wall++)
                {
                    horizontalWalls[line, wall] = Wall.CreateHorizontal(mazeData.HorizontalWallDatas[line, wall],
                        tr.position + new Vector3(line * offset - offset / 2, 0,
                            wall * offset), tr);
                }
            }

            var verticalWalls = new Wall[mazeData.VerticalWallDatas.GetLength(0),
                mazeData.VerticalWallDatas.GetLength(1)];
            for (var line = 0; line < mazeData.VerticalWallDatas.GetLength(0); line++)
            {
                for (var wall = 0; wall < mazeData.VerticalWallDatas.GetLength(1); wall++)
                {
                    verticalWalls[line, wall] = Wall.CreateVertical(mazeData.VerticalWallDatas[line, wall],
                        tr.position + new Vector3(line * offset, 0,
                            wall * offset - offset / 2), tr);
                }
            }

            return new MazeGrids(tiles, horizontalWalls, verticalWalls);
        }

        private float GetWallOffset()
        {
            var offset = cellWidth + wallWidth;
            return offset;
        }
    }
}