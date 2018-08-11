using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Stores;
using Inputs;

namespace Titles
{
    public class GameStarter : MonoBehaviour
    {
        [Inject] private StateStore stateStore;
        [Inject] private InputEventProvider input;

        private void Start()
        {
            input.Drive
                .WithLatestFrom(stateStore.State, (_, x) => x)
                .Where(x => x == State.Waiting)
                .Subscribe(_ =>
                {
                    stateStore.State.Value = State.Playing;
                })
                .AddTo(this);
        }
    }
}