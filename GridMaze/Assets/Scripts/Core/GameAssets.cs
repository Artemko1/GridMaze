using UnityEngine;

namespace GridMaze.Core
{
    public class GameAssets : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        public static GameAssets Instance { get; private set; }

        public GameObject PlayerPrefab => playerPrefab;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}
