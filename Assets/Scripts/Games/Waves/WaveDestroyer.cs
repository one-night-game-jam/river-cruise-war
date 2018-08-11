using UniRx;
using UnityEngine;

namespace Games.Waves
{
    public class WaveDestroyer : MonoBehaviour
    {
        [SerializeField]
        float positionX;

        void Start()
        {
            this.ObserveEveryValueChanged(x => x.transform.position.x)
                .First(x => x < positionX)
                .Subscribe(_ => Destroy(gameObject));
        }
    }
}
