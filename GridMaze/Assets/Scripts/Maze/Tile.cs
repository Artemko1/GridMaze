using GridMaze.Maze.Creation;
using UnityEngine;

namespace GridMaze.Maze
{
    public class Tile : MonoBehaviour
    {
        public int X { get; private set; }
        public int Z { get; private set; }

        public static Tile Create(TileData tileData, int x, int z, Vector3 position, Transform parent)
        {
            var tile = Instantiate(tileData.Prefab, position, Quaternion.identity, parent).GetComponent<Tile>();
            tile.X = x;
            tile.Z = z;
            return tile;
        }
    }
}