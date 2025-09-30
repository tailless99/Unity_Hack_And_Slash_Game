using UnityEngine;
using UnityEngine.InputSystem;
using static Constants;

public class PlayerStateMove : PlayerState, IPlayerState {
    private float _moveSpeed;

    public PlayerStateMove(PlayerController playerController, Animator animator, PlayerInput playerInput)
    : base(playerController, animator, playerInput) {
    }

    public void Enter() {
        _animator.SetBool(PlayerAnimParamMove, true);

        // Player Input에 대한 액션 할당
        _playerInput.actions["Fire"].performed += Attack;
        _playerInput.actions["Jump"].performed += Jump;

        // _moveSpeed 초기화
        _moveSpeed = 0;
    }

    public void Update() {
        // 회전 or 대기 상태 전환
        var moveVector = _playerInput.actions["Move"].ReadValue<Vector2>();
        if(moveVector != Vector2.zero) {
            Rotate(moveVector.x, moveVector.y);
        }
        else {
            _playerController.SetState(EPlayerState.Idle);
        }

        // 움직임 속도 설정
        var isRun = _playerInput.actions["Run"].IsPressed();
        if (isRun && _moveSpeed < 1f) {
            _moveSpeed += Time.deltaTime;
            _moveSpeed = Mathf.Clamp01(_moveSpeed);
        }
        else if(!isRun && _moveSpeed > 0f){
            _moveSpeed -= Time.deltaTime * _playerController.breakForce;
            _moveSpeed = Mathf.Clamp01(_moveSpeed);
        }
        _animator.SetFloat(PlayerAnimParamMoveSpeed, _moveSpeed);
    }

    public void Exit() {
        _animator.SetBool(PlayerAnimParamMove, false);

        // Player Input에 대한 액션 해제
        _playerInput.actions["Fire"].performed -= Attack;
        _playerInput.actions["Jump"].performed -= Jump;
    }
}
