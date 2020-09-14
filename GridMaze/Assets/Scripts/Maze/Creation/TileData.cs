using UnityEngine;

namespace GridMaze.Maze.Creation
{
    [CreateAssetMenu(fileName = "TileData", menuName = "ScriptableObjects/Maze/TileData", order = 2)]
    public class TileData : ScriptableObject
    {
        [SerializeField] private Tile prefab = null;
        public Tile Prefab => prefab;
    }
}