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

        float velocity;
        float angle;

        void FixedUpdate()
        {
            velocity -= gravity * Time.fixedDeltaTime;
            _rigidbody2D.position += Vector2.up * velocity * Time.fixedDeltaTime;
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
