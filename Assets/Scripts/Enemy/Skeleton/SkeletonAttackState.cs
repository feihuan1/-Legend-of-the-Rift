using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    public SkeletonAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    private Enemy_Skeleton enemy;

    public override void Enter()
    {
        base.Enter();

    }


    public override void Exit()
    {
        base.Exit();
        
        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();

        if(triggerCalled)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
