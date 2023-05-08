using Code.Audio;
using Code.GameControl;
using Code.Hittables;
using Code.Input;
using Code.Pause;
using UnityEngine;

namespace Code.Player
{
    public class PlayerController : MonoBehaviour, IPausable
    {
        [SerializeField] private PlayerParameters playerParameters;
        [SerializeField] private HitEventComponent hitEventComponent;
        [SerializeField] private SoundsDatabase soundsDatabase;
        
        private PlayerInput input;
        private PlayerMovement movement;
        private PlayerGroundCheck groundCheck;
        private PlayerAudio audio;

        private const string PLATFORM_TAG = "Platform";

        public HitEventComponent HitEventComponent => hitEventComponent;
            
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            input = new();
            input.Enabled = false;
            movement = new(input, transform, playerParameters);
            groundCheck = new PlayerGroundCheck(transform);
            audio = new PlayerAudio(AudioManager.Instance.Player, soundsDatabase);
            movement.OnMoveFinished += Movement_OnMoveFinished;
            movement.OnMoveStarted += Movement_OnMoveStarted;
            hitEventComponent.OnHit += HitEventComponent_OnHit;
            GameManager.OnGameLost += GameManager_OnGameLost;
            GameManager.OnLevelFinished += GameManager_OnLevelFinished;
            GameManager.OnLevelStart += GameManager_OnLevelStart;
            PauseManager.RegisterPausable(this);
        }

        private void OnDestroy()
        {
            input.Destroy();
            GameManager.OnGameLost -= GameManager_OnGameLost;
            GameManager.OnLevelFinished -= GameManager_OnLevelFinished;
            GameManager.OnLevelStart -= GameManager_OnLevelStart;
            PauseManager.UnregisterPausable(this);
        }

        private void Movement_OnMoveFinished()
        {
            if (!groundCheck.IsGrounded(out Transform ground))
            {
                hitEventComponent.Hit();
                return;
            }
            transform.parent = ground != null && ground.CompareTag(PLATFORM_TAG) ? ground : null;
        }

        private void Movement_OnMoveStarted()
        {
            audio.PlayJumpSound();
        }

        private void HitEventComponent_OnHit()
        {
            audio.PlayHitSound();
        }

        private void GameManager_OnGameLost()
        {
            movement.Reset();
            transform.parent = null;
        }

        private void GameManager_OnLevelFinished()
        {
            input.Enabled = false;
            movement.Reset();
            transform.parent = null;
        }

        private void GameManager_OnLevelStart()
        {
            input.Enabled = true;
        }

        public void SetPause(bool paused)
        {
            input.Enabled = !paused;
            movement.SetPause(paused);
        }
    }
}
