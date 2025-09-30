using UnityEngine;
using static Constants;
using UnityEngine.InputSystem;
using static CharacterUtility;

public class PlayerStateJump : PlayerState, IPlayerState {
    public PlayerStateJump(PlayerController playerController, Animator animator, PlayerInput playerInput)
        : base(playerController, animator, playerInput) {
    }

    public void Enter() {
        _animator.SetTrigger("jump");
    }

    public void Update() {
        // 회전 or 대기 상태 전환
        var moveVector = _playerInput.actions["Move"].ReadValue<Vector2>();
        if (moveVector != Vector2.zero) {
            Rotate(moveVector.x, moveVector.y);
        }

        // Grounded Distante 업데이트
        var playerPosition = _playerController.transform.position;
        var distance = GetDistanceToGround(playerPosition, GroundLayer, 10f);
        _animator.SetFloat(PlayerAnimParamGroundDistance, distance);
    }

    public void Exit() {
       
    }
}