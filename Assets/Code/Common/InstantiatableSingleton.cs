using System;
using UnityEngine;

namespace Code.Common
{
    public abstract class InstantiatableSingleton<T> : MonoBehaviour where T: MonoBehaviour, IInstantiatableSingleton
    {
        private static T instance;
        
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                }

                if (instance == null)
                {
                    instance = new GameObject(nameof(T)).AddComponent<T>();
                    instance.OnInstanceCreated();
                    DontDestroyOnLoad(instance);
                }

                return instance;
            }
        }
    }
}