using UnityEngine;

namespace GridMaze.Core
{
    public class GameAssets : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab = null;
        [SerializeField] private Material defaultWallMat = null;
        [SerializeField] private Material selectedWallMat = null;
        
        public static GameAssets Instance { get; private set; }

        public GameObject PlayerPrefab => playerPrefab;

        public Material DefaultWallMat => defaultWallMat;

        public Material SelectedWallMat => selectedWallMat;

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
