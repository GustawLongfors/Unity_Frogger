using Code.Hittables;
using Code.Player;
using UnityEngine;

namespace Code.Obstacles
{
    public class Obstacle : MonoBehaviour, IHittable
    {
        private void OnTriggerEnter(Collider other)
        {
            var hittable = other.GetComponent<IHittable>();
            var player = other.GetComponent<PlayerController>();
            if (hittable != null && player != null)
            {
                hittable.Hit();
            }
        }

        public void Hit()
        {
            Destroy(gameObject);
        }
    }
}
