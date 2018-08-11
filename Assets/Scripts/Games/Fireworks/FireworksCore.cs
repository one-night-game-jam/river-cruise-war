using System;
using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksCore : MonoBehaviour
    {
        public IObservable<Unit> IsExploded => _isExploded;
        private Subject<Unit> _isExploded = new Subject<Unit>();

        public void Explode()
        {
            _isExploded.OnNext(Unit.Default);
        }
    }
}