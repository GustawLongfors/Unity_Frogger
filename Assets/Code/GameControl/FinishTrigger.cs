using System;
using Code.Player;
using UnityEngine;

namespace Code.GameControl
{
    public class FinishTrigger : MonoBehaviour
    {
        public event Action OnPlayerHit;
    
        private void OnTriggerEnter(Collider collider)
        {
            var player = collider.GetComponent<PlayerController>();
            if(player == null) return;
            OnPlayerHit?.Invoke();
        }
    }
}
