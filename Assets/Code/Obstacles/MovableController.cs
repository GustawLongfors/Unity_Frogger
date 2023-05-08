using System;
using Code.Pause;
using UnityEngine;

namespace Code.Obstacles
{
    public class MovableController : MonoBehaviour, IPausable
    {
        [SerializeField] private Transform model;
        [SerializeField] private SimpleMovement movement;

        private ObstacleDirection direction;
        private float speed;
        
        private void Awake()
        {
            PauseManager.RegisterPausable(this);
        }

        private void OnDestroy()
        {
            PauseManager.UnregisterPausable(this);
        }

        public void Init(ObstacleDirection direction, float speed)
        {
            this.direction = direction;
            this.speed = speed;
            var rotation = model.rotation.eulerAngles;
            rotation.y = direction == ObstacleDirection.Left ? -90f : 90f;
            model.rotation = Quaternion.Euler(rotation);
            movement.Init(direction, speed);
        }

        public void SetPause(bool paused)
        {
            float currentSpeed = paused ? 0f : speed;
            movement.Init(direction,currentSpeed);
        }
    }
}