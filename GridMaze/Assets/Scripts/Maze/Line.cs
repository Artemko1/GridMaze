using System.Collections.Generic;
using UnityEngine;

namespace GridMaze.Maze
{
    public class Line
    {
        public List<Wall> Walls { get; }

        private readonly Vector3[] positions;

        public Line(List<Wall> walls)
        {
            // Walls = new List<Wall>(walls);
            Walls = walls;
            positions = new Vector3[walls.Count];
            for (var i = 0; i < positions.Length; i++)
            {
                positions[i] = walls[i].transform.localPosition;
            }
        }


        public void ShiftLineForward()
        {
            // Последний элемент встает на первое место
            var item = Walls[Walls.Count - 1];
            Walls.RemoveAt(Walls.Count - 1);
            Walls.Insert(0, item);

            for (var i = 0; i < Walls.Count; i++)
            {
                Walls[i].transform.localPosition = positions[i];
            }
        }

        public void ShiftLineBackward()
        {
            // Первый элемент встает последним
            var item = Walls[0];
            Walls.RemoveAt(0);
            Walls.Add(item);

            for (var i = 0; i < Walls.Count; i++)
            {
                Walls[i].transform.localPosition = positions[i];
            }
        }
    }
}