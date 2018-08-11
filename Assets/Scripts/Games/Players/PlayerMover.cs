using Inputs;
using Stores;
using UniRx;
using UnityEngine;
using Zenject;

namespace Games.Players
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        Rigidbody2D _rigidbody2D;
        [SerializeField]
        float gravity;
        [SerializeField]
        float buoyancy;
        [SerializeField]
        float waterElasticity;
        [SerializeField]
        float pitchRate;
        [SerializeField]
        float minJumpVelocity;
        [SerializeField]
        float jumpableAltitude;
        [SerializeField]
        float jumpCooldownTimeSeconds;

        [Inject]
        InputEventProvider inputEventProvider;
        [Inject]
        StateStore stateStore;

        public float positionX;

        float velocity;
        float angle;
        float remainingJumpCooldownTimeSeconds;

        int mapLayerMask;

        void Awake()
        {
            mapLayerMask = 1 << LayerMask.NameToLayer("Map");
        }

        void Start()
        {
            inputEventProvider.Drive
                .Where(_ => remainingJumpCooldownTimeSeconds <= 0)
                .WithLatestFrom(stateStore.IsPlayerJumpable(), (_, x) => x)
                .Where(x => x && IsJumpable())
                .Subscribe(_ => Jump())
                .AddTo(this);
        }

        void Update()
        {
            remainingJumpCooldownTimeSeconds -= Time.deltaTime;
        }

        void FixedUpdate()
        {
            velocity -= gravity * Time.fixedDeltaTime;
            var pos = _rigidbody2D.position;
            pos += Vector2.up * velocity * Time.fixedDeltaTime;
            pos.x = positionX;
            _rigidbody2D.position = pos;

            _rigidbody2D.rotation = angle;
        }

        void OnTriggerStay2D(Collider2D other)
        {
            velocity += buoyancy * Time.deltaTime;
            angle = velocity * pitchRate;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            velocity *= waterElasticity;
        }

        bool IsJumpable()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down, jumpableAltitude, mapLayerMask);
            return hit.collider != null;
        }

        void Jump()
        {
            velocity += Mathf.Max(velocity, minJumpVelocity);
            remainingJumpCooldownTimeSeconds = jumpCooldownTimeSeconds;
        }
    }
}
