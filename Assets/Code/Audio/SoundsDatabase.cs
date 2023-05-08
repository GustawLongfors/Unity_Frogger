using UnityEngine;

namespace Code.Audio
{
    [CreateAssetMenu(fileName = "Sounds Database", menuName = "Data/Audio/Sounds Database", order = 0)]
    public class SoundsDatabase : ScriptableObject
    {
        [SerializeField] private AudioClip musicClip;
        [SerializeField] private AudioClip jumpClip;
        [SerializeField] private AudioClip hitClip;

        public AudioClip MusicClip => musicClip;
        public AudioClip JumpClip => jumpClip;
        public AudioClip HitClip => hitClip;
    }
}