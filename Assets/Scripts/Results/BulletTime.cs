using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Results
{
    public class BulletTime : MonoBehaviour
    {
        [SerializeField] private float slowMotionTimeScale;
        [SerializeField] private float normalTimeScale;
        [SerializeField] private bool isSlowMotion = false;

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