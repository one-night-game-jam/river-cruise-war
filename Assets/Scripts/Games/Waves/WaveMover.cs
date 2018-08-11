using UnityEngine;

namespace Games.Waves
{
    public class WaveMover : MonoBehaviour
    {
        [SerializeField]
        float speed;

        void FixedUpdate()
        {
            transform.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
    }
}
