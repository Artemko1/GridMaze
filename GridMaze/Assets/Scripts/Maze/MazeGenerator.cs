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
                    // Первый индекс вниз, второй вправо
                    tiles[row, column] = Tile.Create(tileDatas[row, column], row, column,
                        tr.position + new Vector3(row * offset, 0,
                            +column * offset), tr);
                }
            }

            var horizontalWallLines = new Line[mazeData.HorizontalWallDataLines.Length];
            for (var lineId = 0; lineId < horizontalWallLines.Length; lineId++)
            {
                var dataLine = mazeData.HorizontalWallDataLines[lineId];
                var wallLine = new Wall[dataLine.WallDatas.Length];
                for (var wall = 0; wall < wallLine.Length; wall++)
                {
                    wallLine[wall] = Wall.CreateHorizontal(dataLine.WallDatas[wall],
                        tr.position + new Vector3(lineId * offset - offset / 2, 0,
                            wall * offset), tr);
                }

                horizontalWallLines[lineId] = new Line(wallLine);
            }

            var verticalWallLines = new Line[mazeData.VerticalWallDataLines.Length];
            for (var lineId = 0; lineId < verticalWallLines.Length; lineId++)
            {
                var dataLine = mazeData.VerticalWallDataLines[lineId];
                var wallLine = new Wall[dataLine.WallDatas.Length];
                for (var wall = 0; wall < wallLine.Length; wall++)
                {
                    wallLine[wall] = Wall.CreateVertical(dataLine.WallDatas[wall],
                        tr.position + new Vector3(wall * offset, 0,
                            lineId * offset - offset / 2), tr);
                }

                verticalWallLines[lineId] = new Line(wallLine);
            }
            
            return new MazeGrids(tiles, horizontalWallLines, verticalWallLines);
        }

        private float GetWallOffset()
        {
            var offset = cellWidth + wallWidth;
            return offset;
        }
    }
}