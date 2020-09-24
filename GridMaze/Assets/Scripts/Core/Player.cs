using System;
using DG.Tweening;
using GridMaze.Maze;
using UnityEngine;

namespace GridMaze.Core
{
    public class Player : MonoBehaviour
    {
        private Tile currentTile;
        private MazeGrids mazeGrids;

        public static Player Create(Tile tile, Transform parent, MazeGrids mazeGrids)
        {
            var player =
                Instantiate(GameAssets.Instance.PlayerPrefab, tile.transform.position, Quaternion.identity, parent)
                    .GetComponent<Player>();
            player.currentTile = tile;
            player.mazeGrids = mazeGrids;
            return player;
        }

        private void TryMove(Direction direction)
        {
            if (!mazeGrids.GetWallByDirection(currentTile.X, currentTile.Z, direction).IsMoveAllowed ||
                !mazeGrids.IsTileInDirection(currentTile.X, currentTile.Z, direction)) return;

            Move(mazeGrids.GetTileInDirection(currentTile.X, currentTile.Z, direction));
        }

        private void Move(Tile tileToMove)
        {
            // transform.position = tileToMove.transform.position;
            transform.DOMove(tileToMove.transform.position, 0.2f);
            currentTile = tileToMove;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMove(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                TryMove(Direction.Down);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                TryMove(Direction.Right);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                TryMove(Direction.Left);
            }
        }
    }
}