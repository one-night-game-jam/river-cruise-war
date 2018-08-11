using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private List<string> _sceneNames;

        private void Start()
        {
            LoadScenesAdditive();
        }

        private void LoadScenesAdditive()
        {
            foreach (var name in _sceneNames)
            {
                SceneManager.LoadScene(name, LoadSceneMode.Additive);
            }
        }
    }
}