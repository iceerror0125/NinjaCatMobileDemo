using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftThrowState : BaseState
{
    public LeftThrowState(Player player, string animName) : base(player, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0.5f;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
