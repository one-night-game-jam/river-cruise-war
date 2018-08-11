using UniRx;
using UnityEngine;
using Fireworks;

namespace Players
{
    public class BulletTime : MonoBehaviour, IFireworksEnterHandler, IFireworksExitHandler
    {
        [SerializeField] private float slowMotionTimeScale = 0.1f;
        [SerializeField] private float normalTimeScale = 1;
        [SerializeField] private bool isSlowMotion = false;

        public bool IFireworksEnter()
        {
            isSlowMotion = true;
            return false;
        }

        public void IFireworksExit()
        {
            isSlowMotion = false;
        }

        private void Update()
        {
            if (isSlowMotion)
            {
                Time.timeScale = slowMotionTimeScale;
            }
            else
            {
                Time.timeScale = normalTimeScale;
            }
        }
    }
}