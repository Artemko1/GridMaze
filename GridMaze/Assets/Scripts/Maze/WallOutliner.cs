using GridMaze.Core;
using UnityEngine;

namespace GridMaze.Maze
{
    public static class WallOutliner
    {
        public static void Select(Renderer rend)
        {
            rend.material = GameAssets.Instance.SelectedWallMat;
        }

        public static void Deselect(Renderer rend)
        {
            rend.material = GameAssets.Instance.DefaultWallMat;
        }
    }
}