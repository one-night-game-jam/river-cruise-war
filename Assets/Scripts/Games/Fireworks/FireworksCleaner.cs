using System;
using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksCleaner : MonoBehaviour, IFireworksEnterHandler, IFireworksExitHandler
    {
        public bool IFireworksEnter()
        {
            return true;
        }

        public bool IFireworksExit()
        {
            return true;
        }
    }
}