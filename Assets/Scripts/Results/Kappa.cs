using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;
using Games.Players;
using Stores;

namespace Results
{
    public class Kappa : MonoBehaviour
    {
        [SerializeField] private float sinkSpeed;
        [SerializeField] private float sinkRotationRate;
        [SerializeField] private float resurrectablePlayerMinY;
        [Inject] private StateStore stateStore;
        [Inject] private PlayerMover playerMover;
        private bool isPlayerSinking = false;
        private Rigidbody2D playerRigidBody;

        private void Start()
        {
            playerRigidBody = playerMover.GetComponentInParent<Rigidbody2D>();
            this.FixedUpdateAsObservable()
                .WithLatestFrom(stateStore.State, (_, x) => x)
                .Where(x => x == State.Dead)
                .Subscribe(_ =>
                {
                    SinkPlayer();
                    MakePlayerResurrectable();
                })
                .AddTo(this);
        }

        void SinkPlayer()
        {
            playerMover.enabled = false;
            var pos = playerRigidBody.position;
            pos.y -= sinkSpeed * Time.fixedDeltaTime;
            playerRigidBody.position = pos;

            var rot = playerRigidBody.rotation;
            rot += sinkRotationRate * Time.fixedDeltaTime;
            playerRigidBody.rotation = rot;
        }

        void MakePlayerResurrectable()
        {
            if (resurrectablePlayerMinY >= playerRigidBody.position.y)
            {
                stateStore.State.Value = State.Resurrectable;
                return;
            }
        }
    }
}
