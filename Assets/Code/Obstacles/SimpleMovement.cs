using UnityEngine;

namespace Code.Obstacles
{
    public class SimpleMovement : MonoBehaviour
    {
        private float speed;

        public void Init(ObstacleDirection direction, float speed)
        {
            float absolute = Mathf.Abs(speed);
            this.speed = direction == ObstacleDirection.Left ? -absolute : absolute;
        }
        
        private void Update()
        {
            Move();
        }
        
        private void Move()
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
    }
}
