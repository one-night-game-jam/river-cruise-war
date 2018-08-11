using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksRenderer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem fireballParticleSystem;
        [SerializeField] private ParticleSystem explosionParticleSystem;
        [SerializeField] private FireworksCore core;

        private void Start()
        {
            fireballParticleSystem.gameObject.SetActive(true);
            explosionParticleSystem.gameObject.SetActive(false);
            core.IsExploded.Subscribe(_ =>
            {
                fireballParticleSystem.gameObject.SetActive(false);
                explosionParticleSystem.gameObject.SetActive(true);
            });
        }
    }
}