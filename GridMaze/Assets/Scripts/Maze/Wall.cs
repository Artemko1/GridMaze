﻿using GridMaze.Maze.Creation;
using UnityEngine;

namespace GridMaze.Maze
{
    public class Wall : MonoBehaviour
    {
        private WallData data;

        public bool IsMoveAllowed => data.IsWalkable;

        public static Wall CreateHorizontal(WallData wallData, Vector3 position, Transform parent)
        {
            var wall = Instantiate(wallData.Prefab, position, Quaternion.identity, parent);
            wall.data = wallData;
            return wall;
        }

        public static Wall CreateVertical(WallData wallData, Vector3 position, Transform parent)
        {
            var wall = Instantiate(wallData.Prefab, position, Quaternion.Euler(0, -90, 0), parent);
            wall.data = wallData;
            return wall;
        }
    }
}