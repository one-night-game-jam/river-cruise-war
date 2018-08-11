using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Games.Players;
using Stores;
using Inputs;

namespace Titles
{
    public class PlayerEnterer : MonoBehaviour
    {
        [SerializeField] private Vector3 initalPlayerPosition;
        [Inject] private StateStore stateStore;
        [Inject] private InputEventProvider input;
        [Inject] private PlayerMover playerMover;
        private Rigidbody2D playerRigidBody;

        private void Start()
        {
            playerRigidBody = playerMover.GetComponentInParent<Rigidbody2D>();
            stateStore.State
                .Where(x => x == State.Entering)
                .Subscribe(_ =>
                {
                    playerMover.enabled = true;
                    playerRigidBody.position = initalPlayerPosition;
                    playerRigidBody.rotation = 0;
                    stateStore.State.Value = State.Waiting;
                })
                .AddTo(this);
        }
    }
}