using System;
using UniRx;
using UnityEngine;

namespace Stores
{
    public class StateStore : MonoBehaviour
    {
        public StateReactiveProperty State;

        public IObservable<bool> IsPlayerJumpable()
        {
            return State.Select(s => s == Stores.State.Entering || s == Stores.State.Playing);
        }
    }
}