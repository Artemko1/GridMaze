using GridMaze.Maze;
using GridMaze.Maze.Creation;
using UnityEngine;

namespace GridMaze.Core
{
    public class MazeManager : MonoBehaviour
    {
        public static MazeManager Instance { get; private set; }

        private IMazeDataProvider mazeDataProvider;
        private MazeGenerator mazeGenerator;

        private MazeGrids mazeGrids;

        public bool IsMovementAllowed(int x, int z, Direction direction)
        {
            var wall = mazeGrids.GetWallByDirection(x, z, direction);
            return wall.IsMoveAllowed;
        }

        public Tile GetTileInDirection(int x, int z, Direction direction)
        {
            return mazeGrids.GetTileInDirection(x, z, direction);
        }

        public bool IsTileInDirection(int x, int z, Direction direction)
        {
            return mazeGrids.IsTileInDirection(x, z, direction);
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            mazeDataProvider = GetComponent<IMazeDataProvider>();
            mazeGenerator = GetComponent<MazeGenerator>();
        }

        private void Start()
        {
            var mazeData = mazeDataProvider.GetMazeData();
            mazeGrids = mazeGenerator.GenerateMaze(mazeData);

            Player.Create(mazeGrids.GetTile(0, 0), transform);
        }
    }
}