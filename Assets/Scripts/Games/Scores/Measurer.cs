using Stores;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Zenject;

namespace Games.Scores
{
    public class Measurer : MonoBehaviour
    {
        [SerializeField]
        float TimeDistanceScale;

        [Inject]
        StateStore stateStore;
        [Inject]
        ScoreStore scoreStore;

        void Start()
        {
            this.UpdateAsObservable()
                .WithLatestFrom(stateStore.State, (_, state) => state)
                .Where(s => s == State.Playing)
                .Subscribe(_ => UpdateScore())
                .AddTo(this);
            this.UpdateAsObservable()
                .WithLatestFrom(stateStore.State, (_, state) => state)
                .Where(s => s == State.Entering)
                .Subscribe(_ => ResetScore())
                .AddTo(this);
        }

        void UpdateScore()
        {
            scoreStore.CruisedDistance.Value += Time.deltaTime * TimeDistanceScale;
        }

        void ResetScore()
        {
            scoreStore.CruisedDistance.Value = 0;
        }
    }
}
