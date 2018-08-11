using System;
using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksCleaner : MonoBehaviour, IFireworksEnterHandler
    {
        public bool IFireworksEnter()
        {
            return true;
        }
    }
}