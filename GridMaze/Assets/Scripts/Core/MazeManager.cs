using System;
using GridMaze.Maze;
using GridMaze.Maze.Creation;
using UnityEngine;

namespace GridMaze.Core
{
    public class MazeManager : MonoBehaviour
    {
        // public static MazeManager Instance { get; private set; }

        private IMazeDataProvider mazeDataProvider;
        private MazeGenerator mazeGenerator;
        private WallSelector wallSelector;

        private MazeGrids mazeGrids;

        private void Awake()
        {
            // if (Instance != null)
            // {
            //     Destroy(gameObject);
            //     return;
            // }
            //
            // Instance = this;

            mazeDataProvider = GetComponent<IMazeDataProvider>();
            mazeGenerator = GetComponent<MazeGenerator>();
        }

        private void Start()
        {
            var mazeData = mazeDataProvider.GetMazeData();
            mazeGrids = mazeGenerator.GenerateMaze(mazeData);

            wallSelector = new WallSelector(mazeGrids);

            Player.Create(mazeGrids.GetTile(0, 0), transform, mazeGrids);
            
            wallSelector.ResumeSelection();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                wallSelector.SwitchLines();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                wallSelector.SelectNextLine();
            }
        }
    }
}