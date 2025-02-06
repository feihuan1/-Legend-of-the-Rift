using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rb.linearVelocityY);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Dashing");

        player.SetVelocity(player.dashSpeed* player.facingDir, rb.linearVelocityY);

        if(stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
