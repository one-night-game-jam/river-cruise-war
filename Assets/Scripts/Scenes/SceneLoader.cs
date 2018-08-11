using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private List<string> _sceneNames;

        private void Start()
        {
            var loaded = Enumerable.Range(0, SceneManager.sceneCount)
                .Select(SceneManager.GetSceneAt)
                .Select(s => s.name).ToList();
            LoadScenesAdditive(_sceneNames.Except(loaded));
        }

        private static void LoadScenesAdditive(IEnumerable<string> sceneNames)
        {
            foreach (var name in sceneNames)
            {
                SceneManager.LoadScene(name, LoadSceneMode.Additive);
            }
        }
    }
}