using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightThrowState : BaseState
{
    public RightThrowState(Player player, string animName) : base(player, animName)
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
