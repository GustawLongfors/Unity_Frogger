using UnityEngine;

namespace Code.Player
{
    [CreateAssetMenu(fileName = "Player Parameters", menuName = "Data/Player/Parameters", order = 0)]
    public class PlayerParameters : ScriptableObject
    {
        [SerializeField] private float jumpPower;
        [SerializeField] private float jumpDuration;
        [SerializeField] private Vector2 xMovementRange;
        
        public float JumpPower => jumpPower;
        public float JumpDuration => jumpDuration;
        public Vector2 XMovementRange => xMovementRange;
    }
}