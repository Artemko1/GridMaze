using UnityEngine;

namespace GridMaze.Maze.Creation
{
    public class RandomMazeDataProvider : MonoBehaviour, IMazeDataProvider
    {
        [SerializeField] private WallDataCollection wallDataCollection = null;
        [SerializeField] private TileData tileData = null;


        [SerializeField] private int gridWidth = 0;
        [SerializeField] private int gridLength = 0;
        [Range(0, 1)] [SerializeField] private float simpleWallProbability = 0f;


        public MazeData GetMazeData()
        {
            var tileDatas = new TileData[gridLength, gridWidth];
            // Внешний сверху вниз, внутренний слева направо
            for (var row = 0; row < gridLength; row++)
            {
                for (var column = 0; column < gridWidth; column++)
                {
                    tileDatas[row, column] = tileData;
                }
            }

            var horizontalWallDataLines = new WallDataLine[gridLength + 1];
            for (var lineId = 0; lineId < horizontalWallDataLines.Length; lineId++)
            {
                var dataLine = new WallData[gridWidth];
                for (var wallId = 0; wallId < dataLine.Length; wallId++)
                {
                    dataLine[wallId] = Random.value < simpleWallProbability
                        ? wallDataCollection.EmptyWall
                        : wallDataCollection.SimpleWall;
                }

                horizontalWallDataLines[lineId] = new WallDataLine(dataLine);
            }


            var verticalWallDataLines = new WallDataLine[gridWidth + 1];
            for (var lineId = 0; lineId < verticalWallDataLines.Length; lineId++)
            {
                var dataLine = new WallData[gridLength];
                for (var wallId = 0; wallId < dataLine.Length; wallId++)
                {
                    dataLine[wallId] = Random.value < simpleWallProbability
                        ? wallDataCollection.EmptyWall
                        : wallDataCollection.SimpleWall;
                }

                verticalWallDataLines[lineId] = new WallDataLine(dataLine);
            }

            return new MazeData(tileDatas, horizontalWallDataLines, verticalWallDataLines);
        }
    }
}