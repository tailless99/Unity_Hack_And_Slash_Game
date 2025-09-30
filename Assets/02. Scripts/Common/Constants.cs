using UnityEngine;

public static class Constants
{
    public const float Gravity = -9.81f;

    // 레이어 마스크
    public static LayerMask GroundLayer = LayerMask.GetMask("Ground");

    // Player 상태
    public enum EPlayerState { None, Idle, Move, Jump, Attack, Hit, Dead }

    // Player 애니메이터 파라메터
    public static readonly int PlayerAnimParamIdle = Animator.StringToHash("idle");
    public static readonly int PlayerAnimParamMove = Animator.StringToHash("move");
    public static readonly int PlayerAnimParamJump = Animator.StringToHash("jump");
    public static readonly int PlayerAnimParamAttack = Animator.StringToHash("attack");
    public static readonly int PlayerAnimParamMoveSpeed = Animator.StringToHash("move_speed");
    public static readonly int PlayerAnimParamGroundDistance = Animator.StringToHash("ground_distance");
}