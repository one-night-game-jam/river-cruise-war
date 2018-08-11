using Stores;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Games.UIs
{
    public class Score : MonoBehaviour
    {
        [SerializeField]
        Text text;

        [Inject]
        StateStore stateStore;
        [Inject]
        ScoreStore scoreStore;

        void Start()
        {
            this.UpdateAsObservable()
                .WithLatestFrom(stateStore.State, (_, state) => state)
                .Select(s => s == State.Playing || s == State.Dead || s == State.Resurrectable)
                .Subscribe(x => text.enabled = x)
                .AddTo(this);

            scoreStore.CruisedDistance
                .Subscribe(x => text.text = $"{x} m")
                .AddTo(this);
        }
    }
}
