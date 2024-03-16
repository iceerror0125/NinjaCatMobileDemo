using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Player player, string animName) : base(player, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (InputManager.Instance.Jump())
        {
            KunaiManager.Instance.SpawnKunai(GameManager.Instance.GetNearestBlockList());
           
            if (player.isInJumpTile)
            {
                PlayerManager.Instance.MoveToNextTile();
            }

            stateMachine.ChangeState(player.rightThrowState);
        }
    }
}
