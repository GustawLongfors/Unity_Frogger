using UnityEngine;

namespace Code.Player
{
    public class PlayerGroundCheck
    {
        private readonly Transform rayOrigin;
        private const float RAY_DISTANCE = 0.25f;
        private const string WATER_TAG = "Water";
        
        public PlayerGroundCheck(Transform rayOrigin)
        {
            this.rayOrigin = rayOrigin;
        }
        
        public bool IsGrounded(out Transform ground)
        {
            bool isWater = false;
            ground = null;
            if (Physics.Raycast(rayOrigin.position,Vector3.down, out var hitInfo, RAY_DISTANCE))
            {
                ground = hitInfo.collider.transform;
                isWater = hitInfo.collider.CompareTag(WATER_TAG);
            }
            return !isWater;
        }
    }
}
