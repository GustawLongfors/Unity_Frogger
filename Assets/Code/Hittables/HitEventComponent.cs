using System;
using UnityEngine;

namespace Code.Hittables
{
    public class HitEventComponent : MonoBehaviour, IHittable
    {
        public event Action OnHit;
        public void Hit()
        {
            OnHit?.Invoke();
        }
    }
}