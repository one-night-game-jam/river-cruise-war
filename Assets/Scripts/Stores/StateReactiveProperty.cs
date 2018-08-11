using UniRx;
using UnityEngine;

namespace Stores
{
    [System.Serializable]
    public class StateReactiveProperty : ReactiveProperty<State>
    {
        public StateReactiveProperty() { }
        public StateReactiveProperty(State initialValue) : base(initialValue) { }
    }
}