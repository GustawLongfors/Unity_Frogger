using System;
using Code.Input;
using DG.Tweening;
using UnityEngine;

namespace Code.Player
{
    public class PlayerMovement
    {
        private readonly Transform playerTransform;
        private readonly PlayerParameters parameters;
        private const int JUMPS = 1;
        private bool lockMovement;
        private Tween jumpTween;
        private Vector3 startPosition;

        public event Action OnMoveFinished;
        public event Action OnMoveStarted;
        
        public PlayerMovement(PlayerInput input, Transform playerTransform, PlayerParameters parameters)
        {
            input.OnMovementPerformed += OnMovementPerformed;
            this.playerTransform = playerTransform;
            this.parameters = parameters;
            startPosition = playerTransform.position;
        }

        private void OnMovementPerformed(Vector2Int movement)
        {
            if (lockMovement || !CanMove(movement)) return;
            lockMovement = true;
            Jump(movement);
        }

        private void Jump(Vector2Int movement)
        {
            OnMoveStarted?.Invoke();
            Vector3 endPosition = playerTransform.localPosition + new Vector3(movement.x, 0, movement.y);
            jumpTween = playerTransform.DOLocalJump(endPosition, parameters.JumpPower, JUMPS, parameters.JumpDuration);
            jumpTween.onComplete = OnJumpComplete;
        }

        private bool CanMove(Vector2Int movement)
        {
            float desiredX = playerTransform.position.x + movement.x;
            float desiredZ = playerTransform.position.z + movement.y;
            return desiredX >= parameters.XMovementRange.x && desiredX <= parameters.XMovementRange.y && desiredZ>=startPosition.z;
        }

        private void OnJumpComplete()
        {
            lockMovement = false;
            OnMoveFinished?.Invoke();
        }

        public void Reset()
        {
            jumpTween.Kill();
            lockMovement = false;
            playerTransform.position = startPosition;
        }

        public void SetPause(bool paused)
        {
            if (paused) jumpTween.Pause();
            else jumpTween.Play();
        }
    }
}