using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Constants;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour {
    // ������Ʈ ĳ��
    private Animator _animator;
    private PlayerInput _playerInput;

    // ���� ����
    public EPlayerState State { get; private set; }
    private Dictionary<EPlayerState, IPlayerState> _states;


    private void Awake() {
        // ������Ʈ �ʱ�ȭ
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();

        // ���� ��ü �ʱ�ȭ
        var PlayerStateIdle = new PlayerStateIdle(this, _animator);
        _states = new Dictionary<EPlayerState, IPlayerState> {
            { EPlayerState.Idle, PlayerStateIdle },
        };
        // ���� �ʱ�ȭ
        SetState(EPlayerState.Idle);
    }

    private void Update() {
        if (State != EPlayerState.None) {
            _states[State].Update();
        }
    }

    public void SetState(EPlayerState state) {
        if (State == state) return;

        if(state != EPlayerState.None) _states[State].Exit();
        State = state;
        if (state != EPlayerState.None) _states[State].Enter();
    }
}
