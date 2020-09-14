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

            var horizontalWallDatas = new WallData[gridLength + 1, gridWidth];
            // Внешний сверху вниз, внутренний слева направо
            for (var row = 0; row < horizontalWallDatas.GetLength(0); row++)
            {
                for (var column = 0; column < horizontalWallDatas.GetLength(1); column++)
                {
                    horizontalWallDatas[row, column] = Random.value < simpleWallProbability
                        ? wallDataCollection.EmptyWall
                        : wallDataCollection.SimpleWall;
                }
            }

            var verticalWallDatas = new WallData[gridLength, gridWidth + 1];
            // Внешний сверху вниз, внутренний слева направо
            for (var row = 0; row < verticalWallDatas.GetLength(0); row++)
            {
                for (var column = 0; column < verticalWallDatas.GetLength(1); column++)
                {
                    verticalWallDatas[row, column] = Random.value < simpleWallProbability
                        ? wallDataCollection.EmptyWall
                        : wallDataCollection.SimpleWall;
                }
            }

            return new MazeData(tileDatas, horizontalWallDatas, verticalWallDatas);
        }
    }
}