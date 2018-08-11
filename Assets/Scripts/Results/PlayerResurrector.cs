using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Stores;
using Inputs;

namespace Results
{
    public class PlayerResurrector : MonoBehaviour
    {
        [Inject] private StateStore stateStore;
        [Inject] private InputEventProvider input;

        private void Start()
        {
            input.Drive
                .WithLatestFrom(stateStore.State, (_, x) => x)
                .Where(x => x == State.Resurrectable)
                .Subscribe(_ =>
                {
                    stateStore.State.Value = State.Entering;
                })
                .AddTo(this);
        }
    }
}