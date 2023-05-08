using Code.Hittables;
using UnityEngine;

namespace Code.Obstacles
{
    public class ObstaclesDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var hittable = other.GetComponent<IHittable>();
            hittable?.Hit();
        }
    }
}
