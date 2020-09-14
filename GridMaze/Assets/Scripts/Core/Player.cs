using System;
using GridMaze.Maze;
using UnityEngine;

namespace GridMaze.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Tile currentTile;

        public static Player Create(Tile tile, Transform parent)
        {
            var player =
                Instantiate(GameAssets.Instance.PlayerPrefab, tile.transform.position, Quaternion.identity, parent)
                    .GetComponent<Player>();
            player.currentTile = tile;
            return player;
        }

        private void TryMove(Direction direction)
        {
            if (!MazeManager.Instance.IsMovementAllowed(currentTile.X, currentTile.Z, direction) ||
                !MazeManager.Instance.IsTileInDirection(currentTile.X, currentTile.Z, direction)) return;

            Move(MazeManager.Instance.GetTileInDirection(currentTile.X, currentTile.Z, direction));
        }

        private void Move(Tile tileToMove)
        {
            transform.position = tileToMove.transform.position;
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