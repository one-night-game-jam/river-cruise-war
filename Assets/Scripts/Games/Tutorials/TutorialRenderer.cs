using System;
using System.Timers;
using UniRx;
using UnityEngine;
using Zenject;
using Stores;

namespace Games.Tutorials
{
    public class TutorialRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer tutorial;
        [SerializeField] private float tutorialShownSeconds;
        [Inject] private StateStore stateStore;

        private void Start()
        {
            tutorial.enabled = false;

            stateStore.State
                .Where(x => x == State.Playing)
                .Subscribe(_ =>
                {
                    tutorial.enabled = true;
                })
                .AddTo(this);

            stateStore.State
                .Where(x => x == State.Playing)
                .Delay(TimeSpan.FromSeconds(tutorialShownSeconds))
                .Subscribe(_ =>
                {
                    tutorial.enabled = false;
                })
                .AddTo(this);
        }
    }
}