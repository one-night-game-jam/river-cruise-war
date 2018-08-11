using UniRx;
using UnityEngine;

namespace Fireworks
{
    public class FireworksMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float speed;

        private void FixedUpdate()
        {
            var pos = _rigidbody2D.position;
            pos.x -= speed * Time.fixedDeltaTime;
            _rigidbody2D.position = pos;
        }
    }
}