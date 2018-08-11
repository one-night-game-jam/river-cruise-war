using System;
using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksGunPowder : MonoBehaviour
    {
        [SerializeField] private FireworksCore core;
        [SerializeField] private double fireworksDestroyDelay;

        void OnTriggerEnter2D(Collider2D other)
        {
            var enterHandler = other.GetComponent<IFireworksEnterHandler>();
            if (enterHandler != null && enterHandler.IFireworksEnter())
            {
                core.Explode();
                Observable.Timer(TimeSpan.FromSeconds(fireworksDestroyDelay))
                    .Subscribe(_ => Destroy(this.gameObject));
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            var exitHandler = other.GetComponent<IFireworksExitHandler>();
            if (exitHandler != null) exitHandler.IFireworksExit();
        }
    }
}