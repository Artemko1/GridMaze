using UnityEngine;

namespace GridMaze.Maze.Creation
{
    [CreateAssetMenu(fileName = "WallData", menuName = "ScriptableObjects/Maze/WallData", order = 0)]
    public class WallData : ScriptableObject
    {
        [SerializeField] private Wall prefab = null;
        [SerializeField] private bool isWalkable = false;
        
        public Wall Prefab => prefab;
        public bool IsWalkable => isWalkable;
    }
}