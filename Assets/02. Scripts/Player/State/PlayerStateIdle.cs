using UnityEngine;

public class PlayerStateIdle : PlayerState, IPlayerState {
    public PlayerStateIdle(PlayerController playerController, Animator animator) : base(playerController, animator) {
    }

    // ���� ���� �� �� ��
    public void Enter() {
        throw new System.NotImplementedException();
    }

    // ���� ���� �� �� ��
    public void Exit() {
        throw new System.NotImplementedException();
    }

    // ���� ���� �� �� ��
    public void Update() {
        throw new System.NotImplementedException();
    }
}
