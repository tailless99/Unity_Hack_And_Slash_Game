using UnityEngine;
using UnityEngine.InputSystem;
using static Constants;

public class PlayerStateIdle: PlayerState, IPlayerState
{
    public PlayerStateIdle(PlayerController playerController, Animator animator, PlayerInput playerInput) 
        : base(playerController, animator, playerInput) { }

    public void Enter()
    {
        _animator.SetBool(PlayerAnimParamIdle, true);
        
        // Player Input에 대한 액션 할당
        _playerInput.actions["Fire"].performed += Attack;
        _playerInput.actions["Jump"].performed += Jump;
    }

    public void Update()
    {
        if (_playerInput.actions["Move"].IsPressed()) {
            _playerController.SetState(EPlayerState.Move);
        }
    }

    public void Exit()
    {
        _animator.SetBool(PlayerAnimParamIdle, false);

        // Player Input에 대한 액션 해제
        _playerInput.actions["Fire"].performed -= Attack;
        _playerInput.actions["Jump"].performed -= Jump;
    }
}