using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseState
{
    protected StateMachine stateMachine;
    protected Player player;
    private string animName;
    protected float timer;

    public BaseState(Player player, string animName)
    {
        this.player = player;
        this.animName = animName;
        stateMachine = player.stateMachine;

    }
    public virtual void Enter() { this.player.anim.Play(animName); }
    public virtual void Exit() { }
    public virtual void Update() { timer -= Time.deltaTime; }
}
