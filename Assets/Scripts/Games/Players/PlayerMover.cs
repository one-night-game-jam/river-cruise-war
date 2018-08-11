using UnityEngine;

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

        public float positionX;

        float velocity;
        float angle;


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
    }
}
