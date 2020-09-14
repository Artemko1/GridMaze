using UnityEngine;

namespace GridMaze.Maze.Creation
{
    [CreateAssetMenu(fileName = "WallDataCollection", menuName = "ScriptableObjects/Maze/WallDataCollection", order = 1)]
    public class WallDataCollection : ScriptableObject
    {
        [SerializeField] private WallData simpleWall = null;
        [SerializeField] private WallData emptyWall = null;

        public WallData SimpleWall => simpleWall;
        public WallData EmptyWall => emptyWall;
    }
}