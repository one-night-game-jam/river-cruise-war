using UniRx;
using UnityEngine;
using Players;
using Zenject;
using Games.Players;
using Stores;

namespace Titles
{
    public class TitleRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer title;
        [Inject] private StateStore stateStore;

        private void Start()
        {
            stateStore.State
                .Subscribe(state =>
                {
                    if (state == State.Entering || state == State.Waiting)
                    {
                        title.enabled = true;
                    }
                    else
                    {
                        title.enabled = false;
                    }
                })
                .AddTo(this);
        }
    }
}