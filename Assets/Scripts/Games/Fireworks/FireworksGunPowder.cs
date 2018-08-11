using System;
using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksGunPowder : MonoBehaviour
    {
        [SerializeField] private FireworksCore core;

        void OnTriggerEnter2D(Collider2D other)
        {
            var enterHandler = other.GetComponent<IFireworksEnterHandler>();
            if (enterHandler != null && enterHandler.IFireworksEnter())
            {
                core.Explode();
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            var exitHandler = other.GetComponent<IFireworksExitHandler>();
            if (exitHandler != null)
            {
                exitHandler.IFireworksExit();
            }
        }
    }
}